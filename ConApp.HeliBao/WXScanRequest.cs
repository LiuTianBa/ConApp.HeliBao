using Jzh.PayPlugin.HeLiBao.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConApp.HeliBao
{
    public sealed class WXScanRequest : HLBRequestBaseDto
    {
      
        /// <summary>
        /// 订单金额 
        /// </summary>
        [Required]
        [CustomValidation(typeof(ValidationExtension), "PositiveNumber")]
        public float OrderAmout { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string MemberName { get; set; }
        /// <summary>
        /// 用户身份证号
        /// </summary>
        [Required]
        [MaxLength(18)]
        public string MemberID { get; set; }
        /// <summary>
        /// 用户手机号
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string MemberMobile { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Required]
        [MaxLength(400)]
        public string GoodsName { get; set; }
        /// <summary>
        /// 下单ip
        /// </summary>
        [MaxLength(15)]
        public string OrderIp { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        [MaxLength(6)]
        public string Period { get; set; }
        /// <summary>
        /// 有效期单位
        /// </summary>
        [MaxLength(10)]
        public string PeriodUnit { get; set; }
        /// <summary>
        /// 服务器回调地址
        /// </summary>
        [MaxLength(300)]
        public string ServerCallbackUrl { get; set; }
        /// <summary>
        /// 平台商户编号
        /// </summary>
        [MaxLength(10)]
        public string PlatMerchantNo { get; set; }
        /// <summary>
        /// 报备号 
        /// </summary>
        [MaxLength(20)]
        public string ReportId { get; set; }
        /// <summary>
        /// 分账请求参数明细
        /// </summary>
        [MaxLength(100)]
        public IList<WXScanShare> ShareList { get; set; }

        public sealed class WXScanShare
        {
            /// <summary>
            /// 排序参数
            /// </summary>
            [Required]
            public int Index { get; set; }
            /// <summary>
            /// 分账账号编号
            /// </summary>
            [Required]
            [MaxLength(10)]
            public string ShareMerchantNo { get; set; }
            /// <summary>
            /// 分账金额
            /// </summary>
            [Required]
            [CustomValidation(typeof(ValidationExtension), "PositiveNumber")]
            public float ShareAmout { get; set; }
        }
    }

}
