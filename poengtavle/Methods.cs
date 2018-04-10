using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace poengtavle
{
    class LoadFunc
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

        #region JSON
        /// <summary>
        /// Reads a JSON-file at desired path 
        /// </summary>
        /// <param name="path">Path for JSON-file</param>
        /// <returns></returns>
        public JObject ReadJSON(string path)
        {
            string json = File.ReadAllText(path);
            JObject j = JObject.Parse(json);
            return j;
        }

        /// <summary>
        /// Reads and parses a formatted JSON-file to the Config datatype
        /// </summary>
        /// <param name="path">Path for JSON-file</param>
        /// <returns></returns>
        public List<Config> ReadJSONtoObject(string path)
        {
            string json = File.ReadAllText(path);
            List<Config> c = JsonConvert.DeserializeObject<List<Config>>(json);
            return c;
        }

        /// <summary>
        /// Writes a formatted JSON-file from Config datatypes at specified path
        /// </summary>
        /// <param name="o">List of Config datatype</param>
        /// <param name="path">Path for writing the JSON-file to</param>
        public void WriteJSON(List<Config> o, string path)
        {
            
            File.Create(path).Close();

            string l = JsonConvert.SerializeObject(o, Formatting.Indented);

            using (StreamWriter sw = new StreamWriter(path)) { sw.WriteLine(l); }
        }
        #endregion
    }
}
