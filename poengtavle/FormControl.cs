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

        private void FormControl_Load(object sender, EventArgs e)
        {

        }

        private void MenuClicked(object sender, EventArgs e)
        {
            Button b = sender as Button;

            switch (b.Text)
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
                    break;
                case "Åpne":
                    break;
                case "Start":
                    break;                
            }

        }
    }
}
