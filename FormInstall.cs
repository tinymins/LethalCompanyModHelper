using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LethalCompanyModHelper
{
    public partial class FormInstall : Form
    {
        private readonly List<string> deleteDirectories = new List<string> { "_state", "BepInEx" };
        private string gamePath = "";
        private string modPath = "";
        private List<string> optionalPaths = new List<string>();

        public FormInstall(string gamePath, string modPath)
        {
            this.gamePath = gamePath;
            this.modPath = modPath;
            InitializeComponent();
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

        private void FormInstall_Load(object sender, EventArgs e)
        {
            // Initialize i18n
            this.Text = Properties.I18n.ResourceManager.GetString("FromInstall/FormTitle");
            lblSelectOptional.Text = Properties.I18n.ResourceManager.GetString("FromInstall/PleaseSelectOptionalModPacks:");
            btnInstall.Text = Properties.I18n.ResourceManager.GetString("FromInstall/StartInstall");

            // 获取可选包列表
            var optionalPath = Path.Combine(modPath, "Optional");

            optionalPaths.Clear();
            if (Directory.Exists(optionalPath))
            {
                var directories = Directory.GetDirectories(optionalPath);
                foreach (var directory in directories)
                {
                    if (Directory.Exists(Path.Combine(directory, "BepInEx")))
                    {
                        optionalPaths.Add(directory);
                    }
                }
            }

            clbOptional.Items.Clear();
            foreach (var p in optionalPaths)
            {
                string item = Path.GetFileName(p);
                clbOptional.Items.Add(item);
            }

            if (clbOptional.Items.Count == 0) {
                this.Hide();
                StartInstall();
            }
        }

        private void StartInstall()
        {
            // 获取名为 "Lethal Company" 的进程是否存在
            Process[] processes = Process.GetProcessesByName("Lethal Company");
            if (processes.Length > 0)
            {
                MessageBox.Show("Lethal Company.exe 进程存在，请先结束游戏！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 开始安装MOD
            btnInstall.Enabled = false;
            foreach (var dirName in deleteDirectories)
            {
                var dirPath = Path.Combine(gamePath, dirName);
                if (Directory.Exists(dirPath))
                {
                    Directory.Delete(dirPath, true);
                }
            }
            CopyDirectory(Path.Combine(modPath, "Base"), gamePath);
            foreach (var item in clbOptional.CheckedItems)
            {
                string optional = Path.Combine(modPath, "Optional", item.ToString());
                CopyDirectory(optional, gamePath);
            }
            btnInstall.Enabled = true;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"致命公司MOD包 \"{Path.GetFileName(modPath)}\" 安装成功！");
            if (clbOptional.CheckedItems.Count > 0)
            {
                sb.AppendLine("");
                sb.AppendLine("已安装可选功能包：");
                foreach (var item in clbOptional.CheckedItems)
                {
                    sb.AppendLine(item.ToString());
                }
            }
            MessageBox.Show(sb.ToString(), "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            StartInstall();
        }
    }
}
