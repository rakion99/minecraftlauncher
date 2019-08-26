using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
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

        public static bool UpdateLauncher = false;
        private static Configuration _configuration;
        private static bool langen_UK = false;
        public static bool Updaterlangen_uk = false;

        private static void VersionCheck(string[] args)
        {

            Configuration configuration = new Configuration(args);
            _configuration = configuration;
            ApplicationConfiguration _cfg = _configuration.ApplicationConfiguration;
            ApplicationLocalization localization = _configuration.Localization;
            string Updatefoundtext = localization.Updatefound;
            string Updateinfotext = localization.UpdateInfo;
            string Updatelangen_uk = localization.UpdateLangen_Uk;

            if (File.Exists("./Launcher-langs/en_UK/lang.json"))
            {
                langen_UK = true;
            }

            if (_cfg.CheckLauncherUpdates)
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                        string UIWebVersion = client.DownloadString("https://rakion99.github.io/minecraftlauncher/Version.txt");
                        string UICurrentVerion = Application.ProductVersion;
                        UIWebVersion = Regex.Replace(UIWebVersion, @"\s+", string.Empty);
                        UIWebVersion = Regex.Replace(UIWebVersion, @"\n", string.Empty);
                        if (UIWebVersion != UICurrentVerion)
                        {
                            string UIUpdateFound = string.Format(Updateinfotext, UICurrentVerion, UIWebVersion);
                            DialogResult UIUpdaterChecker = MessageBox.Show(UIUpdateFound, Updatefoundtext, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            if (UIUpdaterChecker == DialogResult.Yes)
                            {
                                UpdateLauncher = true;
                                new Forms.UpdateForm.UpdaterForm().ShowDialog();
                            }
                        }

                        if (langen_UK)
                        {
                            string Langen_UKCurrent = Getsha256("./Launcher-langs/en_UK/lang.json");
                            string Langen_Ukwebhash = client.DownloadString("http://rakion99.github.io/minecraftlauncher/langen_ukhash.txt");
                            if (Langen_Ukwebhash != Langen_UKCurrent)
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

        private static string Getsha256(string filepath)
        {
            FileStream filestream;
            filestream = new FileStream(filepath, FileMode.Open)
            {
                Position = 0
            };

            return BitConverter.ToString(System.Security.Cryptography.SHA256.Create().ComputeHash(filestream)).Replace("-", string.Empty);
        }
    }
}
