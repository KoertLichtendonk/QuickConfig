using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickConfig
{
    public interface IConfig
    {
        public string configPath { get; set; }

        void SaveDefault()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);

            using (StreamWriter sw = new StreamWriter(configPath, false))
            {
                sw.Write(json);
                sw.Close();
            }
        }
    }
}
