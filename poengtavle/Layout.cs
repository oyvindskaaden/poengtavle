using System.Windows.Forms;
using System.Drawing;

namespace poengtavle
{
    class Layout : Panel
    {
        #region Variabler
        string type;
        int number;

        private Point MouseDownLocation;

        #endregion

        public Layout() { }

        public Layout(FormControl form, string t, int n)
        {
            type = t;
            number = n;
            DeclareControls(GetSize(t));
            AddControls(form);
        }

        #region Objekter

        Label title = new Label();

        #endregion

        #region Adding and Declaring controls

        private void DeclareControls(Size s)
        {
            this.Controls.Add(title);

            this.Location = new Point(10 + number * 5, 10 + number * 5);
            this.Size = s;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = SystemColors.Control;
            this.MouseDown += new MouseEventHandler(Panel_MouseDown);
            this.MouseMove += new MouseEventHandler(Panel_MouseMove);

            title.Text = type;
            title.AutoSize = true;
            CenterOnXY(title, new Point(s.Width / 2, s.Height / 2));
        }

        private void AddControls(FormControl form)
        {
            form.configPanel.Controls.Add(this);
            this.BringToFront();
        }

        #endregion

        #region Eventhandlers

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
                this.BringToFront();
            }
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
                this.BringToFront();
            }
        }

        #endregion

        #region Private-metoder

        private Size GetSize(string t)
        {
            Size size = new Size();
            switch (t)
            {
                case "Klokke":
                    size = new Size(200, 200);
                    break;
                case "Poeng":
                case "Reklame":
                    size = new Size(220, 200);
                    break;
                case "Perioder":
                    size = new Size(100, 200);
                    break;
            }
            return size;
        }

        #endregion

        #region Public-metoder

        public void CenterOnXY(Control c, Point p)
        {
            c.Location = new Point(p.X - (c.Width / 2), p.Y - (c.Height / 2));
        }

        public Config GetConfig() { return new Config(type, this.Location, null); }

        #endregion

    }
}
