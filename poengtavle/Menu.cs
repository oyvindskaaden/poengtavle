using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace poengtavle
{
    class Meny
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<String> ReadCSV(string path)
        {
            List<String> s = new List<String>();
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        String r = sr.ReadLine();
                        s.Add(r);
                    }
                }
            }
            return s;
        }

        public void WriteCSV(List<string> list, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach(string s in list)
                {
                    sw.WriteLine(s);
                }
            }
        }

        public void WriteLineCSV(string line, string path)
        {
            if (!File.Exists(path))
                File.Create(path);

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(line);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public JObject ReadJSON(string path)
        {
            string json = File.ReadAllText(path);
            JObject j = JObject.Parse(json);
            return j;
        }

        public List<Config> ReadJSONtoObject(string path)
        {
            string json = File.ReadAllText(path);
            List<Config> c = JsonConvert.DeserializeObject<List<Config>>(json);
            return c;
        }

        public void WriteJSON(List<object> o, string path)
        {
            if (!File.Exists(path))
                File.Create(path);
            
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (object s in o)
                {
                    string r = JsonConvert.SerializeObject(s, Formatting.Indented);
                    sw.WriteLine(r);
                }
            }
        }
    }
}
