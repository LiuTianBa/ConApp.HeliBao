using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jzh.PayPlugin.HeLiBao.Models
{
    public class DetailBaseDto
    {
        [JsonProperty(Order = 10)]
        public int index { get; set; }
    }
}
