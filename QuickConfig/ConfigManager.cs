using Newtonsoft.Json;
using System.Buffers;
using System.IO;

namespace QuickConfig
{
    public class ConfigManager
    {
        private string projectName { get; set; }
        private Dictionary<string, object> configs { get; set; }

        public ConfigManager(string projectName)
        {
            this.projectName = projectName;
            this.configs = new Dictionary<string, object>();
        }

        public T GetConfig<T>(string configName) where T : IConfig, new()
        {
            if(configs.TryGetValue(configName, out object savedConfig))
            {
                if(savedConfig is T)
                {
                    return (T)savedConfig;
                }
            }

            string dirPath = String.Format("{0}{1}{2}", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), Path.DirectorySeparatorChar, projectName);

            if (!(Directory.Exists(dirPath)))
            {
                Directory.CreateDirectory(dirPath);
            }

            string configPath = String.Format("{0}{1}{2}.json", dirPath, Path.DirectorySeparatorChar, configName);

            T configData;
            if (!(File.Exists(configPath)))
            {
                using (StreamWriter sw = File.CreateText(configPath))
                {
                    configData = new T();

                    string configJson = JsonConvert.SerializeObject(configData, Formatting.Indented);

                    sw.Write(configJson);
                    sw.Close();
                }
            }

            string config = File.ReadAllText(configPath);

            configData = JsonConvert.DeserializeObject<T>(config);
            configData.configPath = configPath;

            configs.Add(configName, configData);

            return configData;
        }
    }
}