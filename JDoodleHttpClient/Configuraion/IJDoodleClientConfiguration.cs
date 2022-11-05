using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDoodleHttpClient.Configuraion
{
    public interface IJDoodleClientConfiguration
    {
        public Uri BaseUrl { get; }
        public string ClientId { get; }
        public string ClientSecret { get; }
    }
}
