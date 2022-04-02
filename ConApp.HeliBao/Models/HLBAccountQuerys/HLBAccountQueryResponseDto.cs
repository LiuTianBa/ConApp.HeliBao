using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jzh.PayPlugin.HeLiBao.Models.HLBAccountQuerys
{
    public class HLBAccountQueryResponseDto: HLBResponseBaseDto
    {
        /// <summary>
        /// 产品编码
        /// </summary>
        public string productCode { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string orderNo { get; set; }

        /// <summary>
        /// 商户编号
        /// </summary>
        public string merchantNo { get; set; }

        /// <summary>
        /// 小B/小C商商户编号
        /// String(20)
        /// </summary>
        public string subMerchantNo { get; set; }

        /// <summary>
        /// 联名商商户编号
        /// </summary>
        public string ownerNo { get; set; }

        /// <summary>
        /// 账户状态
        /// ACTIV/INACTIVE/DELETED/FREEZE_CREDIT/FREEZE_DEBIT
        /// </summary>
        public string accountStatus { get; set; }

        /// <summary>
        /// 账户类型
        /// </summary>
        public string accountType { get; set; }

        /// <summary>
        /// 币种类型
        /// </summary>
        public string currency { get; set; }

        /// <summary>
        /// 账户余额
        /// 单位：元
        /// </summary>
        public decimal balance { get; set; }
 
    }
}
