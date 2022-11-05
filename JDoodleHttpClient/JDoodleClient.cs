using JDoodleClient.HttpClients;
using JDoodleHttpClient.Configuraion;
using JDoodleHttpClient.Models;

namespace JDoodleHttpClient
{
    public class JDoodleClient : IJDoodleClient
    {
        private IJDoodleHttpClient httpClient;
        private IJDoodleClientConfiguration configuration;

        public JDoodleClient(IJDoodleHttpClient client, IJDoodleClientConfiguration config)
        {
            httpClient = client;
            configuration = config;
        }
        public async Task<JDoodleResponseModel> ExecuteTask(JDoodleRequestModel request)
        {
            request.clientSecret = configuration.ClientSecret;
            request.clientId = configuration.ClientId;
            var requestUri = configuration.BaseUrl;
            return await httpClient.MakePostRequest<JDoodleResponseModel>(requestUri,request);
        }
    }
}