namespace LethalCompanyModHelper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lstMods = new ListBox();
            btnMod = new Button();
            btnStart = new Button();
            linkHomepage = new LinkLabel();
            SuspendLayout();
            // 
            // lstMods
            // 
            lstMods.FormattingEnabled = true;
            lstMods.ItemHeight = 25;
            lstMods.Location = new Point(12, 33);
            lstMods.Name = "lstMods";
            lstMods.Size = new Size(516, 429);
            lstMods.TabIndex = 0;
            // 
            // btnMod
            // 
            btnMod.Enabled = false;
            btnMod.Location = new Point(12, 468);
            btnMod.Name = "btnMod";
            btnMod.Size = new Size(254, 83);
            btnMod.TabIndex = 1;
            btnMod.Text = "MOD";
            btnMod.UseVisualStyleBackColor = true;
            btnMod.Click += btnMod_Click;
            // 
            // btnStart
            // 
            btnStart.Enabled = false;
            btnStart.Location = new Point(272, 468);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(254, 83);
            btnStart.TabIndex = 2;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // linkHomepage
            // 
            linkHomepage.AutoSize = true;
            linkHomepage.Location = new Point(440, 5);
            linkHomepage.Name = "linkHomepage";
            linkHomepage.Size = new Size(88, 25);
            linkHomepage.TabIndex = 3;
            linkHomepage.TabStop = true;
            linkHomepage.Text = "关于作者";
            linkHomepage.LinkClicked += linkHomepage_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 579);
            Controls.Add(linkHomepage);
            Controls.Add(btnStart);
            Controls.Add(btnMod);
            Controls.Add(lstMods);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "致命公司MOD安装器 --by@茗伊";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstMods;
        private Button btnMod;
        private Button btnStart;
        private LinkLabel linkHomepage;
    }
}
