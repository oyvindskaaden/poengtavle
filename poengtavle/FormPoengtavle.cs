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
    public partial class FormPoengtavle : Form
    {
        public FormPoengtavle()
        {
            InitializeComponent();
        }

        private void FormPoengtavleClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void CenterOnXY()
        {
            this.MinimumSize = poengPanel.Size;
            poengPanel.Location = new Point((this.Width / 2) - (poengPanel.Width / 2), (this.Height / 2) - (poengPanel.Height / 2));
        }

        private void MovePanel(object sender, EventArgs e)
        {
            CenterOnXY();
        }

        private void MovePanelPanel(object sender, ControlEventArgs e)
        {
            CenterOnXY();
        }
    }
}
