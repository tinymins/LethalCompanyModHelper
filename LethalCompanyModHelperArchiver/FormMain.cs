using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LethalCompanyModHelperArchiver
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Text = Program.GetI18nString("FormMain/FormMainTitle");
            btnStart.Text = Program.GetI18nString("FormMain/BtnStartText");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string[] installerFiles = { "LethalCompanyModHelper.exe", "Gameloop.Vdf.dll" };
            var targetFile = "installer.exe";

            // Check if installer file exists
            foreach (var installerExeFile in installerFiles)
            {
                if (!File.Exists(installerExeFile))
                {
                    MessageBox.Show(
                        $"{Program.GetI18nString("FormMain/InstallerFileMissingL")} {installerExeFile} {Program.GetI18nString("FormMain/InstallerFileMissingR")}",
                        Program.GetI18nString("FormMain/Error"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            // Make installer 7z files string
            var installerFileString = string.Join(" ", installerFiles.Select(d => $"\"{d}\""));

            // Get the current assembly
            var assembly = Assembly.GetExecutingAssembly();

            // Get the embedded resource streams
            Stream sfxStream = assembly.GetManifestResourceStream("LethalCompanyModHelperArchiver.Resources.7zSD.sfx");
            Stream exeStream = assembly.GetManifestResourceStream("LethalCompanyModHelperArchiver.Resources.7zr.exe");

            // Write the resources to temporary files
            Random random = new Random();
            byte[] tempFileNameBuffer = new byte[4];
            random.NextBytes(tempFileNameBuffer);
            string tempFileNameHex = BitConverter.ToString(tempFileNameBuffer).Replace("-", "");
            string tempDir = Path.Combine(Path.GetTempPath(), $"LethalCompanyModHelperArchiver{tempFileNameHex}");
            Directory.CreateDirectory(tempDir);

            string sfxPath = Path.Combine(tempDir, "7zSD.sfx");
            string configPath = Path.Combine(tempDir, "7z-config.txt");
            string exePath = Path.Combine(tempDir, "7zr.exe");

            using (var fileStream = new FileStream(sfxPath, FileMode.Create))
            {
                sfxStream.CopyTo(fileStream);
            }

            // Write the config file
            using (var writer = new StreamWriter(configPath))
            {
                writer.WriteLine(";!@Install@!UTF-8!");
                writer.WriteLine("Title=\"LethalCompanyModHelper\"");
                writer.WriteLine("RunProgram=\"LethalCompanyModHelper.exe\"");
                writer.WriteLine(";!@InstallEnd@!");
            }

            using (var fileStream = new FileStream(exePath, FileMode.Create))
            {
                exeStream.CopyTo(fileStream);
            }

            // Make mods 7z files string
            string currentDirectory = Path.GetDirectoryName(assembly.Location);
            string[] modDirectories = Directory.GetDirectories(currentDirectory);
            string modDirectoriesString = string.Join(" ", modDirectories.Select(d => $"\"{d}\""));

            // Delete the existing archive and exe if they exist
            File.Delete("archive.7z");
            File.Delete(targetFile);

            // Run 7zr to create the archive
            var startInfo = new ProcessStartInfo
            {
                FileName = exePath,
                Arguments = $"a archive.7z {installerFileString} {modDirectoriesString} -mx -mf=BCJ2",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = Process.Start(startInfo);
            process.WaitForExit();

            // Concatenate the sfx, config, and archive to create the exe
            using (var outputStream = new FileStream(targetFile, FileMode.Create))
            {
                using (var inputStream = new FileStream(sfxPath, FileMode.Open))
                {
                    inputStream.CopyTo(outputStream);
                }

                using (var inputStream = new FileStream(configPath, FileMode.Open))
                {
                    inputStream.CopyTo(outputStream);
                }

                using (var inputStream = new FileStream("archive.7z", FileMode.Open))
                {
                    inputStream.CopyTo(outputStream);
                }
            }

            // Clean up the temporary files
            File.Delete(sfxPath);
            File.Delete(configPath);
            File.Delete(exePath);
            File.Delete("archive.7z");
            Directory.Delete(tempDir);

            MessageBox.Show(Program.GetI18nString("FormMain/CreateArchiveSuccess"));
            Process.Start("explorer.exe", $"/select,\"{targetFile}\"");
        }
    }
}
