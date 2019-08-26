using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace FreeLauncher.Forms.UpdateForm
{
    public partial class UpdaterForm : RadForm
    {
        public UpdaterForm()
        {
            InitializeComponent();
            DownloadProgressbar.ProgressBarElement.IndicatorElement1.BackColor = Color.Lime;
            DownloadLauncherUpdate();
        }

        private async void DownloadLauncherUpdate()
        {
            try
            {
                if (Program.UpdateLauncher)
                {
                    using (WebClient WebC = new WebClient())
                    {
                        DownloadingLabel.Text = "Downloading Launcher Update";
                        Directory.CreateDirectory("tmp");
                        WebC.DownloadProgressChanged += WebC_DownloadProgressChanged;
                        WebC.DownloadDataCompleted += new DownloadDataCompletedEventHandler(WebC_DownloadUICompleted);
                        string ExeDownloadLocation = WebC.DownloadString("https://rakion99.github.io/minecraftlauncher/DownloadLocation.txt");
                        var data = await WebC.DownloadDataTaskAsync(new Uri(ExeDownloadLocation));
                        File.WriteAllBytes(@".\tmp\Launcher.exe", data);
                    }
                }
                else if (Program.Updaterlangen_uk)
                {
                    using (WebClient WebC2 = new WebClient())
                    {
                        DownloadingLabel.Text = "Downloading en_UK Lang Update";
                        Directory.CreateDirectory(@"tmp\Launcher-langs\en_UK");
                        WebC2.DownloadProgressChanged += WebC_DownloadProgressChanged;
                        WebC2.DownloadDataCompleted += new DownloadDataCompletedEventHandler(WebC_DownloadlangCompleted);
                        string en_ukDownloadLocation = WebC2.DownloadString("http://rakion99.github.io/minecraftlauncher/en_ukLocation.txt");
                        var data = await WebC2.DownloadDataTaskAsync(new Uri(en_ukDownloadLocation));
                        File.WriteAllBytes(@".\tmp\Launcher-langs\en_UK\lang.json", data);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void WebC_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) => DownloadProgressbar.Value1 = e.ProgressPercentage;

        private void WebC_DownloadUICompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                MessageBox.Show("Download complete\nUpdater will close and Launcher will run", "Download complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new Thread(() =>
                {
                    Process.Start("cmd.exe",
                    "/C timeout /T 1 & Del " + Application.ExecutablePath + @"& MOVE /Y .\tmp\Launcher.exe .\ & rmdir .\tmp & start Launcher.exe");
                    Environment.Exit(0);
                }).Start();
            }
        }

        private void WebC_DownloadlangCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {

                MessageBox.Show("Download Completed\nUpdater will close and Launcher will run", "Download Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new Thread(() =>
                {
                    try
                    {
                        if (Directory.Exists(@".\Launcher-langs"))
                        {
                            Thread.Sleep(100);
                            File.Delete(@".\Launcher-langs\en_UK\lang.json");
                            File.Move(@".\tmp\Launcher-langs\en_UK\lang.json", @".\Launcher-langs\en_UK\lang.json");
                            Directory.Delete(@".\tmp", true);
                        }
                        else
                        {
                            Directory.Move(@".\tmp\Launcher-langs", @".\");
                            Directory.Delete(@".\tmp");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message.ToString()}\n{ex.StackTrace}", "Updater Fatal Exception while trying to update lang", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Invoke((MethodInvoker)delegate
                    {
                        Close();
                    });
                }).Start();
            }
        }
    }
}
