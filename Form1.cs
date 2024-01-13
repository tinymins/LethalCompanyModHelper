using GameLib;
using GameLib.Core;
using System.Diagnostics;

namespace LethalCompanyModHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private IGame? game;
        private List<string> mods = new();
        private List<string> deleteDirectories = new() { "_state", "BepInEx" };
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

        private static IGame? GetGame()
        {
            var launcherManager = new LauncherManager(new LauncherOptions() { QueryOnlineData = true });
            foreach (var launcher in launcherManager.GetLaunchers())
            {
                if (launcher.Name.Equals("Steam"))
                {
                    foreach (var game in launcher.Games)
                    {
                        if (game.Id.Equals("1966720"))
                        {
                            return game;
                        }
                    }
                }
            }
            return null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 获取游戏
            var game = GetGame();
            if (game != null)
            {
                this.game = game;
                btnMod.Enabled = true;
                btnStart.Enabled = true;
            }
            else
            {
                MessageBox.Show("未找到致命公司安装路径！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string? item = Path.GetFileName(mod);
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
            if (game == null)
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

            // 复制文件
            foreach (var dirName in deleteDirectories)
            {
                var dirPath = Path.Combine(game.InstallDir, dirName);
                if (Directory.Exists(dirPath))
                {
                    Directory.Delete(dirPath, true);
                }
            }
            var modPath = mods[lstMods.SelectedIndex];
            CopyDirectory(modPath, game.InstallDir);
            MessageBox.Show($"致命公司MOD包 \"{lstMods.SelectedItem}\" 安装成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (game == null)
            {
                return;
            }
            Process.Start("explorer.exe", game.LaunchString);
            btnStart.Enabled = false;
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += TimerButtonStartClick_Tick;
            timer.Start();
        }

        private void TimerButtonStartClick_Tick(object? sender, EventArgs e)
        {
            btnStart.Enabled = true;
        }
    }
}
