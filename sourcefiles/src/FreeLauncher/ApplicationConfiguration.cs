namespace FreeLauncher
{
    public class ApplicationConfiguration
    {
        public bool CheckforLauncherUpdates { get; set; } = true;
        public bool SkipAssetsDownload { get; set; }
        public bool EnableGameLogging { get; set; } = true;
        public bool CloseTabAfterSuccessfulExitCode { get; set; } = true;
        public string SelectedLanguage { get; set; } = "es_MX";
    }
}
