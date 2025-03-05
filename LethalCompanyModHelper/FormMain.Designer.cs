namespace LethalCompanyModHelper
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
            this.lstMods = new System.Windows.Forms.ListBox();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.linkHomepage = new System.Windows.Forms.LinkLabel();
            this.linkOpenGamePath = new System.Windows.Forms.LinkLabel();
            this.linkOpenSavePath = new System.Windows.Forms.LinkLabel();
            this.txtAbout = new System.Windows.Forms.TextBox();
            this.btnAboutAuthor = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.linkModPath = new System.Windows.Forms.LinkLabel();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstMods
            // 
            this.lstMods.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstMods.FormattingEnabled = true;
            this.lstMods.ItemHeight = 27;
            this.lstMods.Location = new System.Drawing.Point(10, 34);
            this.lstMods.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstMods.Name = "lstMods";
            this.lstMods.Size = new System.Drawing.Size(1010, 112);
            this.lstMods.TabIndex = 0;
            this.lstMods.SelectedIndexChanged += new System.EventHandler(this.lstMods_SelectedIndexChanged);
            // 
            // btnMod
            // 
            this.btnMod.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMod.Location = new System.Drawing.Point(11, 778);
            this.btnMod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(245, 82);
            this.btnMod.TabIndex = 1;
            this.btnMod.Text = "Install MOD";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(263, 778);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(245, 82);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // linkHomepage
            // 
            this.linkHomepage.AutoSize = true;
            this.linkHomepage.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkHomepage.Location = new System.Drawing.Point(262, 0);
            this.linkHomepage.Name = "linkHomepage";
            this.linkHomepage.Size = new System.Drawing.Size(71, 27);
            this.linkHomepage.TabIndex = 3;
            this.linkHomepage.TabStop = true;
            this.linkHomepage.Text = "About";
            this.linkHomepage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHomepage_LinkClicked);
            // 
            // linkOpenGamePath
            // 
            this.linkOpenGamePath.AutoSize = true;
            this.linkOpenGamePath.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkOpenGamePath.Location = new System.Drawing.Point(4, 0);
            this.linkOpenGamePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkOpenGamePath.Name = "linkOpenGamePath";
            this.linkOpenGamePath.Size = new System.Drawing.Size(135, 27);
            this.linkOpenGamePath.TabIndex = 4;
            this.linkOpenGamePath.TabStop = true;
            this.linkOpenGamePath.Text = "Game Folder";
            this.linkOpenGamePath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOpenGamePath_LinkClicked);
            // 
            // linkOpenSavePath
            // 
            this.linkOpenSavePath.AutoSize = true;
            this.linkOpenSavePath.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkOpenSavePath.Location = new System.Drawing.Point(147, 0);
            this.linkOpenSavePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkOpenSavePath.Name = "linkOpenSavePath";
            this.linkOpenSavePath.Size = new System.Drawing.Size(124, 27);
            this.linkOpenSavePath.TabIndex = 5;
            this.linkOpenSavePath.TabStop = true;
            this.linkOpenSavePath.Text = "Save Folder";
            this.linkOpenSavePath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOpenSavePath_LinkClicked);
            // 
            // txtAbout
            // 
            this.txtAbout.BackColor = System.Drawing.SystemColors.Window;
            this.txtAbout.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbout.Location = new System.Drawing.Point(10, 152);
            this.txtAbout.Multiline = true;
            this.txtAbout.Name = "txtAbout";
            this.txtAbout.ReadOnly = true;
            this.txtAbout.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAbout.Size = new System.Drawing.Size(1010, 611);
            this.txtAbout.TabIndex = 6;
            // 
            // btnAbout
            // 
            this.btnAboutAuthor.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAboutAuthor.Location = new System.Drawing.Point(515, 778);
            this.btnAboutAuthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAboutAuthor.Name = "btnAbout";
            this.btnAboutAuthor.Size = new System.Drawing.Size(245, 82);
            this.btnAboutAuthor.TabIndex = 7;
            this.btnAboutAuthor.Text = "About Author";
            this.btnAboutAuthor.UseVisualStyleBackColor = true;
            this.btnAboutAuthor.Click += new System.EventHandler(this.btnAboutAuthor_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdate.Location = new System.Drawing.Point(767, 778);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(245, 82);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Check Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.linkOpenGamePath);
            this.flowLayoutPanel1.Controls.Add(this.linkOpenSavePath);
            this.flowLayoutPanel1.Controls.Add(this.linkModPath);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(681, 27);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.linkHomepage);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(690, 5);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(336, 27);
            this.flowLayoutPanel2.TabIndex = 10;
            // 
            // linkModPath
            // 
            this.linkModPath.AutoSize = true;
            this.linkModPath.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkModPath.Location = new System.Drawing.Point(279, 0);
            this.linkModPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkModPath.Name = "linkModPath";
            this.linkModPath.Size = new System.Drawing.Size(130, 27);
            this.linkModPath.TabIndex = 6;
            this.linkModPath.TabStop = true;
            this.linkModPath.Text = "MOD Folder";
            this.linkModPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkModPath_LinkClicked);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 871);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.txtAbout);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAboutAuthor);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.lstMods);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lethal Company Mod Helper -- by TinyMins";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstMods;
        private System.Windows.Forms.LinkLabel linkHomepage;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.LinkLabel linkOpenGamePath;
        private System.Windows.Forms.LinkLabel linkOpenSavePath;
        private System.Windows.Forms.TextBox txtAbout;
        private System.Windows.Forms.Button btnAboutAuthor;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.LinkLabel linkModPath;
    }
}
