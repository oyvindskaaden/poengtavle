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

        FormPoengtavle FP = new FormPoengtavle();
        //FormPoengtavle Fp2 = new FormPoengtavle();

        LoadFunc lf = new LoadFunc();

        List<Form> formPoeng = new List<Form>();
        List<DataTyper> controlList = new List<DataTyper>();

        private void FormControl_Load(object sender, EventArgs e)
        {
            formPoeng.Add(FP);
            //formPoeng.Add(Fp2);
            c.Add(new Config("Poeng", new Point(10, 34), new string[] { "Testlag1", "1"}));
            c.Add(new Config("Poeng", new Point(240, 34), new string[] { "Testlag2", "1"}));
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
                    controlList.Add(new Poeng(c[0], this, formPoeng));
                    controlList.Add(new Poeng(c[1], this, formPoeng));
                    pMenu.Visible = false;
                    break;
                case "Mal":
                case "Ny mal":
                    break;
                case "Lagre":
                    break;
                case "Åpne":
                    formPoeng[0].Show();
                    //formPoeng[1].Show();
                    break;
                case "Start":
                    break;                
            }

        }
    }
}
