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
            SuspendLayout();
            // 
            // lstMods
            // 
            lstMods.FormattingEnabled = true;
            lstMods.ItemHeight = 25;
            lstMods.Location = new Point(12, 12);
            lstMods.Name = "lstMods";
            lstMods.Size = new Size(516, 429);
            lstMods.TabIndex = 0;
            // 
            // btnMod
            // 
            btnMod.Enabled = false;
            btnMod.Location = new Point(12, 447);
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
            btnStart.Location = new Point(272, 447);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(254, 83);
            btnStart.TabIndex = 2;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 543);
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
        }

        #endregion

        private ListBox lstMods;
        private Button btnMod;
        private Button btnStart;
    }
}
