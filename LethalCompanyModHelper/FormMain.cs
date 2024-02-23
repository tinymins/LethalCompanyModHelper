using Gameloop.Vdf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LethalCompanyModHelper
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private static readonly string gameId = "1966720";
        private string gamePath = null;
        private string aboutURL = null;
        private string updateURL = null;
        private readonly List<string> modPaths = new List<string> { };

        string GetKnownFolderPath(Guid knownFolderId)
        {
            IntPtr pszPath = IntPtr.Zero;
            try
            {
                int hr = SHGetKnownFolderPath(knownFolderId, 0, IntPtr.Zero, out pszPath);
                if (hr >= 0)
                    return Marshal.PtrToStringAuto(pszPath);
                throw Marshal.GetExceptionForHR(hr);
            }
            finally
            {
                if (pszPath != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(pszPath);
            }
        }

        [DllImport("shell32.dll")]
        static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr pszPath);

        private bool IsValidURL(string url)
        {
            return !string.IsNullOrWhiteSpace(url) && (url.StartsWith("http://") || url.StartsWith("https://"));
        }

        private string GetSteamInstallPath()
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Valve\Steam");
                if (key != null)
                {
                    string steamInstallPath = (string)key.GetValue("InstallPath");
                    key.Close();

                    if (!string.IsNullOrEmpty(steamInstallPath))
                    {
                        return steamInstallPath;
                    }
                }

                key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Valve\Steam");
                if (key != null)
                {
                    string steamInstallPath = (string)key.GetValue("InstallPath");
                    key.Close();

                    if (!string.IsNullOrEmpty(steamInstallPath))
                    {
                        return steamInstallPath;
                    }
                }
            }
            catch { }
            return null;
        }

        private string GetGameInstallPath()
        {
            try
            {
                var steamInstallPath = GetSteamInstallPath();
                if (string.IsNullOrEmpty(steamInstallPath))
                {
                    return null;
                }
                var libraryFoldersVdfPath = Path.Combine(steamInstallPath, "config", "libraryfolders.vdf");
                if (!File.Exists(libraryFoldersVdfPath))
                {
                    return null;
                }
                var volvoLibraryFolders = VdfConvert.Deserialize(File.ReadAllText(libraryFoldersVdfPath));
                foreach (dynamic item in volvoLibraryFolders.Value)
                {
                    dynamic itemValue = item.Value;
                    var appManifestPath = Path.Combine(itemValue.path.Value, "steamapps", $"appmanifest_{gameId}.acf");
                    if (!File.Exists(appManifestPath))
                    {
                        continue;
                    }
                    var volvoManifest = VdfConvert.Deserialize(File.ReadAllText(appManifestPath));
                    var gameInstallDir = volvoManifest.Value.installdir;
                    if (gameInstallDir == null)
                    {
                        continue;
                    }
                    var gameInstallPath = Path.Combine(itemValue.path.Value, "steamapps", "common", gameInstallDir.Value);
                    if (Directory.Exists(gameInstallPath))
                    {
                        return gameInstallPath;
                    }
                }
            }
            catch { }
            return null;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Initialize i18n
            this.Text = Program.GetI18nString("FormMain/FormTitle");
            linkOpenGamePath.Text = Program.GetI18nString("FormMain/GamePath");
            linkOpenSavePath.Text = Program.GetI18nString("FormMain/GameSavePath");
            linkModPath.Text = Program.GetI18nString("FormMain/ModPath");
            linkHomepage.Text = Program.GetI18nString("FormMain/AboutSoftwareAuthor");
            btnMod.Text = Program.GetI18nString("FormMain/InstallMod");
            btnStart.Text = Program.GetI18nString("FormMain/StartGame");
            btnAbout.Text = Program.GetI18nString("FormMain/AboutModAuthor");
            btnUpdate.Text = Program.GetI18nString("FormMain/CheckModUpdate");

            // 获取游戏
            gamePath = GetGameInstallPath();
            if (gamePath == null || gamePath.Equals(""))
            {
                gamePath = null;
                MessageBox.Show(Program.GetI18nString("FormMain/GamePathNotFoundError"), Program.GetI18nString("FormMain/Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                btnMod.Enabled = true;
                btnStart.Enabled = true;
            }

            // 获取 MOD 列表
            var exePath = AppDomain.CurrentDomain.BaseDirectory;
            var directories = Directory.GetDirectories(exePath);
            foreach (var directory in directories)
            {
                if (Directory.Exists(Path.Combine(directory, "Base", "BepInEx")))
                {
                    modPaths.Add(directory);
                }
            }
            lstMods.Items.Clear();
            foreach (var mod in modPaths)
            {
                string item = Path.GetFileName(mod);
                if (item != null)
                {
                    lstMods.Items.Add(item);
                }
            }
            lstMods.SelectedItems.Clear();
            if (lstMods.Items.Count != 0)
            {
                lstMods.SelectedItems.Add(lstMods.Items[0]);
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (gamePath == null)
            {
                MessageBox.Show(Program.GetI18nString("FormMain/GamePathNotFoundError"), Program.GetI18nString("FormMain/Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lstMods.SelectedIndex == -1)
            {
                MessageBox.Show(Program.GetI18nString("FormMain/ModFolderNotFoundError"), Program.GetI18nString("FormMain/Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormInstall formInstall = new FormInstall(gamePath, modPaths[lstMods.SelectedIndex]);
            formInstall.ShowDialog();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (gamePath == null)
            {
                return;
            }
            Process.Start("explorer.exe", $"steam://rungameid/{gameId}");
            btnStart.Enabled = false;
            var timer = new Timer();
            timer.Interval = 500;
            timer.Tick += TimerButtonStartClick_Tick;
            timer.Start();
        }

        private void TimerButtonStartClick_Tick(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
        }

        private void linkHomepage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", "https://zhaiyiming.com/feedback");
        }

        private void linkOpenGamePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", gamePath);
        }

        private void linkOpenSavePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Guid localLowId = new Guid("A520A1A4-1780-4FF6-BD18-167343C5AF16");
            string appDataPath = GetKnownFolderPath(localLowId);
            string targetPath = Path.Combine(appDataPath, "ZeekerssRBLX", "Lethal Company");
            Process.Start("explorer.exe", targetPath);
        }

        private void lstMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            string modName = modPaths[lstMods.SelectedIndex];

            string readme = "";
            string readmeFilePath = Path.Combine(modName, "README.txt");
            if (File.Exists(readmeFilePath))
            {
                readme = File.ReadAllText(readmeFilePath);
            }
            txtAbout.Text = readme;

            string aboutFilePath = Path.Combine(modName, "ABOUT.txt");
            aboutURL = File.Exists(aboutFilePath) ? File.ReadAllText(aboutFilePath) : null;
            btnAbout.Enabled = IsValidURL(aboutURL);

            string updateFilePath = Path.Combine(modName, "UPDATE.txt");
            updateURL = File.Exists(updateFilePath) ? File.ReadAllText(updateFilePath) : null;
            btnUpdate.Enabled = IsValidURL(updateURL);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            if (!IsValidURL(aboutURL))
            {
                return;
            }
            Process.Start("explorer.exe", aboutURL);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!IsValidURL(updateURL))
            {
                return;
            }
            Process.Start("explorer.exe", updateURL);
        }

        private void linkModPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
