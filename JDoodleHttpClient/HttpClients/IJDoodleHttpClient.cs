using JDoodleHttpClient.Models;


namespace JDoodleClient.HttpClients
{
    public interface IJDoodleHttpClient
    {
        public Task<T?> MakePostRequest<T>(Uri requestUri, JDoodleRequestModel body);
    }
}
