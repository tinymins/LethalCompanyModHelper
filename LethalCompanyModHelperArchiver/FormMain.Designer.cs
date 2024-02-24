namespace LethalCompanyModHelperArchiver
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnStart = new System.Windows.Forms.Button();
            this.txtCustomBasePath = new System.Windows.Forms.TextBox();
            this.chkCustomBase = new System.Windows.Forms.CheckBox();
            this.panelCustomBase = new System.Windows.Forms.Panel();
            this.panelCustomBaseSettings = new System.Windows.Forms.Panel();
            this.lblCustomBasePath = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCustomBasePath = new System.Windows.Forms.Button();
            this.txtCustomBaseName = new System.Windows.Forms.TextBox();
            this.lblCustomBaseName = new System.Windows.Forms.Label();
            this.lblAuthorURL = new System.Windows.Forms.Label();
            this.lblUpdateURL = new System.Windows.Forms.Label();
            this.lblREADME = new System.Windows.Forms.Label();
            this.txtAuthorURL = new System.Windows.Forms.TextBox();
            this.txtUpdateURL = new System.Windows.Forms.TextBox();
            this.txtREADME = new System.Windows.Forms.TextBox();
            this.lblCustomOptionalPath = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtCustomOptionalPath = new System.Windows.Forms.TextBox();
            this.btnCustomOptionalPath = new System.Windows.Forms.Button();
            this.panelCustomBase.SuspendLayout();
            this.panelCustomBaseSettings.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(12, 919);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(1192, 83);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtCustomBasePath
            // 
            this.txtCustomBasePath.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCustomBasePath.Location = new System.Drawing.Point(3, 3);
            this.txtCustomBasePath.Name = "txtCustomBasePath";
            this.txtCustomBasePath.Size = new System.Drawing.Size(874, 33);
            this.txtCustomBasePath.TabIndex = 1;
            this.txtCustomBasePath.TextChanged += new System.EventHandler(this.txtCustomBasePath_TextChanged);
            // 
            // chkCustomBase
            // 
            this.chkCustomBase.AutoSize = true;
            this.chkCustomBase.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCustomBase.Location = new System.Drawing.Point(14, 7);
            this.chkCustomBase.Name = "chkCustomBase";
            this.chkCustomBase.Size = new System.Drawing.Size(188, 31);
            this.chkCustomBase.TabIndex = 0;
            this.chkCustomBase.Text = "chkCustomBase";
            this.chkCustomBase.UseVisualStyleBackColor = true;
            this.chkCustomBase.CheckedChanged += new System.EventHandler(this.chkCustomBase_CheckedChanged);
            // 
            // panelCustomBase
            // 
            this.panelCustomBase.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelCustomBase.Controls.Add(this.chkCustomBase);
            this.panelCustomBase.Location = new System.Drawing.Point(13, 12);
            this.panelCustomBase.Name = "panelCustomBase";
            this.panelCustomBase.Size = new System.Drawing.Size(1192, 901);
            this.panelCustomBase.TabIndex = 4;
            // 
            // panelCustomBaseSettings
            // 
            this.panelCustomBaseSettings.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelCustomBaseSettings.Controls.Add(this.flowLayoutPanel2);
            this.panelCustomBaseSettings.Controls.Add(this.lblCustomOptionalPath);
            this.panelCustomBaseSettings.Controls.Add(this.txtREADME);
            this.panelCustomBaseSettings.Controls.Add(this.txtUpdateURL);
            this.panelCustomBaseSettings.Controls.Add(this.txtAuthorURL);
            this.panelCustomBaseSettings.Controls.Add(this.lblREADME);
            this.panelCustomBaseSettings.Controls.Add(this.lblUpdateURL);
            this.panelCustomBaseSettings.Controls.Add(this.lblAuthorURL);
            this.panelCustomBaseSettings.Controls.Add(this.lblCustomBasePath);
            this.panelCustomBaseSettings.Controls.Add(this.flowLayoutPanel1);
            this.panelCustomBaseSettings.Controls.Add(this.txtCustomBaseName);
            this.panelCustomBaseSettings.Controls.Add(this.lblCustomBaseName);
            this.panelCustomBaseSettings.Enabled = false;
            this.panelCustomBaseSettings.Location = new System.Drawing.Point(13, 56);
            this.panelCustomBaseSettings.Name = "panelCustomBaseSettings";
            this.panelCustomBaseSettings.Size = new System.Drawing.Size(1192, 857);
            this.panelCustomBaseSettings.TabIndex = 4;
            // 
            // lblCustomBasePath
            // 
            this.lblCustomBasePath.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCustomBasePath.Location = new System.Drawing.Point(10, 9);
            this.lblCustomBasePath.Margin = new System.Windows.Forms.Padding(3);
            this.lblCustomBasePath.Name = "lblCustomBasePath";
            this.lblCustomBasePath.Size = new System.Drawing.Size(228, 42);
            this.lblCustomBasePath.TabIndex = 5;
            this.lblCustomBasePath.Text = "lblCustomBasePath";
            this.lblCustomBasePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.flowLayoutPanel1.Controls.Add(this.txtCustomBasePath);
            this.flowLayoutPanel1.Controls.Add(this.btnCustomBasePath);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(241, 9);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(948, 42);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // btnCustomBasePath
            // 
            this.btnCustomBasePath.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCustomBasePath.Location = new System.Drawing.Point(883, 3);
            this.btnCustomBasePath.Name = "btnCustomBasePath";
            this.btnCustomBasePath.Size = new System.Drawing.Size(45, 39);
            this.btnCustomBasePath.TabIndex = 2;
            this.btnCustomBasePath.Text = "...";
            this.btnCustomBasePath.UseVisualStyleBackColor = true;
            this.btnCustomBasePath.Click += new System.EventHandler(this.btnCustomBasePath_Click);
            // 
            // txtCustomBaseName
            // 
            this.txtCustomBaseName.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCustomBaseName.Location = new System.Drawing.Point(244, 55);
            this.txtCustomBaseName.Name = "txtCustomBaseName";
            this.txtCustomBaseName.Size = new System.Drawing.Size(931, 33);
            this.txtCustomBaseName.TabIndex = 3;
            this.txtCustomBaseName.TextChanged += new System.EventHandler(this.txtCustomBaseName_TextChanged);
            // 
            // lblCustomBaseName
            // 
            this.lblCustomBaseName.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCustomBaseName.Location = new System.Drawing.Point(10, 55);
            this.lblCustomBaseName.Margin = new System.Windows.Forms.Padding(3);
            this.lblCustomBaseName.Name = "lblCustomBaseName";
            this.lblCustomBaseName.Size = new System.Drawing.Size(228, 33);
            this.lblCustomBaseName.TabIndex = 6;
            this.lblCustomBaseName.Text = "lblCustomBaseName";
            this.lblCustomBaseName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAuthorURL
            // 
            this.lblAuthorURL.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAuthorURL.Location = new System.Drawing.Point(7, 137);
            this.lblAuthorURL.Margin = new System.Windows.Forms.Padding(3);
            this.lblAuthorURL.Name = "lblAuthorURL";
            this.lblAuthorURL.Size = new System.Drawing.Size(228, 33);
            this.lblAuthorURL.TabIndex = 7;
            this.lblAuthorURL.Text = "lblAuthorURL";
            this.lblAuthorURL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUpdateURL
            // 
            this.lblUpdateURL.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUpdateURL.Location = new System.Drawing.Point(7, 176);
            this.lblUpdateURL.Margin = new System.Windows.Forms.Padding(3);
            this.lblUpdateURL.Name = "lblUpdateURL";
            this.lblUpdateURL.Size = new System.Drawing.Size(228, 33);
            this.lblUpdateURL.TabIndex = 8;
            this.lblUpdateURL.Text = "lblUpdateURL";
            this.lblUpdateURL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblREADME
            // 
            this.lblREADME.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblREADME.Location = new System.Drawing.Point(7, 215);
            this.lblREADME.Margin = new System.Windows.Forms.Padding(3);
            this.lblREADME.Name = "lblREADME";
            this.lblREADME.Size = new System.Drawing.Size(228, 33);
            this.lblREADME.TabIndex = 9;
            this.lblREADME.Text = "lblREADME";
            this.lblREADME.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAuthorURL
            // 
            this.txtAuthorURL.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAuthorURL.Location = new System.Drawing.Point(244, 137);
            this.txtAuthorURL.Name = "txtAuthorURL";
            this.txtAuthorURL.Size = new System.Drawing.Size(931, 33);
            this.txtAuthorURL.TabIndex = 10;
            this.txtAuthorURL.TextChanged += new System.EventHandler(this.txtAuthorURL_TextChanged);
            // 
            // txtUpdateURL
            // 
            this.txtUpdateURL.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUpdateURL.Location = new System.Drawing.Point(244, 176);
            this.txtUpdateURL.Name = "txtUpdateURL";
            this.txtUpdateURL.Size = new System.Drawing.Size(931, 33);
            this.txtUpdateURL.TabIndex = 11;
            this.txtUpdateURL.TextChanged += new System.EventHandler(this.txtUpdateURL_TextChanged);
            // 
            // txtREADME
            // 
            this.txtREADME.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtREADME.Location = new System.Drawing.Point(244, 215);
            this.txtREADME.Multiline = true;
            this.txtREADME.Name = "txtREADME";
            this.txtREADME.Size = new System.Drawing.Size(931, 601);
            this.txtREADME.TabIndex = 12;
            this.txtREADME.TextChanged += new System.EventHandler(this.txtREADME_TextChanged);
            // 
            // lblCustomOptionalPath
            // 
            this.lblCustomOptionalPath.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCustomOptionalPath.Location = new System.Drawing.Point(7, 94);
            this.lblCustomOptionalPath.Margin = new System.Windows.Forms.Padding(3);
            this.lblCustomOptionalPath.Name = "lblCustomOptionalPath";
            this.lblCustomOptionalPath.Size = new System.Drawing.Size(228, 33);
            this.lblCustomOptionalPath.TabIndex = 14;
            this.lblCustomOptionalPath.Text = "lblCustomOptionalPath";
            this.lblCustomOptionalPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.flowLayoutPanel2.Controls.Add(this.txtCustomOptionalPath);
            this.flowLayoutPanel2.Controls.Add(this.btnCustomOptionalPath);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(241, 94);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(948, 42);
            this.flowLayoutPanel2.TabIndex = 15;
            // 
            // txtCustomOptionalPath
            // 
            this.txtCustomOptionalPath.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCustomOptionalPath.Location = new System.Drawing.Point(3, 3);
            this.txtCustomOptionalPath.Name = "txtCustomOptionalPath";
            this.txtCustomOptionalPath.Size = new System.Drawing.Size(874, 33);
            this.txtCustomOptionalPath.TabIndex = 1;
            this.txtCustomOptionalPath.TextChanged += new System.EventHandler(this.txtCustomOptionalPath_TextChanged);
            // 
            // btnCustomOptionalPath
            // 
            this.btnCustomOptionalPath.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCustomOptionalPath.Location = new System.Drawing.Point(883, 3);
            this.btnCustomOptionalPath.Name = "btnCustomOptionalPath";
            this.btnCustomOptionalPath.Size = new System.Drawing.Size(45, 39);
            this.btnCustomOptionalPath.TabIndex = 2;
            this.btnCustomOptionalPath.Text = "...";
            this.btnCustomOptionalPath.UseVisualStyleBackColor = true;
            this.btnCustomOptionalPath.Click += new System.EventHandler(this.btnCustomOptionalPath_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 1012);
            this.Controls.Add(this.panelCustomBaseSettings);
            this.Controls.Add(this.panelCustomBase);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelCustomBase.ResumeLayout(false);
            this.panelCustomBase.PerformLayout();
            this.panelCustomBaseSettings.ResumeLayout(false);
            this.panelCustomBaseSettings.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtCustomBasePath;
        private System.Windows.Forms.CheckBox chkCustomBase;
        private System.Windows.Forms.Panel panelCustomBase;
        private System.Windows.Forms.Panel panelCustomBaseSettings;
        private System.Windows.Forms.Button btnCustomBasePath;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblCustomBasePath;
        private System.Windows.Forms.TextBox txtCustomBaseName;
        private System.Windows.Forms.Label lblCustomBaseName;
        private System.Windows.Forms.Label lblAuthorURL;
        private System.Windows.Forms.Label lblUpdateURL;
        private System.Windows.Forms.Label lblREADME;
        private System.Windows.Forms.TextBox txtUpdateURL;
        private System.Windows.Forms.TextBox txtAuthorURL;
        private System.Windows.Forms.TextBox txtREADME;
        private System.Windows.Forms.Label lblCustomOptionalPath;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox txtCustomOptionalPath;
        private System.Windows.Forms.Button btnCustomOptionalPath;
    }
}

