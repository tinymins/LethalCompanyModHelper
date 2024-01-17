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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static readonly string gameId = "1966720";
        private string gamePath = null;
        private readonly List<string> mods = new List<string> { };
        private readonly List<string> deleteDirectories = new List<string> { "_state", "BepInEx" };

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

        public static void CopyDirectory(string sourceDir, string targetDir)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            // 获取游戏
            gamePath = GetGameInstallPath();
            if (gamePath == null || gamePath.Equals(""))
            {
                gamePath = null;
                MessageBox.Show("未找到致命公司安装路径！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (Directory.Exists(Path.Combine(directory, "BepInEx")))
                {
                    mods.Add(directory);
                }
            }
            lstMods.Items.Clear();
            foreach (var mod in mods)
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
                MessageBox.Show("未找到致命公司安装路径！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lstMods.SelectedIndex == -1)
            {
                MessageBox.Show("找不到有效的MOD文件夹！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 获取名为 "Lethal Company" 的进程是否存在
            Process[] processes = Process.GetProcessesByName("Lethal Company");
            if (processes.Length > 0)
            {
                MessageBox.Show("Lethal Company.exe 进程存在，请先结束游戏！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 开始安装MOD
            btnMod.Enabled = false;
            foreach (var dirName in deleteDirectories)
            {
                var dirPath = Path.Combine(gamePath, dirName);
                if (Directory.Exists(dirPath))
                {
                    Directory.Delete(dirPath, true);
                }
            }
            var modPath = mods[lstMods.SelectedIndex];
            CopyDirectory(modPath, gamePath);
            btnMod.Enabled = true;
            MessageBox.Show($"致命公司MOD包 \"{lstMods.SelectedItem}\" 安装成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
