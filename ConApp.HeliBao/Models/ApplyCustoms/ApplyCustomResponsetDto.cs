using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jzh.PayPlugin.HeLiBao.Models.ApplyCustoms
{
    public class ApplyCustomResponsetDto : HLBResponseBaseDto
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
        /// 支付产品编码
        /// String(20)
        /// 报关订单对应的实际支付订单的产品编码
        /// </summary>
        public string payProductCode { get; set; }

        /// <summary>
        /// 原始订单号
        /// String(64)
        /// 商户原交易订单的商户订单号(请求合利宝的订单号)
        /// </summary>
        public string payOrderNo { get; set; }

        /// <summary>
        /// 报关明细
        /// </summary>
        public List<ApplyCustomResponseDetail> detailList { get; set; }

    }

    public class ApplyCustomResponseDetail : DetailBaseDto
    {
        /// <summary>
        /// 海关通道
        /// </summary>
        public string customsType { get; set; }

        /// <summary>
        /// 国检通道
        /// </summary>
        public string inspectionType { get; set; }

        /// <summary>
        /// 平台流水号
        /// </summary>
        public string serialNumber { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public string createDate { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        public string finishDate { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public string orderStatus { get; set; }

        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal orderAmount { get; set; }

        /// <summary>
        /// 支付货款
        /// </summary>
        public decimal goodsAmount { get; set; }

        /// <summary>
        /// 支付运费
        /// </summary>
        public decimal freight { get; set; }

        /// <summary>
        /// 支付税款
        /// </summary>
        public decimal tax { get; set; }
    }
}
