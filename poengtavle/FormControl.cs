using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace poengtavle
{
    public partial class FormControl : Form
    {
        public FormControl()
        {
            InitializeComponent();
        }
        List<Config> c = new List<Config>();

        LoadFunc lf = new LoadFunc();

        List<FormPoengtavle> formPoeng = new List<FormPoengtavle>();
        List<DataTyper> controlList = new List<DataTyper>();
        List<Layout> layoutList = new List<Layout>();

        string folder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

        WMPLib.IWMPPlaylist playlist;

        private void FormControl_Load(object sender, EventArgs e)
        {
            formPoeng.Add(new FormPoengtavle());
            layoutList.Add(new Layout(this, "Poeng"));
            layoutList.Add(new Layout(this, "Klokke"));
            layoutList.Add(new Layout(this, "Perioder"));
            layoutList.Add(new Layout(this, "Reklame"));
            playlist = mediaPlayer.playlistCollection.newPlaylist("music");

            /*
            c.Add(new Config("Poeng", new Point(10, 34), new string[] { "Testlag1", "1"}));
            c.Add(new Config("Poeng", new Point(450, 34), new string[] { "Testlag2", "1"}));
            c.Add(new Config("Klokke", new Point(240, 34), new string[] { "5400", "100", "false" }));
            c.Add(new Config("Poeng", new Point(10, 244), null));
            c.Add(new Config("Poeng", new Point(450, 244), new string[] { "", "2" }));
            c.Add(new Config("Klokke", new Point(240, 244), new string[] { "0", "1000", "true" }));
            c.Add(new Config("Perioder", new Point(680, 34), new string[] { "1" }));
            c.Add(new Config("Reklame", new Point(680, 244), null));
            */
            /*
            c.Add(new Config("Poeng", new Point(10, 34), null));
            c.Add(new Config("Poeng", new Point(450, 34), null));
            c.Add(new Config("Klokke", new Point(240, 34), null));
            c.Add(new Config("Poeng", new Point(10, 244), null));
            c.Add(new Config("Poeng", new Point(450, 244), null));
            c.Add(new Config("Klokke", new Point(240, 244), null));
            c.Add(new Config("Perioder", new Point(680, 34), null));
            c.Add(new Config("Reklame", new Point(680, 244), null));
            */
        }

        private void MenuClicked(string s)
        {
            switch (s)
            {
                case "Ny":
                case "Poengtavle":
                    break;
                case "Fra mal":
                    break;
                case "Mal":
                case "Ny mal":
                    break;
                case "Lagre":
                    lf.WriteJSON(c, System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\test.json");
                    break;
                case "Åpne":
                    c = lf.ReadJSONtoObject(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\test.json");
                    //formPoeng[1].Show();
                    break;
                case "Start":
                    GetConfig();
                    CreatePoengtavle(c);
                    PlaceMusic();
                    formPoeng[0].Show();
                    pMenu.Visible = false;
                    configPanel.Visible = false;
                    kontrolPanel.Dock = DockStyle.Fill;
                    kontrolPanel.Visible = true;
                    break;                
            }

        }

        private void CreatePoengtavle(List<Config> e)
        {
            foreach (Config d in e)
            {
                switch (d.ConfType)
                {
                    case "Klokke":
                        controlList.Add(new Klokke(d, this, formPoeng));
                        break;
                    case "Poeng":
                        controlList.Add(new Poeng(d, this, formPoeng));
                        break;
                    case "Perioder":
                        controlList.Add(new Perioder(d, this, formPoeng));
                        break;
                    case "Reklame":
                        controlList.Add(new Reklame(d, this, formPoeng));
                        break;
                }
            }
        }

        public void GetConfig()
        {
            foreach (Layout l in layoutList)
            {
                c.Add(l.GetConfig());
            }
        }

        #region Musicplayer

        private void OpenMusic(object sender, EventArgs e)
        {
            playlist.clear();
            musicFolder.InitialDirectory = folder;
            WMPLib.IWMPMedia media;

            if (musicFolder.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in musicFolder.FileNames)
                {
                    media = mediaPlayer.newMedia(file);
                    playlist.appendItem(media);
                }
            }
            mediaPlayer.currentPlaylist = playlist;
            mediaPlayer.Ctlcontrols.stop();
        }

        public void PlayMusic()
        {
            mediaPlayer.Ctlcontrols.play();
        }
        
        public void PauseMusic()
        {
            mediaPlayer.Ctlcontrols.pause();
        }

        public void PlaceMusic()
        {
            int my = 0;

            foreach (Config conf in c)
            {
                if (conf.Pos.Y > my)
                    my = conf.Pos.Y;
            }

            my += 210;

            pMusic.Location = new Point(10, my);
            kontrolPanel.Controls.Add(pMusic);
            pMusic.Visible = true;
        }

        #endregion

        #region Button and menu handlers
        private void ButtonPressed(object sender, EventArgs e)
        {
            Button b = sender as Button;
            MenuClicked(b.Text);
        }

        private void MenuClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem b = sender as ToolStripMenuItem;
            MenuClicked(b.Text);
        }
        #endregion

    }
}
