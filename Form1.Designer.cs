﻿namespace LethalCompanyModHelper
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lstMods = new System.Windows.Forms.ListBox();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.linkHomepage = new System.Windows.Forms.LinkLabel();
            this.linkOpenGamePath = new System.Windows.Forms.LinkLabel();
            this.linkOpenSavePath = new System.Windows.Forms.LinkLabel();
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
            this.lstMods.Size = new System.Drawing.Size(514, 409);
            this.lstMods.TabIndex = 0;
            // 
            // btnMod
            // 
            this.btnMod.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMod.Location = new System.Drawing.Point(12, 478);
            this.btnMod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(254, 82);
            this.btnMod.TabIndex = 1;
            this.btnMod.Text = "安装 MOD";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(272, 478);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(254, 82);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始游戏";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // linkHomepage
            // 
            this.linkHomepage.AutoSize = true;
            this.linkHomepage.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkHomepage.Location = new System.Drawing.Point(434, 5);
            this.linkHomepage.Name = "linkHomepage";
            this.linkHomepage.Size = new System.Drawing.Size(92, 27);
            this.linkHomepage.TabIndex = 3;
            this.linkHomepage.TabStop = true;
            this.linkHomepage.Text = "关于作者";
            this.linkHomepage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHomepage_LinkClicked);
            // 
            // linkOpenGamePath
            // 
            this.linkOpenGamePath.AutoSize = true;
            this.linkOpenGamePath.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkOpenGamePath.Location = new System.Drawing.Point(6, 5);
            this.linkOpenGamePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkOpenGamePath.Name = "linkOpenGamePath";
            this.linkOpenGamePath.Size = new System.Drawing.Size(112, 27);
            this.linkOpenGamePath.TabIndex = 4;
            this.linkOpenGamePath.TabStop = true;
            this.linkOpenGamePath.Text = "游戏文件夹";
            this.linkOpenGamePath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOpenGamePath_LinkClicked);
            // 
            // linkOpenSavePath
            // 
            this.linkOpenSavePath.AutoSize = true;
            this.linkOpenSavePath.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkOpenSavePath.Location = new System.Drawing.Point(114, 5);
            this.linkOpenSavePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkOpenSavePath.Name = "linkOpenSavePath";
            this.linkOpenSavePath.Size = new System.Drawing.Size(112, 27);
            this.linkOpenSavePath.TabIndex = 5;
            this.linkOpenSavePath.TabStop = true;
            this.linkOpenSavePath.Text = "存档文件夹";
            this.linkOpenSavePath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOpenSavePath_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 583);
            this.Controls.Add(this.linkOpenSavePath);
            this.Controls.Add(this.linkOpenGamePath);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.linkHomepage);
            this.Controls.Add(this.lstMods);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "致命公司MOD安装器 --by@茗伊";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}
