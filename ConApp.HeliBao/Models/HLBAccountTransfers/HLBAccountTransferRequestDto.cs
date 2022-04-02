using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jzh.PayPlugin.HeLiBao.Models.HLBAccountTransfers
{
    public class HLBAccountTransferRequestDto : HLBRequestBaseDto
    {
        /// <summary>
        /// 订单金额
        /// 单位：元
        /// </summary>
        public decimal orderAmount { get; set; }

        /// <summary>
        /// 转出商户编号
        /// String(20)
        /// </summary>
        public string sourceMerchantNo { get; set; }

        /// <summary>
        /// 转入商户编号
        /// String(20)
        /// </summary>
        public string targetMerchantNo { get; set; }

        /// <summary>
        /// 币种
        /// String(20)
        /// </summary>
        public string currency
        {
            get
            {
                return "CNY";
            }
        }

    }
}
