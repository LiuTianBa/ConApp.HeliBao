using Jzh.PayPlugin.HeLiBao.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConApp.HeliBao
{
    public sealed class WXScanRequest : HLBRequestBaseDto
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        [Required]
        [MaxLength(400)]
        [JsonProperty(Order = 1)]
        public string goodsName { get; set; }
        /// <summary>
        /// 用户身份证号
        /// </summary>
        [Required]
        [MaxLength(18)]
        [JsonProperty(Order = 2)]
        public string memberID { get; set; }
        /// <summary>
        /// 用户手机号
        /// </summary>
        [Required]
        [MaxLength(20)]
        [JsonProperty(Order = 3)]
        public string memberMobile { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        [Required]
        [MaxLength(10)]
        [JsonProperty(Order = 4)]
        public string memberName { get; set; }
        /// <summary>
        /// 订单金额 
        /// </summary>
        [Required]
        [CustomValidation(typeof(ValidationExtension), "PositiveNumber")]
        [JsonProperty(Order = 6)]
        public float orderAmount { get; set; }
        /// <summary>
        /// 下单ip
        /// </summary>
        [MaxLength(15)]
        [JsonProperty(Order = 7)]
        public string orderIp { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        [MaxLength(6)]
        [JsonProperty(Order = 9)]
        public string period { get; set; }
        /// <summary>
        /// 有效期单位
        /// </summary>
        [MaxLength(10)]
        [JsonProperty(Order = 10)]
        public string periodUnit { get; set; }
        /// <summary>
        /// 平台商户编号
        /// </summary>
        [MaxLength(10)]
        [JsonProperty(Order = 11)]
        public string platMerchantNo { get; set; }
        /// <summary>
        /// 报备号 
        /// </summary>
        [MaxLength(20)]
        [JsonProperty(Order = 13)]
        public string reportId { get; set; }
        /// <summary>
        /// 服务器回调地址
        /// </summary>
        [MaxLength(300)]
        [JsonProperty(Order = 14)]
        public string serverCallbackUrl { get; set; }
        /// <summary>
        /// 分账请求参数明细
        /// </summary>
        [MaxLength(100)]
        [JsonProperty(Order = 15)]
        public IList<WXScanShare> shareList { get; set; }

        public sealed class WXScanShare : DetailBaseDto
        {
            /// <summary>
            /// 分账金额
            /// </summary>
            [Required]
            [CustomValidation(typeof(ValidationExtension), "PositiveNumber")]
            [JsonProperty(Order = 11)]
            public float shareAmount { get; set; }

            /// <summary>
            /// 分账账号编号
            /// </summary>
            [Required]
            [MaxLength(10)]
            [JsonProperty(Order = 12)]
            public string shareMerchantNo { get; set; }
        }
    }

}
