using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CommandLine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FreeLauncher
{
    public class Configuration
    {
        private readonly string _configurationFile;

        public ApplicationArguments Arguments { get; private set; }

        public ApplicationLocalization Localization { get; private set; }
        public Dictionary<string, ApplicationLocalization> LocalizationsList { get; }

        public string McDirectory { get; }
        public string McLauncher { get; }
        public string McVersions { get; }
        public string McLibs { get; }

        public ApplicationConfiguration ApplicationConfiguration { get; }

        public Configuration(IEnumerable<string> args)
        {
            Arguments = new ApplicationArguments();
            Localization = new ApplicationLocalization();
            LocalizationsList = new Dictionary<string, ApplicationLocalization>();
            Parser.Default.ParseArguments<ApplicationArguments>(args).WithParsed(arguments => Arguments = arguments);
            McDirectory = Path.Combine(Application.StartupPath, ".minecraft");
            McLauncher = Path.Combine(McDirectory, "Launcher");
            McVersions = Path.Combine(McDirectory, "versions");
            McLibs = Path.Combine(McDirectory, "libraries");

            _configurationFile = McLauncher + @"\configuration.json";
            ApplicationConfiguration = GetConfiguration();
            LoadLocalization();
        }

        public void SetLocalization(string localizationName)
        {
            Localization = string.IsNullOrEmpty(localizationName) ? new ApplicationLocalization() : LocalizationsList[localizationName];
        }

        public void SaveConfiguration()
        {
            File.WriteAllText(_configurationFile, JsonConvert.SerializeObject(ApplicationConfiguration, Formatting.Indented));
        }

        private ApplicationConfiguration GetConfiguration()
        {
            return File.Exists(_configurationFile)
                ? JsonConvert.DeserializeObject<ApplicationConfiguration>(File.ReadAllText(_configurationFile))
                : new ApplicationConfiguration {
                    SelectedLanguage =
                        CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "es" ? "es_MX" : "en_UK"
                };
        }

        private void LoadLocalization()
        {
            var langsDirectory = new DirectoryInfo(Path.Combine(Application.StartupPath + @"\Launcher-langs\"));
            if (!langsDirectory.Exists) {
                return;
            }
            foreach (var local in langsDirectory
                .GetFiles("*.json", SearchOption.AllDirectories)
                .Select(file => JObject.Parse(File.ReadAllText(file.FullName)))
                .Select(jo => JsonConvert.DeserializeObject<ApplicationLocalization>(jo.ToString()))) {
                if (LocalizationsList.ContainsKey(local.LanguageTag)) {
                    continue;
                }
                LocalizationsList.Add(local.LanguageTag, local);
                if (local.LanguageTag == ApplicationConfiguration.SelectedLanguage) {
                    Localization = local;
                }
            }
        }
    }
}
