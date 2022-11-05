using JDoodleHttpClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDoodleHttpClient
{
    public interface IJDoodleClient
    {
        public Task<JDoodleResponseModel> ExecuteTask(JDoodleRequestModel request);
    }
}
