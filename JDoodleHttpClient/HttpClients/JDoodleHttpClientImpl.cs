using JDoodleHttpClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace JDoodleClient.HttpClients
{
    public class JDoodleHttpClientImpl : IJDoodleHttpClient
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        public JDoodleHttpClientImpl(HttpClient client)
        {
            httpClient = client;
        }
        public async Task<T?> MakePostRequest<T>(Uri requestUri, JDoodleRequestModel body)
        {
            var bodyJson = JsonConvert.SerializeObject(body);
            var content = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = content,
                RequestUri = requestUri
            };
            var response = await httpClient.SendAsync(request);
         
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ToString());
            }
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseBody, jsonSettings);
        }
    }
}
