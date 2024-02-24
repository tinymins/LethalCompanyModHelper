using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LethalCompanyModHelperArchiver
{
    public partial class FormBuild : Form
    {
        private string[] installerFiles = { "LethalCompanyModHelper.exe", "Gameloop.Vdf.dll" };
        private Process process;
        private bool processCancelled = false;

        public FormBuild()
        {
            InitializeComponent();
        }

        private void Log(string str)
        {
            txtLogs.AppendText(str);
        }

        private static string GetRandomHEX(int length)
        {
            Random random = new Random();
            byte[] buffer = new byte[length];
            random.NextBytes(buffer);
            return BitConverter.ToString(buffer).Replace("-", "");
        }

        private static bool IsValidFileName(string testName)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            return !testName.Any(i => invalidChars.Contains(i));
        }

        private static void CopyDirectory(string sourceDir, string targetDir)
        {
            // Check if the target directory exists, if not, create it.
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            // Copy each file into the new directory.
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(targetDir, fileName);
                File.Copy(file, destFile, true); // true to overwrite
            }

            // Copy each subdirectory using recursion.
            foreach (string dir in Directory.GetDirectories(sourceDir))
            {
                string dirName = Path.GetFileName(dir);
                string destDir = Path.Combine(targetDir, dirName);
                CopyDirectory(dir, destDir);
            }
        }

        private bool CanMake()
        {
            // Check if installer file exists
            foreach (var installerExeFile in installerFiles)
            {
                if (!File.Exists(installerExeFile))
                {
                    MessageBox.Show(
                        $"{Program.GetI18nString("FormMain/InstallerFileMissing")} {installerExeFile}",
                        Program.GetI18nString("FormMain/Error"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }
            // Check custom base settings
            if (Properties.Settings.Default.CustomBase)
            {
                if (Properties.Settings.Default.CustomBasePath.Length == 0 || !Directory.Exists(Path.Combine(Properties.Settings.Default.CustomBasePath, "BepInEx")))
                {
                    MessageBox.Show(
                        $"{Program.GetI18nString("FormMain/CustomBasePathNotExists")}",
                        Program.GetI18nString("FormMain/Error"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                if (Properties.Settings.Default.CustomBaseName.Length == 0 || !IsValidFileName(Properties.Settings.Default.CustomBaseName))
                {
                    MessageBox.Show(
                        $"{Program.GetI18nString("FormMain/CustomBaseNameNotValid")}",
                        Program.GetI18nString("FormMain/Error"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                if (Properties.Settings.Default.CustomOptionalPath.Length != 0 && !Directory.Exists(Properties.Settings.Default.CustomOptionalPath))
                {
                    MessageBox.Show(
                        $"{Program.GetI18nString("FormMain/CustomOptionalPathNotExists")}",
                        Program.GetI18nString("FormMain/Error"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private async void StartMake()
        {
            // Make 7z files
            var filePaths = installerFiles.Select(_ => _).ToList();

            // Get the current assembly
            var assembly = Assembly.GetExecutingAssembly();

            // Get the embedded resource streams
            Stream sfxStream = assembly.GetManifestResourceStream("LethalCompanyModHelperArchiver.Resources.7zSD.sfx");
            Stream exeStream = assembly.GetManifestResourceStream("LethalCompanyModHelperArchiver.Resources.7zr.exe");

            // Write the resources to temporary files
            string temporaryPath = Path.Combine(Path.GetTempPath(), $"LethalCompanyModHelperArchiver{GetRandomHEX(4)}");
            string sfxPath = Path.Combine(temporaryPath, "7zSD.sfx");
            string configPath = Path.Combine(temporaryPath, "7z-config.txt");
            string exePath = Path.Combine(temporaryPath, "7zr.exe");

            Directory.CreateDirectory(temporaryPath);

            using (var fileStream = new FileStream(sfxPath, FileMode.Create))
            {
                sfxStream.CopyTo(fileStream);
            }
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

            // Add mods 7z files
            string currentDirectory = Path.GetDirectoryName(assembly.Location);
            string customModDirectory = null;
            string targetFile = "installer.exe";
            if (Properties.Settings.Default.CustomBase)
            {
                // Add custom mod Base
                customModDirectory = Path.Combine(temporaryPath, Properties.Settings.Default.CustomBaseName);
                Directory.CreateDirectory(customModDirectory);
                CopyDirectory(Properties.Settings.Default.CustomBasePath, Path.Combine(customModDirectory, "Base"));
                // Add custom mod Optional
                if (Properties.Settings.Default.CustomOptionalPath.Length > 0)
                {
                    CopyDirectory(Properties.Settings.Default.CustomOptionalPath, Path.Combine(customModDirectory, "Optional"));
                }
                // Add custom mod info files
                using (var writer = new StreamWriter(Path.Combine(customModDirectory, "AUTHOR.txt")))
                {
                    writer.Write(Properties.Settings.Default.CustomAuthorURL);
                }
                using (var writer = new StreamWriter(Path.Combine(customModDirectory, "UPDATE.txt")))
                {
                    writer.Write(Properties.Settings.Default.CustomUpdateURL);
                }
                using (var writer = new StreamWriter(Path.Combine(customModDirectory, "README.txt")))
                {
                    writer.Write(Properties.Settings.Default.CustomREADME);
                }
                // Add custom mod directory to file paths
                filePaths.Add(customModDirectory);
                targetFile = $"{Properties.Settings.Default.CustomBaseName}.exe";
            }

            string[] modDirectories = Directory.GetDirectories(currentDirectory);
            foreach (var fileName in modDirectories)
            {
                if (Properties.Settings.Default.CustomBase && Directory.Exists(Path.Combine(fileName, "Base", "BepInEx")))
                {
                    continue;
                }
                filePaths.Add(fileName);
            }

            // Make 7z files string
            var fileNameString = string.Join(" ", filePaths.Select(d => $"\"{d}\""));
            var archiveFilePath = Path.Combine(temporaryPath, "archive.7z");

            // Delete the existing exe if exists
            File.Delete(targetFile);

            Log("\r\n");
            Log("-----------------------------------------------------\r\n");
            Log("-- Start building mod installer!\r\n");
            Log("-----------------------------------------------------\r\n");

            // Run 7zr to create the archive
            var tcs = new TaskCompletionSource<bool>();
            var startInfo = new ProcessStartInfo
            {
                FileName = exePath,
                Arguments = $"a -mx -mf=BCJ2 -bsp1 \"{archiveFilePath}\" {fileNameString}",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
            };

            process = new Process();
            process.StartInfo = startInfo;
            process.OutputDataReceived += (sender, e) =>
            {
                try
                {
                    if (e.Data != null)
                    {
                        this.Invoke(new Action(() =>
                        {
                            Log(e.Data + Environment.NewLine);
                        }));
                    }
                }
                catch { }
            };
            process.Exited += (sender, args) =>
            {
                tcs.SetResult(true);
                process.Dispose();
            };
            process.EnableRaisingEvents = true;
            process.Start();

            process.BeginOutputReadLine();

            await tcs.Task;

            process = null;

            if (!processCancelled)
            {
                // Concatenate the sfx, config, and archive to create the exe
                Log("\r\n");
                Log("-----------------------------------------------------\r\n");
                Log("-- Create installer.exe file.\r\n");
                Log("-----------------------------------------------------\r\n");
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

                    using (var inputStream = new FileStream(archiveFilePath, FileMode.Open))
                    {
                        inputStream.CopyTo(outputStream);
                    }
                }
                Log("\r\nCreate installer.exe success.\r\n");
            }

            // Clean up the temporary files
            Directory.Delete(temporaryPath, true);

            if (!processCancelled)
            {
                MessageBox.Show(Program.GetI18nString("FormMain/CreateArchiveSuccess"));
                Process.Start("explorer.exe", $"/select,\"{targetFile}\"");
            }
            this.Close();
        }

        private void FormBuild_Load(object sender, EventArgs e)
        {
            this.Text = Program.GetI18nString("FormBuild/FormBuildTitle");
            btnStop.Text = Program.GetI18nString("FormBuild/StopBuild");

            if (!CanMake())
            {
                this.Close();
                return;
            }
            StartMake();
        }

        private void FormBuild_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (process != null && !process.HasExited)
            {
                processCancelled = true;
                process.Kill();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
