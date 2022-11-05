
using JDoodleClient.HttpClients;
using JDoodleHttpClient.Configuraion;
using Microsoft.Extensions.DependencyInjection;

namespace JDoodleHttpClient.Extensions
{
    public static class JDoodleClientExtensions
    {
        public static void AddJDoodleClient(this IServiceCollection services,
            Func<IServiceProvider, IJDoodleClientConfiguration> JDoodleClientConfigurationImplementationFactory)
        {
            services.AddScoped<IJDoodleClient, JDoodleClient>();
            services.AddHttpClient<IJDoodleHttpClient, JDoodleHttpClientImpl>();
            services.AddScoped(JDoodleClientConfigurationImplementationFactory);
        }
    }
}
