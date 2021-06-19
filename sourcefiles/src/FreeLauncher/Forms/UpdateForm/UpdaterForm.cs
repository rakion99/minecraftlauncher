﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace FreeLauncher.Forms.UpdateForm
{
    public partial class UpdaterForm : RadForm
    {
        public UpdaterForm()
        {
            InitializeComponent();
            DownloadProgressbar.ProgressBarElement.IndicatorElement1.BackColor = Color.Lime;
            DownloadLauncherFiles();
        }

        private async void DownloadLauncherFiles()
        {
            try
            {
                if (Directory.Exists("./tmp"))
                {
                    Directory.Delete("./tmp", true);
                }
                if (Program.UpdateLauncher)
                {
                    using (WebClient WebC = new WebClient())
                    {
                        DownloadingLabel.Text = "Downloading Launcher Update";
                        Directory.CreateDirectory("tmp");
                        WebC.DownloadProgressChanged += WebC_DownloadProgressChanged;
                        WebC.DownloadDataCompleted += new DownloadDataCompletedEventHandler(WebC_DownloadUICompleted);
                        var data = await WebC.DownloadDataTaskAsync(new Uri(Program.XmlGetSingleNode("/Launcher/DownloadUrl")));
                        File.WriteAllBytes(@".\tmp\Launcher.exe", data);
                    }
                }
                else if (Program.UpdateLang != null)
                {
                    using (WebClient WebC2 = new WebClient())
                    {
                        DownloadingLabel.Text = $"Downloading {Program.UpdateLang} Language Update";
                        Directory.CreateDirectory(@"tmp\Launcher-langs");
                        WebC2.DownloadProgressChanged += WebC_DownloadProgressChanged;
                        WebC2.DownloadDataCompleted += new DownloadDataCompletedEventHandler(WebC_DownloadlangCompleted);
                        var data = await WebC2.DownloadDataTaskAsync(new Uri(Program.XmlGetSingleNode($"/Launcher/Languages/{Program.UpdateLang}/DownloadUrl")));
                        File.WriteAllBytes($@".\tmp\Launcher-langs\{Program.UpdateLang}.json", data);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Download Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            File.Delete($@".\Launcher-langs\{Program.UpdateLang}.json");
                            File.Move($@".\tmp\Launcher-langs\{Program.UpdateLang}.json", $@".\Launcher-langs\{Program.UpdateLang}.json");
                            Directory.Delete(@".\tmp", true);
                            if (Program.Langnotfound)
                            {
                                Process.Start(Application.ExecutablePath);
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            Directory.Move(@".\tmp\Launcher-langs", @".\Launcher-langs");
                            Directory.Delete(@".\tmp");
                            if (Program.Langnotfound)
                            {
                                Process.Start(Application.ExecutablePath);
                                Environment.Exit(0);
                            }
                        }
                        Program.UpdateLang = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message.ToString()}\n{ex.StackTrace}", $"Updater Fatal Exception while trying to update lang {Program.UpdateLang}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
