using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace foobar_readout
{
    public class WebsocketResponse
    {
        [JsonProperty("values")]
        public WebsocketValues Values;
        [JsonProperty("command")]
        public string Command;
    }
}
