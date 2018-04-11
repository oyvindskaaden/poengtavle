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

        bool countDown = true;

        Point pos;
        int width = 200;
        int height = 200;

        FormControl form;

        #endregion

        public Klokke(Config config, FormControl formKontroll, List<Form> formPoeng)
        {
            form = formKontroll;
            pos = config.Pos;
            totalTime = Convert.ToInt32(config.Info[0]) * 1000;
            interval = Convert.ToInt32(config.Info[1]);
            countDown = Convert.ToBoolean(config.Info[2]);
            if (countDown)
                curTime = totalTime;


            DecleareControls(config);
            AddControls(formKontroll, formPoeng);
            CheckCount(new CheckBox() { Checked = countDown }, null);
        }

        #region Objekter

        Panel pKontrol = new Panel();
        Panel pPoeng = new Panel();

        Timer timer = new Timer();

        Label lVisning = new Label();
        Label lVisningKontrol = new Label();

        Button bStart = new Button();
        Button bNullstill = new Button();
        CheckBox isCountDown = new CheckBox();

        CheckBox isStopp = new CheckBox();

        Label lInter = new Label();
        NumericUpDown nudInterval = new NumericUpDown();

        CheckBox autoMusic = new CheckBox();

        #region Panel med nedtelling
        Panel pNedtell = new Panel();
        NumericUpDown minutter = new NumericUpDown();
        NumericUpDown sekunder = new NumericUpDown();
        Label lMinutter = new Label();
        Label lSekunder = new Label();
        #endregion

        #region Panel med nedtelling
        Panel pStopp = new Panel();
        NumericUpDown stoppMinutter = new NumericUpDown();
        NumericUpDown stoppSekunder = new NumericUpDown();
        Label lStoppMinutter = new Label();
        Label lStoppSekunder = new Label();
        #endregion

        #endregion

        private void DecleareControls(Config config)
        {
            pNedtell.Controls.Add(minutter);
            pNedtell.Controls.Add(sekunder);
            pNedtell.Controls.Add(lMinutter);
            pNedtell.Controls.Add(lSekunder);

            pStopp.Controls.Add(stoppMinutter);
            pStopp.Controls.Add(stoppSekunder);
            pStopp.Controls.Add(lStoppMinutter);
            pStopp.Controls.Add(lStoppSekunder);

            pKontrol.Controls.Add(lVisningKontrol);
            pKontrol.Controls.Add(bStart);
            pKontrol.Controls.Add(bNullstill);
            pKontrol.Controls.Add(lInter);
            pKontrol.Controls.Add(nudInterval);
            pKontrol.Controls.Add(isCountDown);
            pKontrol.Controls.Add(pNedtell);
            pKontrol.Controls.Add(isStopp);
            pKontrol.Controls.Add(pStopp);
            pKontrol.Controls.Add(autoMusic);

            pPoeng.Controls.Add(lVisning);

            pKontrol.Location = pos;
            pKontrol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pKontrol.Size = new Size(width, height);

            pPoeng.Location = pos;
            pPoeng.Size = new Size(width, height);

            timer.Tick += new EventHandler(Tick);

            #region PoengPanel

            lVisning.Font = new System.Drawing.Font("Arial Black", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lVisning.AutoSize = true;
            lVisning.Text = GetTime(curTime);
            CenterOnXY(lVisning, new Point(width / 2, height / 2));


            #endregion

            #region KontrolPanel

            lVisningKontrol.AutoSize = true;
            lVisningKontrol.Text = GetTime(curTime);
            CenterOnXY(lVisningKontrol, new Point(width / 2, 8));

            bStart.Location = new Point(16, 21);
            bStart.Text = "Start";
            bStart.Click += new EventHandler(ButtonPressed);

            bNullstill.Location = new Point(97, 21);
            bNullstill.Text = "Nullstill";
            bNullstill.Click += new EventHandler(ButtonPressed);

            lInter.Location = new Point(54, 48);
            lInter.AutoSize = true;
            lInter.Text = "Intervall i ms";

            nudInterval.Location = new Point(120,46);
            nudInterval.Minimum = 100;
            nudInterval.Increment = 100;
            nudInterval.Maximum = 1000;
            nudInterval.Size = new Size(51, 20);
            nudInterval.ReadOnly = true;
            nudInterval.ValueChanged += new EventHandler(ChangeInterval);

            isCountDown.Location = new Point(16, 63);
            isCountDown.Text = "Telle ned fra?";
            isCountDown.CheckedChanged += new EventHandler(CheckCount);

            isStopp.Location = new Point(16, 121);
            isStopp.Text = "Stoppe ved tid?";
            isStopp.CheckedChanged += new EventHandler(CheckStopp);

            autoMusic.Location = new Point(16, 179);
            autoMusic.AutoSize = true;
            autoMusic.Text = "Auto start/stopp musikk";

            #region Panel for nedtelling

            pNedtell.Location = new Point(16, 82);
            pNedtell.Size = new Size(150, 38);
            pNedtell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pNedtell.Visible = isCountDown.Checked;

            minutter.Location = new Point(15, 15);
            minutter.Size = new Size(44, 20);
            minutter.Maximum = 300;
            minutter.Value = (totalTime / 1000) / 60;
            minutter.ValueChanged += new EventHandler(ChangeTime);

            sekunder.Location = new Point(65, 15);
            sekunder.Size = new Size(44, 20);
            sekunder.Maximum = 59;
            sekunder.Value = (totalTime / 1000) % 60;
            sekunder.ValueChanged += new EventHandler(ChangeTime);

            lMinutter.Location = new Point(14, 3);
            lMinutter.Text = "Minutter";

            lSekunder.Location = new Point(64, 3);
            lSekunder.AutoSize = true;
            lSekunder.Text = "Sekunder";
            lSekunder.Size = new Size(53, 13);

            #endregion

            #region Panel for stopp ved tid

            pStopp.Location = new Point(16, 138);
            pStopp.Size = new Size(150, 38);
            pStopp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pStopp.Visible = isStopp.Checked;

            stoppMinutter.Location = new Point(15, 15);
            stoppMinutter.Size = new Size(44, 20);
            stoppMinutter.Maximum = 300;
            stoppMinutter.Value = 0;

            stoppSekunder.Location = new Point(65, 15);
            stoppSekunder.Size = new Size(44, 20);
            stoppSekunder.Maximum = 59;
            stoppSekunder.Value = 0;

            lStoppMinutter.Location = new Point(14, 3);
            lStoppMinutter.Text = "Minutter";

            lStoppSekunder.Location = new Point(64, 3);
            lStoppSekunder.AutoSize = true;
            lStoppSekunder.Text = "Sekunder";
            lStoppSekunder.Size = new Size(53, 13);


            #endregion

            #endregion

        }

        private void CheckStopp(Object sender, EventArgs e)
        {
            pStopp.Visible = isStopp.Checked;
        }

        private void ChangeInterval(Object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;

            timer.Interval = (int)nud.Value;

            PrintTime();
        }

        private void ChangeTime(Object sender, EventArgs e)
        {
            totalTime = (((int)minutter.Value * 60) + (int)sekunder.Value) * 1000;

            if (countDown)
                curTime = totalTime;
            
            ButtonPressed(new Button() { Text = "Nullstill" }, null);
        }

        private void CheckCount(Object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;

            pNedtell.Visible = c.Checked;

            if (!c.Checked)
                countDown = false;
            else
                countDown = true;

            ButtonPressed(new Button() { Text = "Nullstill" }, null);
        }

        private void ButtonPressed(Object sender, EventArgs e)
        {
            Button b = sender as Button;

            switch (b.Text)
            {
                case "Start":
                    timer.Start();
                    b.Text = "Stopp";
                    form.PauseMusic();
                    break;
                case "Stopp":
                    timer.Stop();
                    b.Text = "Start";
                    if (autoMusic.Checked)
                        form.PlayMusic();

                    break;
                case "Nullstill":
                    timer.Stop();

                    bStart.Text = "Start";

                    form.PauseMusic();

                    if (!countDown)
                        curTime = 0;
                    else
                        curTime = totalTime;

                    PrintTime();

                    break;
            }
        }

        private void Tick(Object sender, EventArgs e)
        {
            if (!countDown)
                curTime += timer.Interval;
            else
            {
                if (curTime > timer.Interval)
                    curTime -= timer.Interval;
            }

            PrintTime();
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
            string ms = "" + time;

            string s = "";

            int length = ms.Length;
            if (length > 3)
            {
                for (int i = 0; i < length - 3; i++)
                {
                    s += ms[0];
                    ms = ms.Substring(1);
                }
            }
            else if (length == 3)
            {
                s = "0";
                ms = Convert.ToString(ms[0]);
            }
            else
            {
                s = "0";
                ms = "0";
            }

            int sec = Convert.ToInt32(s);

            int min = sec / 60;
            sec = sec % 60;

            string m = "";
            s = "";

            if (min < 10)
                m += "0";
            if (sec < 10)
                s += "0";

            m += Convert.ToString(min);
            s += Convert.ToString(sec);

            s = m + ":" + s;

            if (timer.Interval < 1000)
                s += "." + ms[0];

            if (min == stoppMinutter.Value && sec == stoppSekunder.Value && Convert.ToInt32(ms) == 0 && isStopp.Checked)
                ButtonPressed(new Button() { Text = "Stopp" }, null);

            return s;
        }

        private void PrintTime()
        {
            lVisning.Text = GetTime(curTime);
            CenterOnXY(lVisning, new Point(width / 2, height / 2));
            lVisningKontrol.Text = GetTime(curTime);
            CenterOnXY(lVisningKontrol, new Point(width / 2, 8));
        }
    }

    class Perioder : DataTyper
    {
        int periode = 1;

        int width = 100;
        int height = 200;

        Point pos;

        public Perioder(Config config, FormControl formKontroll, List<Form> formPoeng)
        {

            pos = config.Pos;
            if (config.Info != null)
                periode = Convert.ToInt32(config.Info[0]);

            DeclareControls(config);
            AddControls(formKontroll, formPoeng);

        }

        #region Objekter

        Panel pKontrol = new Panel();
        Panel pPoeng = new Panel();

        Label lTitlePer = new Label();
        Label lPer = new Label();

        Label lPeriodeKontroll = new Label();
        Label lPeriode = new Label();

        Button bPerUp = new Button();
        Button bPerDown = new Button();

        #endregion

        private void DeclareControls(Config config)
        {
            pKontrol.Controls.Add(lPeriodeKontroll);
            pKontrol.Controls.Add(bPerUp);
            pKontrol.Controls.Add(lPeriode);
            pKontrol.Controls.Add(bPerDown);

            pPoeng.Controls.Add(lTitlePer);
            pPoeng.Controls.Add(lPer);

            pKontrol.Location = pos;
            pKontrol.Size = new Size(width, height);
            pKontrol.BorderStyle = BorderStyle.FixedSingle;

            pPoeng.Location = pos;
            pPoeng.Size = new Size(width, height);

            #region Tavle

            lTitlePer.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lTitlePer.AutoSize = true;
            lTitlePer.Text = "Periode";
            CenterOnXY(lTitlePer, new Point(width / 2, 50));

            lPer.Font = new System.Drawing.Font("Arial Black", 20.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lPer.AutoSize = true;
            lPer.Text = Convert.ToString(periode);
            CenterOnXY(lPer, new Point(width / 2, height / 2));

            #endregion

            #region Kontroll

            lPeriodeKontroll.AutoSize = true;
            lPeriodeKontroll.Text = "Periode";
            CenterOnXY(lPeriodeKontroll, new Point(width / 2, 10));

            bPerUp.Text = "Opp";
            CenterOnXY(bPerUp, new Point(width / 2, (height / 2) - 50));
            bPerUp.Click += new EventHandler(ButtonPressed);

            bPerDown.Text = "Ned";
            CenterOnXY(bPerDown, new Point(width / 2, (height / 2) + 50));
            bPerDown.Click += new EventHandler(ButtonPressed);

            lPeriode.Text = Convert.ToString(periode);
            lPeriode.AutoSize = true;
            lPeriode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CenterOnXY(lPeriode, new Point(width / 2, height / 2));

            #endregion

        }

        private void ButtonPressed(Object sender, EventArgs e)
        {
            Button b = sender as Button;

            switch (b.Text)
            {
                case "Opp":
                    periode++;
                    break;
                case "Ned":
                    if (periode > 1)
                        periode--;
                    break;
            }

            lPeriode.Text = Convert.ToString(periode);
            CenterOnXY(lPeriode, new Point(width / 2, height / 2));
            lPer.Text = Convert.ToString(periode);
            CenterOnXY(lPer, new Point(width / 2, height / 2));
        }

        private void AddControls(Form formKontrol, List<Form> formPoeng)
        {
            formKontrol.Controls.Add(pKontrol);

            foreach(Form f in formPoeng)
            {
                f.Controls.Add(pPoeng);
            }
        }

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