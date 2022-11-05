using JDoodleHttpClient.Configuraion;

namespace OnlineCompiler.Configurations
{
    public class JDoodleClientConfiguration : IJDoodleClientConfiguration
    {
        public Uri BaseUrl { get; }
        public string ClientId { get; }
        public string ClientSecret { get; }

        public JDoodleClientConfiguration(IConfigurationSection configSection)
        {
            BaseUrl = new Uri(configSection["Url"]);
            ClientId = configSection["ClientId"];
            ClientSecret = configSection["ClientSecret"];
        }
    }
}
