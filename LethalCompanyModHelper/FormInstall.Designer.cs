namespace LethalCompanyModHelper
{
    partial class FormInstall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInstall));
            this.btnInstall = new System.Windows.Forms.Button();
            this.clbOptional = new System.Windows.Forms.CheckedListBox();
            this.lblSelectOptional = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInstall
            // 
            this.btnInstall.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInstall.Location = new System.Drawing.Point(143, 649);
            this.btnInstall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(245, 82);
            this.btnInstall.TabIndex = 2;
            this.btnInstall.Text = "Start Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // clbOptional
            // 
            this.clbOptional.CheckOnClick = true;
            this.clbOptional.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbOptional.FormattingEnabled = true;
            this.clbOptional.Location = new System.Drawing.Point(17, 51);
            this.clbOptional.Name = "clbOptional";
            this.clbOptional.Size = new System.Drawing.Size(497, 574);
            this.clbOptional.TabIndex = 3;
            // 
            // lblSelectOptional
            // 
            this.lblSelectOptional.AutoSize = true;
            this.lblSelectOptional.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectOptional.Location = new System.Drawing.Point(12, 13);
            this.lblSelectOptional.Name = "lblSelectOptional";
            this.lblSelectOptional.Size = new System.Drawing.Size(331, 27);
            this.lblSelectOptional.TabIndex = 4;
            this.lblSelectOptional.Text = "Please select optional mod packs:";
            // 
            // FormInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 766);
            this.Controls.Add(this.lblSelectOptional);
            this.Controls.Add(this.clbOptional);
            this.Controls.Add(this.btnInstall);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormInstall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Install";
            this.Load += new System.EventHandler(this.FormInstall_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.CheckedListBox clbOptional;
        private System.Windows.Forms.Label lblSelectOptional;
    }
}