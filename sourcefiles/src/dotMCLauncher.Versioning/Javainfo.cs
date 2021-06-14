using Newtonsoft.Json;

namespace dotMCLauncher.Versioning
{
    public class Javainfo
    {
        [JsonProperty("majorVersion")]
        public string majorVersion { get; set; }
    }
}
