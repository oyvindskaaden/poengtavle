namespace poengtavle
{
    partial class FormControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormControl));
            this.menuStripStd = new System.Windows.Forms.MenuStrip();
            this.filToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lagreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.åpneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nyPoengtavleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poengtavleToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.fraMalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.malToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.poengtavleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.startFullskjermToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poengtavleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fraMalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.malToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.pMenu = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.pMusic = new System.Windows.Forms.Panel();
            this.bOpenMusic = new System.Windows.Forms.Button();
            this.musicFolder = new System.Windows.Forms.OpenFileDialog();
            this.menuStripStd.SuspendLayout();
            this.pMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.pMusic.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripStd
            // 
            this.menuStripStd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filToolStripMenuItem,
            this.nyPoengtavleToolStripMenuItem,
            this.poengtavleToolStripMenuItem1});
            this.menuStripStd.Location = new System.Drawing.Point(0, 0);
            this.menuStripStd.Name = "menuStripStd";
            this.menuStripStd.Size = new System.Drawing.Size(953, 24);
            this.menuStripStd.TabIndex = 0;
            this.menuStripStd.Text = "meny";
            // 
            // filToolStripMenuItem
            // 
            this.filToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.filToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lagreToolStripMenuItem,
            this.åpneToolStripMenuItem});
            this.filToolStripMenuItem.Name = "filToolStripMenuItem";
            this.filToolStripMenuItem.Size = new System.Drawing.Size(31, 20);
            this.filToolStripMenuItem.Text = "Fil";
            // 
            // lagreToolStripMenuItem
            // 
            this.lagreToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lagreToolStripMenuItem.Name = "lagreToolStripMenuItem";
            this.lagreToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.lagreToolStripMenuItem.Text = "Lagre";
            this.lagreToolStripMenuItem.Click += new System.EventHandler(this.MenuClicked);
            // 
            // åpneToolStripMenuItem
            // 
            this.åpneToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.åpneToolStripMenuItem.Name = "åpneToolStripMenuItem";
            this.åpneToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.åpneToolStripMenuItem.Text = "Åpne";
            this.åpneToolStripMenuItem.Click += new System.EventHandler(this.MenuClicked);
            // 
            // nyPoengtavleToolStripMenuItem
            // 
            this.nyPoengtavleToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.nyPoengtavleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.poengtavleToolStripMenuItem2,
            this.fraMalToolStripMenuItem1,
            this.malToolStripMenuItem1});
            this.nyPoengtavleToolStripMenuItem.Name = "nyPoengtavleToolStripMenuItem";
            this.nyPoengtavleToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.nyPoengtavleToolStripMenuItem.Text = "Ny";
            // 
            // poengtavleToolStripMenuItem2
            // 
            this.poengtavleToolStripMenuItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.poengtavleToolStripMenuItem2.Name = "poengtavleToolStripMenuItem2";
            this.poengtavleToolStripMenuItem2.Size = new System.Drawing.Size(133, 22);
            this.poengtavleToolStripMenuItem2.Text = "Poengtavle";
            this.poengtavleToolStripMenuItem2.Click += new System.EventHandler(this.MenuClicked);
            // 
            // fraMalToolStripMenuItem1
            // 
            this.fraMalToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fraMalToolStripMenuItem1.Name = "fraMalToolStripMenuItem1";
            this.fraMalToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.fraMalToolStripMenuItem1.Text = "Fra mal";
            this.fraMalToolStripMenuItem1.Click += new System.EventHandler(this.MenuClicked);
            // 
            // malToolStripMenuItem1
            // 
            this.malToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.malToolStripMenuItem1.Name = "malToolStripMenuItem1";
            this.malToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.malToolStripMenuItem1.Text = "Mal";
            this.malToolStripMenuItem1.Click += new System.EventHandler(this.MenuClicked);
            // 
            // poengtavleToolStripMenuItem1
            // 
            this.poengtavleToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.poengtavleToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startFullskjermToolStripMenuItem});
            this.poengtavleToolStripMenuItem1.Name = "poengtavleToolStripMenuItem1";
            this.poengtavleToolStripMenuItem1.Size = new System.Drawing.Size(78, 20);
            this.poengtavleToolStripMenuItem1.Text = "Poengtavle";
            // 
            // startFullskjermToolStripMenuItem
            // 
            this.startFullskjermToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.startFullskjermToolStripMenuItem.Name = "startFullskjermToolStripMenuItem";
            this.startFullskjermToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.startFullskjermToolStripMenuItem.Text = "Start";
            this.startFullskjermToolStripMenuItem.Click += new System.EventHandler(this.MenuClicked);
            // 
            // poengtavleToolStripMenuItem
            // 
            this.poengtavleToolStripMenuItem.Name = "poengtavleToolStripMenuItem";
            this.poengtavleToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.poengtavleToolStripMenuItem.Text = "Poengtavle";
            // 
            // fraMalToolStripMenuItem
            // 
            this.fraMalToolStripMenuItem.Name = "fraMalToolStripMenuItem";
            this.fraMalToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.fraMalToolStripMenuItem.Text = "Fra Mal";
            // 
            // malToolStripMenuItem
            // 
            this.malToolStripMenuItem.Name = "malToolStripMenuItem";
            this.malToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.malToolStripMenuItem.Text = "Mal";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(67, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ny";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonPressed);
            // 
            // pMenu
            // 
            this.pMenu.Controls.Add(this.label2);
            this.pMenu.Controls.Add(this.label1);
            this.pMenu.Controls.Add(this.button4);
            this.pMenu.Controls.Add(this.button3);
            this.pMenu.Controls.Add(this.button2);
            this.pMenu.Controls.Add(this.button1);
            this.pMenu.Location = new System.Drawing.Point(12, 27);
            this.pMenu.Name = "pMenu";
            this.pMenu.Size = new System.Drawing.Size(416, 292);
            this.pMenu.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(270, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Reprise";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ny poengtavle";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(274, 111);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Åpne";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ButtonPressed);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(67, 169);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Ny mal";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ButtonPressed);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(67, 140);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Fra mal";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ButtonPressed);
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Dock = System.Windows.Forms.DockStyle.Top;
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(0, 0);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
            this.mediaPlayer.Size = new System.Drawing.Size(385, 65);
            this.mediaPlayer.TabIndex = 5;
            // 
            // pMusic
            // 
            this.pMusic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pMusic.Controls.Add(this.bOpenMusic);
            this.pMusic.Controls.Add(this.mediaPlayer);
            this.pMusic.Location = new System.Drawing.Point(64, 353);
            this.pMusic.Name = "pMusic";
            this.pMusic.Size = new System.Drawing.Size(387, 94);
            this.pMusic.TabIndex = 6;
            this.pMusic.Visible = false;
            // 
            // bOpenMusic
            // 
            this.bOpenMusic.Location = new System.Drawing.Point(3, 67);
            this.bOpenMusic.Name = "bOpenMusic";
            this.bOpenMusic.Size = new System.Drawing.Size(97, 23);
            this.bOpenMusic.TabIndex = 6;
            this.bOpenMusic.Text = "Åpne musikk";
            this.bOpenMusic.UseVisualStyleBackColor = true;
            this.bOpenMusic.Click += new System.EventHandler(this.OpenMusic);
            // 
            // musicFolder
            // 
            this.musicFolder.Filter = "Music files|*.mp3|All files|*.*";
            this.musicFolder.Multiselect = true;
            // 
            // FormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(953, 671);
            this.Controls.Add(this.pMusic);
            this.Controls.Add(this.pMenu);
            this.Controls.Add(this.menuStripStd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStripStd;
            this.MaximizeBox = false;
            this.Name = "FormControl";
            this.Text = "Kontrollpanel";
            this.Load += new System.EventHandler(this.FormControl_Load);
            this.menuStripStd.ResumeLayout(false);
            this.menuStripStd.PerformLayout();
            this.pMenu.ResumeLayout(false);
            this.pMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.pMusic.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripStd;
        private System.Windows.Forms.ToolStripMenuItem filToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lagreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem åpneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nyPoengtavleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poengtavleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fraMalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem malToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poengtavleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem startFullskjermToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poengtavleToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem fraMalToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem malToolStripMenuItem1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pMenu;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
        private System.Windows.Forms.Panel pMusic;
        private System.Windows.Forms.Button bOpenMusic;
        private System.Windows.Forms.OpenFileDialog musicFolder;
    }
}

