namespace Downstream
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.cbShow = new System.Windows.Forms.CheckBox();
            this.btnPrevTip = new System.Windows.Forms.Button();
            this.btnNextTip = new System.Windows.Forms.Button();
            this.picHelpImage = new System.Windows.Forms.PictureBox();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlBottom.Controls.Add(this.cbShow);
            this.pnlBottom.Controls.Add(this.btnPrevTip);
            this.pnlBottom.Controls.Add(this.btnNextTip);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 383);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(734, 51);
            this.pnlBottom.TabIndex = 0;
            // 
            // cbShow
            // 
            this.cbShow.AutoSize = true;
            this.cbShow.Location = new System.Drawing.Point(12, 18);
            this.cbShow.Name = "cbShow";
            this.cbShow.Size = new System.Drawing.Size(108, 17);
            this.cbShow.TabIndex = 2;
            this.cbShow.Text = "Don\'t show again";
            this.cbShow.UseVisualStyleBackColor = true;
            this.cbShow.CheckedChanged += new System.EventHandler(this.cbShow_CheckedChanged);
            // 
            // btnPrevTip
            // 
            this.btnPrevTip.Location = new System.Drawing.Point(575, 3);
            this.btnPrevTip.Name = "btnPrevTip";
            this.btnPrevTip.Size = new System.Drawing.Size(75, 45);
            this.btnPrevTip.TabIndex = 1;
            this.btnPrevTip.Text = "Previous Tip";
            this.btnPrevTip.UseVisualStyleBackColor = true;
            this.btnPrevTip.Click += new System.EventHandler(this.btnPrevTip_Click);
            // 
            // btnNextTip
            // 
            this.btnNextTip.Location = new System.Drawing.Point(656, 3);
            this.btnNextTip.Name = "btnNextTip";
            this.btnNextTip.Size = new System.Drawing.Size(75, 45);
            this.btnNextTip.TabIndex = 0;
            this.btnNextTip.Text = "Next Tip";
            this.btnNextTip.UseVisualStyleBackColor = true;
            this.btnNextTip.Click += new System.EventHandler(this.btnNextTip_Click);
            // 
            // picHelpImage
            // 
            this.picHelpImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHelpImage.Location = new System.Drawing.Point(12, 12);
            this.picHelpImage.Name = "picHelpImage";
            this.picHelpImage.Size = new System.Drawing.Size(710, 360);
            this.picHelpImage.TabIndex = 1;
            this.picHelpImage.TabStop = false;
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 434);
            this.Controls.Add(this.picHelpImage);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HelpForm";
            this.Text = "Downstream Quick Start Guide";
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.CheckBox cbShow;
        private System.Windows.Forms.Button btnPrevTip;
        private System.Windows.Forms.Button btnNextTip;
        private System.Windows.Forms.PictureBox picHelpImage;
    }
}