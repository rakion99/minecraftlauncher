using System;
using System.IO;

namespace FreeLauncher
{
    internal static class Java
    {
        public static string JavaExecutable => GetJavaFolder == null ? null : string.Format("{0}\\bin\\java.exe", GetJavaFolder);
        public static string JavaInstallationPath => GetJavaFolder;

        public static string JavaBitInstallation
        {
            get
            {
                if (JavaExecutable == null)
                {
                    return "null";
                }
                if (!Environment.Is64BitOperatingSystem)
                {
                    return "32";
                }
                if (Environment.Is64BitOperatingSystem)
                {
                    return "64";
                }
                return "null";
            }
        }

        private static string GetJavaFolder => Environment.Is64BitOperatingSystem ? "./jre_64bit" : "./jre_32bit";

        public static bool IsJavaDownloaded
        {
            get
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
}
