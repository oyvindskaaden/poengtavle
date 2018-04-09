using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace poengtavle
{
    class Config
    {

        String type;
        Point pos;
        String[] info;

        public Config(String t, Point p, string[] st)
        {
            type = t;
            pos = p;
            info = st;
        }

        public String ConfType
        {
            get { return type; }
            set { type = value; }
        }

        public Point Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public String[] Info
        {
            get { return info; }
            set { info = value; }
        }

    }
}
