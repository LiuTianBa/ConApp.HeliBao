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
        /// 产品编码
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string ProductCode { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        [Required]
        [MaxLength(64)]
        public string OrderNo { get; set; }
        /// <summary>
        /// 商户编号
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string MerchantNo { get; set; }
    }
}
