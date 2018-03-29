using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void FormControl_Load(object sender, EventArgs e)
        {
            c.Add(new Config("PictureBox", new Point(2, 2), new string[] { "Test", "Test2" }));
            c.Add(new Config("TextBox", new Point(1, 0), new string[] { "Test1_0", "Test1_1", "Test1_2" }));
        }

        private void MenuClicked(object sender, EventArgs e)
        {
            Button b = sender as Button;

            switch (b.Text)
            {
                case "Ny":
                case "Poengtavle":
                    lf.WriteJSON(c, System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\test.json");
                    break;
                case "Fra mal":
                    break;
                case "Mal":
                case "Ny mal":
                    break;
                case "Lagre":
                    break;
                case "Åpne":
                    break;
                case "Start":
                    break;                
            }

        }
    }
}
