using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace FreeLauncher
{
    internal static class Java
    {
        public static string JavaExecutable
            => GetJavaInstallationPath() == null ? null : string.Format("{0}\\bin\\java.exe", GetJavaInstallationPath());

        public static string JavaInstallationPath => GetJavaInstallationPath();

        private static bool _isNotWow6432Installation;
        private static Configuration _configuration;
        private static string[] args = { "" };

        public static string JavaBitInstallation
        {
            get {
                Configuration configuration = new Configuration(args);
                _configuration = configuration;

                ApplicationLocalization localization = _configuration.Localization;
                string downloadjava32 = localization.Downloadjava32;
                string downloadjava64 = localization.Downloadjava64;
                string javanotfound = localization.Javanotfound;
                string needjava = localization.Needjava;


                if (JavaExecutable == null) {
                    if (!Environment.Is64BitOperatingSystem)
                    {
                        DialogResult Down32bit = MessageBox.Show(downloadjava32, javanotfound, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (Down32bit == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start("https://drive.google.com/open?id=1ykUdrqR42dHcBIRCTHQJPC6Dg4q1Pf6w");
                            MessageBox.Show(needjava);
                            Environment.Exit(0);
                        }
                        else
                        {
                            MessageBox.Show(needjava);
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        DialogResult Down64bit = MessageBox.Show(downloadjava64, javanotfound, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (Down64bit == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start("https://drive.google.com/open?id=1HIjyaWql3siapxIqYvkAeT9idyzT47Y9");
                            MessageBox.Show(needjava);
                            Environment.Exit(0);
                        }
                        else
                        {
                            MessageBox.Show(needjava);
                            Environment.Exit(0);
                        }
                    }
                    return "null";
                }
                if ((_isNotWow6432Installation && !Environment.Is64BitOperatingSystem) ||
                    (!_isNotWow6432Installation && Environment.Is64BitOperatingSystem)) {
                    return "32";
                }
                if (_isNotWow6432Installation && Environment.Is64BitOperatingSystem) {
                    return "64";
                }
                return "null";
            }
        }

        private static string GetJavaInstallationPath()
        {
            _isNotWow6432Installation = true;
            string javaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment";
            while (true) {
                using (RegistryKey baseKey =
                    RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(javaKey)) {
                    if (baseKey == null) {
                        if (javaKey == "SOFTWARE\\Wow6432Node\\JavaSoft\\Java Runtime Environment") {
                            break;
                        }
                        _isNotWow6432Installation = false;
                        javaKey = "SOFTWARE\\Wow6432Node\\JavaSoft\\Java Runtime Environment";
                        continue;
                    }
                    string currentVersion = baseKey.GetValue("CurrentVersion").ToString();
                    using (RegistryKey homeKey = baseKey.OpenSubKey(currentVersion))
                        if (homeKey != null) {
                            return homeKey.GetValue("JavaHome").ToString();
                        }
                }
                break;
            }
            return null;
        }
    }
}
