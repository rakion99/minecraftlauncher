using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using FreeLauncher.Forms;
using Telerik.WinControls;

namespace FreeLauncher
{
    internal static class Program
    {
        static Form SplashScreen;
        static Form MainForm;
        [STAThread]
        public static void Main(string[] args)
        {
            ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RadMessageBox.SetThemeName("VisualStudio2012Dark");//For some reason dont work here outside a form
            VersionCheck(args);
        }

        private static readonly XmlDocument XmlUpdateFileDoc = new XmlDocument();

        public static bool UpdateLauncher = false;
        private static Configuration _configuration;
        private static bool langen_UK = false;
        private static bool langes_MX = false;
        public static bool Updaterlangen_uk = false;
        public static bool Langnotfound = false;
        public static string UpdateLang = null;

        public static string XmlGetSingleNode(string nodelocation) => XmlUpdateFileDoc.DocumentElement.SelectSingleNode(nodelocation).InnerText;

        public static bool CheckForInternetConnection
        {
            get
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        using (client.OpenRead("http://clients3.google.com/generate_204"))
                        {
                            return true;
                        }
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        public static string WindowsCurrentUILang
        {
            get
            {
                if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en")
                {
                    return "en";
                }
                if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "es")
                {
                    return "es";
                }
                return "en";
            }
        }

        private static void VersionCheck(string[] args)
        {
            Configuration configuration = new Configuration(args);
            _configuration = configuration;
            ApplicationConfiguration _cfg = _configuration.ApplicationConfiguration;
            ApplicationLocalization localization = _configuration.Localization;
            string Updatefoundtext = localization.Updatefound;
            string Updateinfotext = localization.UpdateInfo;
            string Updatelangtext = localization.UpdateLang;
            ServicePointManager.Expect100Continue = true;//win7 fix
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;//win7 fix
            using (WebClient client = new WebClient())
            {
                client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                XmlUpdateFileDoc.LoadXml(client.DownloadString("https://raw.githubusercontent.com/rakion99/minecraftlauncher/gh-pages/Updater.xml"));//for some reason if i use https://rakion99.github.io/minecraftlauncher/Updater.xml takes ages to get the file
            }

            if ((WindowsCurrentUILang == "en" && !File.Exists("./Launcher-langs/en_UK.json"))
                || (_configuration.ApplicationConfiguration.SelectedLanguage == "en_UK" && !File.Exists("./Launcher-langs/en_UK.json")))
            {
                UpdateLang = "en_UK";
                Langnotfound = true;
                new Forms.UpdateForm.UpdaterForm().ShowDialog();
            }

            if ((WindowsCurrentUILang == "es" && !File.Exists("./Launcher-langs/es_MX.json"))
                || (_configuration.ApplicationConfiguration.SelectedLanguage == "es_MX" && !File.Exists("./Launcher-langs/es_MX.json")))
            {
                UpdateLang = "es_MX";
                Langnotfound = true;
                new Forms.UpdateForm.UpdaterForm().ShowDialog();
            }

            if (File.Exists("./Launcher-langs/en_UK.json"))
            {
                langen_UK = true;
            }

            if (File.Exists("./Launcher-langs/es_MX.json"))
            {
                langes_MX = true;
            }


            if (!_configuration.Arguments.OfflineMode)
            {
                _configuration.Arguments.OfflineMode = !CheckForInternetConnection;
            }

            if (_cfg.CheckforLauncherUpdates && !_configuration.Arguments.OfflineMode)
            {
                try
                {
                    string UICurrentVerion = Application.ProductVersion;
                    string LauncherXmlVersion = XmlGetSingleNode("/Launcher/version");
                    if (LauncherXmlVersion != UICurrentVerion)
                    {
                        string UIUpdateFound = string.Format(Updateinfotext, UICurrentVerion, LauncherXmlVersion);
                        DialogResult UIUpdaterChecker = RadMessageBox.Show(UIUpdateFound, Updatefoundtext, MessageBoxButtons.YesNo, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                        if (UIUpdaterChecker == DialogResult.Yes)
                        {
                            UpdateLauncher = true;
                            new Forms.UpdateForm.UpdaterForm().ShowDialog();
                        }
                    }

                    if (langen_UK)
                    {
                        string localen_UKSHA384 = GetSHA384("./Launcher-langs/en_UK.json");
                        if (XmlGetSingleNode("/Launcher/Languages/en_UK/SHA384") != localen_UKSHA384)
                        {
                            string Updatelangen_UK = string.Format(Updatelangtext, "en_UK");
                            DialogResult DLLUpdaterChecker = MessageBox.Show(Updatelangen_UK, Updatefoundtext, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            if (DLLUpdaterChecker == DialogResult.Yes)
                            {
                                UpdateLang = "en_UK";
                                new Forms.UpdateForm.UpdaterForm().ShowDialog();
                            }
                        }
                    }
                    if (langes_MX)
                    {
                        string locales_MXSHA384 = GetSHA384("./Launcher-langs/es_MX.json");
                        if (XmlGetSingleNode("/Launcher/Languages/es_MX/SHA384") != locales_MXSHA384)
                        {
                            string Updatelanges_MX = string.Format(Updatelangtext, "es_MX");
                            DialogResult DLLUpdaterChecker = MessageBox.Show(Updatelanges_MX, Updatefoundtext, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            if (DLLUpdaterChecker == DialogResult.Yes)
                            {
                                UpdateLang = "es_MX";
                                new Forms.UpdateForm.UpdaterForm().ShowDialog();
                            }
                        }
                    }
                }
                catch (WebException wex)
                {
                    if (wex.Status == WebExceptionStatus.ProtocolError)
                    {
                        if (((HttpWebResponse)wex.Response).StatusCode == HttpStatusCode.NotFound)
                        {
                            MessageBox.Show("Something happened and updater got error 404", "Update Checker Web 404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (wex.Response == null)
                    {
                        MessageBox.Show("Can't connect because the update server is down, you dont have an internet connection or something is blocking it", "Update Checker Can't connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"{wex.Message.ToString()}", "Update Checker Web Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message.ToString()}\n{ex.StackTrace}", "Update Checker Fatal Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Thanks stackoverflow: https://stackoverflow.com/a/32421479
            SplashScreen = new Forms.Splash.SplashForm();
            var splashThread = new System.Threading.Thread(new System.Threading.ThreadStart(
                () => Application.Run(SplashScreen)));
            splashThread.SetApartmentState(System.Threading.ApartmentState.STA);
            splashThread.Start();
            MainForm = new LauncherForm(configuration);
            MainForm.Load += MainForm_LoadCompleted;
            Application.Run(MainForm);

            configuration.SaveConfiguration();
        }

        private static void MainForm_LoadCompleted(object sender, EventArgs e)
        {
            if (SplashScreen != null && !SplashScreen.Disposing && !SplashScreen.IsDisposed)
                SplashScreen.Invoke(new Action(() => SplashScreen.Close()));
            MainForm.TopMost = true;
            MainForm.Activate();
            MainForm.TopMost = false;
        }

        private static string GetSHA384(string filepath)
        {
            FileStream filestream = new FileStream(filepath, FileMode.Open)
            {
                Position = 0
            };
            var filehash = BitConverter.ToString(System.Security.Cryptography.SHA384.Create().ComputeHash(filestream)).Replace("-", string.Empty);
            filestream.Close();
            return filehash;
        }
    }
}
