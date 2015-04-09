using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace foobar_readout
{
    [Serializable]
    public class WebsocketValues
    {
        [JsonProperty("music")]
        public MusicValues Music = new MusicValues();

        public static bool operator ==(WebsocketValues a, WebsocketValues b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }


            if (a.Music != b.Music)
            {
                return false;
            }
            
            return true;
        }

        public static bool operator !=(WebsocketValues a, WebsocketValues b)
        {
            return !(a == b);
        }
    }
}
