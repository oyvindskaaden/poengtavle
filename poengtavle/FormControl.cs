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

        List<Form> formPoeng = new List<Form>();
        List<DataTyper> controlList = new List<DataTyper>();

        

        

        private void FormControl_Load(object sender, EventArgs e)
        {
            formPoeng.Add(new FormPoengtavle());

            mediaPlayer.URL = (System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Pegboard Nerds.mp3");
            
            c.Add(new Config("Poeng", new Point(10, 34), new string[] { "Testlag1", "1"}));
            c.Add(new Config("Poeng", new Point(450, 34), new string[] { "Testlag2", "1"}));
            c.Add(new Config("Klokke", new Point(240, 34), new string[] { "5400", "100", "false" }));
            c.Add(new Config("Poeng", new Point(10, 244), new string[] { "testLag3", "2" }));
            c.Add(new Config("Poeng", new Point(450, 244), new string[] { "testLag4", "2" }));
            c.Add(new Config("Klokke", new Point(240, 244), new string[] { "0", "1000", "false" }));
            
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
                    CreatePoengtavle(c);
                    formPoeng[0].Show();
                    pMenu.Visible = false;
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
                }
            }
        }

        public void PlayMusic()
        {
            mediaPlayer.Ctlcontrols.play();
        }
        
        public void PauseMusic()
        {
            mediaPlayer.Ctlcontrols.pause();
        }

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
