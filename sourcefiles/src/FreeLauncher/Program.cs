using System;
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

        private static System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CurrentCulture;

        public static bool UpdateLauncher = false;
        private static Configuration _configuration;

        private static void VersionCheck(string[] args)
        {

            Configuration configuration = new Configuration(args);
            _configuration = configuration;

            ApplicationLocalization localization = _configuration.Localization;
            string Updatefoundtext = localization.Updatefound;
            string Updateinfotext = localization.UpdateInfo;

            try
            {
                using (WebClient client = new WebClient())
                {
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
            Application.Run(new LauncherForm(configuration));
            configuration.SaveConfiguration();
        }
    }
}
