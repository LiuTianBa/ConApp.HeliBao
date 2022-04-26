using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jzh.PayPlugin.HeLiBao.Models
{
    public class HLBRequestBaseDto
    {
        /// <summary>
        /// 商户编号
        /// </summary>
        [Required]
        [MaxLength(10)]
        [JsonProperty(Order = 5)]
        public string merchantNo { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [Required]
        [MaxLength(64)]
        [JsonProperty(Order = 8)]
        public string orderNo { get; set; }

        /// <summary>
        /// 产品编码
        /// </summary>
        [Required]
        [MaxLength(20)]
        [JsonProperty(Order = 12)]
        public string productCode { get; set; }
    }
}
