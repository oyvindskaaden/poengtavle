using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace poengtavle
{
    class Klokke
    {

        #region Variabler og objekter
        private Timer time = new Timer();
        private Panel pPoeng = new Panel();
        private Panel pKontroll = new Panel();

        private Label lPoeng = new Label();
        private Label lKontrol = new Label();

        int height = 50;
        int width = 100;

        bool countUp;
        int totalTime;
        int periods;

        bool isRunning = false;

        #endregion

        public Klokke(Config config)
        {
            time.Tick += new System.EventHandler(Sekund);
            p.Location = config.Pos;

            totalTime = Convert.ToInt32(config.Info[0]);
            countUp = Convert.ToBoolean(config.Info[1]);
            time.Interval = Convert.ToInt32(config.Info[2]);
            if (config.Info[3] != "")
                periods = Convert.ToInt32(config.Info[3]);

            pPoeng.Controls.Add(lPoeng);
            lPoeng.Anchor = AnchorStyles.None;
            lPoeng.Location = new Point(height / 2, width / 2);

            poengtavle.FormControl.

        }

        public void Sekund(Object clock, EventArgs args)
        {

        }

        public void ToggleTick()
        {
            if (isRunning)
            {
                isRunning = false;
                time.Stop();
            }
            else
            {
                isRunning = true;
                time.Start();
            }
        }

        public bool Running
        {
            get { return isRunning; }
            set { isRunning = value; Enable(); }
        }

        private void Enable()
        {
            if (isRunning)
                time.Start();
            else
                time.Stop();
        }




    }

    class Perioder
    {

    }

    class Poeng
    {

    }

    class PoengNavn
    {

    }

    class Periode
    {

    }

    class Utvisninger
    {

    }
}