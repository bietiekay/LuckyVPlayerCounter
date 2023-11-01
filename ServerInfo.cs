using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyVPlayerCount
{
    public class ServerInfo
    {
        [JsonProperty("playersCount")]
        public int PlayersCount { get; set; }
    }


}
