using Jzh.PayPlugin.HeLiBao.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConApp.HeliBao
{
    public sealed class WXScanResponse : HLBResponseBaseDto
    {
        public  string ProductCode { get; set; }
        public string OrderNo { get; set; }
        /// <summary>
        /// 商户编号
        /// </summary>
        public string MerchantNo { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        public string SerialNumber { get; set; }
        public string QrCode { get; set; }
    }
}
