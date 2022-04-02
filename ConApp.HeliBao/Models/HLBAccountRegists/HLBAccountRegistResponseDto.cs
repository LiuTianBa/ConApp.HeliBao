using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jzh.PayPlugin.HeLiBao.Models.HLBAccountRegists
{
    public class HLBAccountRegistResponseDto : HLBResponseBaseDto
    {
        /// <summary>
        /// 产品编码
        /// String(20)
        /// </summary>
        public string productCode { get; set; }

        /// <summary>
        /// 商户订单号
        /// String(64)
        /// 商户系统内部订单号，同一商户号下订单号唯一
        /// </summary>
        public string orderNo { get; set; }

        /// <summary>
        /// 商户编号
        /// String(64)
        /// 合利宝-跨境系统分配的商户编号
        /// </summary>
        public string merchantNo { get; set; }

        /// <summary>
        /// 子商户编号
        /// </summary>
        public string subMerchantNo { get; set; }

        /// <summary>
        /// 平台商系统的联名账户商户ID
        /// </summary>
        public string memberNo { get; set; }

        /// <summary>
        /// 商户姓名
        /// </summary>
        public string merchantName { get; set; }

        /// <summary>
        /// 注册状态
        /// </summary>
        public string status { get; set; }

    }
}
