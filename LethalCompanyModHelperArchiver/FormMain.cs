using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;
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
            chkCustomBase.Text = Program.GetI18nString("FormMain/CustomBase");
            lblCustomBaseName.Text = Program.GetI18nString("FormMain/CustomBaseName");
            lblCustomBasePath.Text = Program.GetI18nString("FormMain/CustomBasePath");
            lblCustomOptionalPath.Text = Program.GetI18nString("FormMain/CustomOptionalPath");
            lblAuthorURL.Text = Program.GetI18nString("FormMain/CustomAuthorURL");
            lblUpdateURL.Text = Program.GetI18nString("FormMain/CustomUpdateURL");
            lblREADME.Text = Program.GetI18nString("FormMain/CustomREADME");
            btnStart.Text = Program.GetI18nString("FormMain/BtnStartText");

            chkCustomBase.Checked = Properties.Settings.Default.CustomBase;
            txtCustomBasePath.Text = Properties.Settings.Default.CustomBasePath;
            txtCustomBaseName.Text = Properties.Settings.Default.CustomBaseName;
            txtCustomOptionalPath.Text = Properties.Settings.Default.CustomOptionalPath;
            txtAuthorURL.Text = Properties.Settings.Default.CustomAuthorURL;
            txtUpdateURL.Text = Properties.Settings.Default.CustomUpdateURL;
            txtREADME.Text = Properties.Settings.Default.CustomREADME;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            var form = new FormBuild();
            form.ShowDialog();
            btnStart.Enabled = true;
        }

        private void chkCustomBase_CheckedChanged(object sender, EventArgs e)
        {
            panelCustomBaseSettings.Enabled = chkCustomBase.Checked;
            Properties.Settings.Default.CustomBase = chkCustomBase.Checked;
            Properties.Settings.Default.Save();
        }

        private void btnCustomBasePath_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.Title = Program.GetI18nString("FormMain/SelectCustomBaseFolder");
            dialog.InitialDirectory = Properties.Settings.Default.CustomBasePath;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtCustomBasePath.Text = dialog.FileName;
                txtCustomBaseName.Text = Path.GetFileName(dialog.FileName);
            }
        }

        private void txtCustomBasePath_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CustomBasePath = txtCustomBasePath.Text;
            Properties.Settings.Default.Save();
        }

        private void txtCustomBaseName_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CustomBaseName = txtCustomBaseName.Text;
            Properties.Settings.Default.Save();
        }

        private void btnCustomOptionalPath_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.Title = Program.GetI18nString("FormMain/SelectCustomOptionalFolder");
            dialog.InitialDirectory = Properties.Settings.Default.CustomOptionalPath;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtCustomOptionalPath.Text = dialog.FileName;
            }
        }

        private void txtCustomOptionalPath_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CustomOptionalPath = txtCustomOptionalPath.Text;
            Properties.Settings.Default.Save();
        }

        private void txtAuthorURL_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CustomAuthorURL = txtAuthorURL.Text;
            Properties.Settings.Default.Save();
        }

        private void txtUpdateURL_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CustomUpdateURL = txtUpdateURL.Text;
            Properties.Settings.Default.Save();
        }

        private void txtREADME_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CustomREADME = txtREADME.Text;
            Properties.Settings.Default.Save();
        }
    }
}
