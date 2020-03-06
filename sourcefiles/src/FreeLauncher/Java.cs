using System;
using System.IO;

namespace FreeLauncher
{
    internal static class Java
    {
        public static string JavaExecutable => GetJavaFolder() == null ? null : string.Format("{0}\\bin\\java.exe", GetJavaFolder());
        public static string JavaInstallationPath => GetJavaFolder();
        private static Configuration _configuration;
        private static string[] args = { "" };

        public static string JavaBitInstallation
        {
            get {
                Configuration configuration = new Configuration(args);
                _configuration = configuration;

                //saved for later or to remove
                //ApplicationLocalization localization = _configuration.Localization;
                //string downloadjava32 = localization.Downloadjava32;
                //string downloadjava64 = localization.Downloadjava64;
                //string javanotfound = localization.Javanotfound;
                //string needjava = localization.Needjava;


                if (JavaExecutable == null) {
                    return "null";
                }
                if (!Environment.Is64BitOperatingSystem) {
                    return "32";
                }
                if (Environment.Is64BitOperatingSystem) {
                    return "64";
                }
                return "null";
            }
        }

        private static string GetJavaFolder()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                return "./jre_64bit";
            }
            else
            {
                return "./jre_32bit";
            }
        }

        public static bool IsJavaDownloaded()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                if (File.Exists("./jre_64bit/bin/java.exe"))
                {
                    return true;
                }
            }
            else
            {
                if (File.Exists("./jre_32bit/bin/java.exe"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
