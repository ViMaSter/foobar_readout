using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace foobar_readout
{
    [Serializable]
    public class MusicValues
    {
        [JsonProperty("artist")]
        public string Artist = "";
        [JsonProperty("track")]
        public string Track = "";
        [JsonProperty("album")]
        public string Album = "";
        [JsonProperty("album_artwork")]
        public string Album_Artwork = "";
        [JsonProperty("forcehide")]
        public bool ForceHide = false;

        public static bool operator ==(MusicValues a, MusicValues b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }


            if (a.Artist != b.Artist)
            {
                return false;
            }

            if (a.Track != b.Track)
            {
                return false;
            }

            if (a.Album != b.Album)
            {
                return false;
            }

            if (a.Album_Artwork != b.Album_Artwork)
            {
                return false;
            }

            if (a.ForceHide != b.ForceHide)
            {
                return false;
            }

            return true;
        }

        public static bool operator !=(MusicValues a, MusicValues b)
        {
            return !(a == b);
        }
    }
}
