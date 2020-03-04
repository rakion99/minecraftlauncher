using System;
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
        [STAThread]
        public static void Main(string[] args)
        {
            ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            VersionCheck(args);
        }

        private static readonly XmlDocument XmlUpdateFileDoc = new XmlDocument();

        public static bool UpdateLauncher = false;
        private static Configuration _configuration;
        private static bool langen_UK = false;
        public static bool Updaterlangen_uk = false;

        public static string XmlGetSingleNode(string nodelocation) => XmlUpdateFileDoc.DocumentElement.SelectSingleNode(nodelocation).InnerText;

        private static void VersionCheck(string[] args)
        {
            Configuration configuration = new Configuration(args);
            _configuration = configuration;
            ApplicationConfiguration _cfg = _configuration.ApplicationConfiguration;
            ApplicationLocalization localization = _configuration.Localization;
            string Updatefoundtext = localization.Updatefound;
            string Updateinfotext = localization.UpdateInfo;
            string Updatelangen_uk = localization.UpdateLangen_Uk;

            if (File.Exists("./Launcher-langs/en_UK.json"))
            {
                langen_UK = true;
            }

            if (_cfg.CheckforLauncherUpdates)
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                        XmlUpdateFileDoc.LoadXml(client.DownloadString("https://rakion99.github.io/minecraftlauncher/Updater.xml"));
                        string UICurrentVerion = Application.ProductVersion;
                        string LauncherXmlVersion = XmlGetSingleNode("/Launcher/version");
                        if (LauncherXmlVersion != UICurrentVerion)
                        {
                            string UIUpdateFound = string.Format(Updateinfotext, UICurrentVerion, LauncherXmlVersion);
                            DialogResult UIUpdaterChecker = MessageBox.Show(UIUpdateFound, Updatefoundtext, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            if (UIUpdaterChecker == DialogResult.Yes)
                            {
                                UpdateLauncher = true;
                                new Forms.UpdateForm.UpdaterForm().ShowDialog();
                            }
                        }

                        if (langen_UK)
                        {
                            string en_UKCurrent = GetSHA384("./Launcher-langs/en_UK.json");
                            if (XmlGetSingleNode("/Launcher/Languages/en_UK/SHA384") != en_UKCurrent)
                            {
                                DialogResult DLLUpdaterChecker = MessageBox.Show(Updatelangen_uk, Updatefoundtext, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                                if (DLLUpdaterChecker == DialogResult.Yes)
                                {
                                    Updaterlangen_uk = true;
                                    new Forms.UpdateForm.UpdaterForm().ShowDialog();
                                }
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
            Application.Run(new LauncherForm(configuration));
            configuration.SaveConfiguration();
        }

        private static string GetSHA384(string filepath)
        {
            FileStream filestream = new FileStream(filepath, FileMode.Open)
            {
                Position = 0
            };

            return BitConverter.ToString(System.Security.Cryptography.SHA384.Create().ComputeHash(filestream)).Replace("-", string.Empty);
        }
    }
}
