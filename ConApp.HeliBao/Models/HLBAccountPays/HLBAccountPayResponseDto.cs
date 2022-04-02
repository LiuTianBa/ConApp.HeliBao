using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jzh.PayPlugin.HeLiBao.Models.HLBAccountPays
{
    public class HLBAccountPayResponseDto : HLBResponseBaseDto
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
        /// 订单状态
        /// </summary>
        public string orderStatus { get; set; }

        /// <summary>
        /// 平台流水号
        /// </summary>
        public string serialNumber { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal orderAmount { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        public string finishDate { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string description { get; set; }
    }
}
