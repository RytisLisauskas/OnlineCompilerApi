using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDoodleHttpClient.Models
{
    public class JDoodleRequestModel
    {
        public string? clientId { get; set; }
        public string? clientSecret { get; set; }
        public string script { get; set; }
        public string language { get; set; }
        public string versionIndex { get; set; }

        public JDoodleRequestModel(string script, string language, string versionIndex)
        {
            this.script = script;
            this.language = language;
            this.versionIndex = versionIndex;
        }

    }
}
