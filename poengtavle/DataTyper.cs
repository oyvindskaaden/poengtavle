﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace poengtavle
{
    class DataTyper
    {
        public DataTyper() { }

        public void CenterOnXY(Control c, Point p)
        {
            c.Location = new Point(p.X - (c.Width / 2), p.Y - (c.Height / 2));
        }
    }

    class Klokke : DataTyper
    {
        #region Variabler

        int interval;
        int totalTime;
        int curTime;

        bool countUp = true;
        bool decimalPlace;

        Point pos;
        int width = 200;
        int height = 200;

        #endregion

        public Klokke(Config config, Form formKontroll, List<Form> formPoeng)
        {
            pos = config.Pos;
            totalTime = Convert.ToInt32(config.Info[0]) * 1000;
            interval = Convert.ToInt32(config.Info[1]);
            if (interval < 1000)
                decimalPlace = true;
            countUp = Convert.ToBoolean(config.Info[2]);
            if (!countUp)
                curTime = totalTime;

            DecleareControls(config);
            AddControls(formKontroll, formPoeng);
        }

        #region Objekter

        Panel pKontrol = new Panel();
        Panel pPoeng = new Panel();

        Timer timer = new Timer();

        Label lVisning = new Label();
        Label lVisningKontrol = new Label();

        Button bStart = new Button();
        Button bStop = new Button();
        Button bNullstill = new Button();
        CheckBox isCountDown = new CheckBox();

        #region Panel med nedtelling
        Panel pNedtell = new Panel();
        NumericUpDown minutter = new NumericUpDown();
        NumericUpDown sekunder = new NumericUpDown();
        Label lMinutter = new Label();
        Label lSekunder = new Label();
        #endregion

        #endregion


        private void DecleareControls(Config config)
        {
            pNedtell.Controls.Add(minutter);
            pNedtell.Controls.Add(sekunder);
            pNedtell.Controls.Add(lMinutter);
            pNedtell.Controls.Add(lSekunder);

            pKontrol.Controls.Add(lVisningKontrol);
            pKontrol.Controls.Add(bStart);
            pKontrol.Controls.Add(bStop);
            pKontrol.Controls.Add(bNullstill);
            pKontrol.Controls.Add(isCountDown);
            pKontrol.Controls.Add(pNedtell);

            pPoeng.Controls.Add(lVisning);

            pKontrol.Location = pos;
            pKontrol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pKontrol.Size = new Size(width, height);

            pPoeng.Location = pos;
            pPoeng.Size = new Size(width, height);

            #region Panel for nedtelling

            pNedtell.Location = new Point(16, 94);
            pNedtell.Size = new Size(150, 53);
            pNedtell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pNedtell.Visible = true;

            minutter.Location = new Point(15, 27);
            minutter.Size = new Size(44, 20);
            minutter.Maximum = 300;
            minutter.Value = (totalTime / 1000) / 60;

            sekunder.Location = new Point(65, 27);
            sekunder.Size = new Size(44, 20);
            sekunder.Maximum = 59;
            sekunder.Value = (totalTime / 1000) % 60;

            lMinutter.Location = new Point(14, 11);
            lMinutter.Text = "Minutter";

            lSekunder.Location = new Point(64, 11);
            lSekunder.Text = "Sekunder";
            lSekunder.Size = new Size(53, 13);
            lSekunder.AutoSize = true;

            #endregion

            #region PoengPanel

            lVisning.Font = new System.Drawing.Font("Arial Black", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lVisning.AutoSize = true;
            lVisning.Text = GetTime(curTime);
            CenterOnXY(lVisning, new Point(width / 2, height / 2));


            #endregion




        }

        private void AddControls(Form formKontrol, List<Form> formPoeng)
        {
            formKontrol.Controls.Add(pKontrol);

            foreach(Form f in formPoeng)
            {
                f.Controls.Add(pPoeng);
            }
        }

        private string GetTime(int time)
        {
            int min = 0;
            int sek = 0;
            int dec = 0;

            string sMin = "";
            string sSek = "";
            string sDec = "";

            string s = "";
            string t = Convert.ToString(time);

            string[] tall = new string[2];

            decimal totaltime = time / 1000;

            min = (int)totaltime / 60;
            sek = (int)totaltime % 60;
            if (decimalPlace)
            {
                dec = (int)((time - (min * 60 * 1000) - (sek * 1000)) / 100);
                sDec = Convert.ToString(dec);
            }


            if (min < 10)
                sMin += "0";
            if (sek < 10)
                sSek += "0";

            sMin += Convert.ToString(min);
            sSek += Convert.ToString(sek);

            s = sMin + ":" + sSek;

            if (decimalPlace)
            {
                s += "." + sDec;
            }
            
            return s;
        }
    }

    class Perioder : DataTyper
    {

    }

    class Poeng : DataTyper
    {

        string navn;
        int poeng = 0;
        int inc;
        Point pos;

        int width = 220;
        int height = 200;

        Panel pKontrol = new Panel();
        Panel pPoeng = new Panel();

        Label nameField = new Label();
        Label sum = new Label();

        Label title = new Label();
        Label nameTitle = new Label();
        Label lKontolPoint = new Label();

        TextBox nameText = new TextBox();
        Button bSubName = new Button();

        Label incTitle = new Label();
        NumericUpDown increment = new NumericUpDown();

        Button bInc = new Button();
        Button bDinc = new Button();

        string buttonInc = "Poeng opp";
        string buttonDinc = "Poeng ned";

        public Poeng(Config config, Form formKontrol, List<Form> formPoeng)
        {
            navn = config.Info[0];
            inc = Convert.ToInt32(config.Info[1]);
            pos = config.Pos;

            DeclareControls(config);
            AddControls(formKontrol, formPoeng);

        }

        private void DeclareControls(Config config)
        {
            pPoeng.Controls.Add(nameField);
            pPoeng.Controls.Add(sum);

            pKontrol.Controls.Add(title);
            pKontrol.Controls.Add(lKontolPoint);
            pKontrol.Controls.Add(bInc);
            pKontrol.Controls.Add(bDinc);
            pKontrol.Controls.Add(nameTitle);
            pKontrol.Controls.Add(nameText);
            pKontrol.Controls.Add(bSubName);
            pKontrol.Controls.Add(incTitle);
            pKontrol.Controls.Add(increment);

            pKontrol.Size = new Size(width, height);
            pKontrol.Location = pos;
            pKontrol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pPoeng.Size = new Size(width, height);
            pPoeng.Location = pos;

            title.Text = "Kontroll for " + navn;
            title.AutoSize = true;
            CenterOnXY(title, new Point(width / 2, 12));

            lKontolPoint.Text = "Poengsum: " + poeng;
            CenterOnXY(lKontolPoint, new Point(width / 2, 35));

            bInc.Text = buttonInc;
            bInc.Location = new Point(123, height / 4);

            bDinc.Text = buttonDinc;
            bDinc.Location = new Point(23, height / 4);

            nameTitle.Text = "Navn på lag/spiller";
            nameTitle.Location = new Point(7, 86);

            nameText.Location = new Point(7, 115);
            nameText.Text = navn;
            nameText.Size = new Size(130, 20);

            bSubName.Location = new Point(139, 113);
            bSubName.Text = "Endre navn";

            incTitle.Location = new Point(7, 140);
            incTitle.Text = "Poengøkning:";

            increment.Location = new Point(7, 166);
            increment.Value = inc;
            increment.ReadOnly = true;

            // Objekter for selve poengtavla
            // Navn på Lag/Spiller
            nameField.Text = navn;
            nameField.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nameField.MaximumSize = new Size((width / 4) * 3, 0);
            nameField.AutoEllipsis = true;
            nameField.AutoSize = true;
            CenterOnXY(nameField, new Point(width / 2, height / 8));

            // Poengsum
            sum.Text = Convert.ToString(poeng);
            sum.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sum.MaximumSize = new Size((width / 4) * 3, 0);
            //sum.AutoEllipsis = true;
            sum.AutoSize = true;
            CenterOnXY(sum, new Point(width / 2, (height / 2)));
        }

        private void IncChanged(Object sender, EventArgs e)
        {
            inc = (int)increment.Value;
        }

        private void ButtonPress(Object sender, EventArgs e)
        {
            Button b = sender as Button;

            if (b.Text == buttonInc)
                poeng += inc;
            else if (b.Text == buttonDinc && poeng >= inc)
                poeng -= inc;
            else if (b.Text == "Endre navn")
            {
                navn = nameText.Text;
                title.Text = "Kontroll for " + navn;
                CenterOnXY(title, new Point(width / 2, 12));
                nameField.Text = navn;
                CenterOnXY(nameField, new Point(width / 2, height / 8));
            }

            sum.Text = Convert.ToString(poeng);
            CenterOnXY(sum, new Point(width / 2, (height / 2)));
            lKontolPoint.Text = "Poengsum: " + poeng;
            CenterOnXY(lKontolPoint, new Point(width / 2, 35));
        }

        private void AddControls(Form formKontrol, List<Form> formPoeng)
        {
            bInc.Click += new EventHandler(ButtonPress);
            bDinc.Click += new EventHandler(ButtonPress);
            bSubName.Click += new EventHandler(ButtonPress);

            increment.ValueChanged += new EventHandler(IncChanged);

            formKontrol.Controls.Add(pKontrol);

            foreach(Form f in formPoeng)
            {
                f.Controls.Add(pPoeng);
            }
        }

        public Config GetConfig()
        {
            return new Config("Poeng", pos, new string[] { navn, Convert.ToString(inc) });
        }

    }

    class Reklame : DataTyper
    {

    }

    class Utvisninger
    {

    }
}