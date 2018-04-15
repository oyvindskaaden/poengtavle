namespace poengtavle
{
    partial class FormPoengtavle
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
            this.poengPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // poengPanel
            // 
            this.poengPanel.AutoSize = true;
            this.poengPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.poengPanel.Location = new System.Drawing.Point(163, 103);
            this.poengPanel.Name = "poengPanel";
            this.poengPanel.Size = new System.Drawing.Size(0, 0);
            this.poengPanel.TabIndex = 0;
            this.poengPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.MovePanelPanel);
            // 
            // FormPoengtavle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 551);
            this.Controls.Add(this.poengPanel);
            this.Name = "FormPoengtavle";
            this.Text = "Poengtavle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPoengtavleClosing);
            this.ResizeEnd += new System.EventHandler(this.MovePanel);
            this.SizeChanged += new System.EventHandler(this.MovePanel);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel poengPanel;
    }
}