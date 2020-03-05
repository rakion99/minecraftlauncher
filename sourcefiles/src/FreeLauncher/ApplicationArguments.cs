using CommandLine;

namespace FreeLauncher
{
    public class ApplicationArguments
    {
        [Option('o', "offline", Required = false, HelpText = "Forces offline mode")]
        public bool OfflineMode { get; set; }
    }
}
