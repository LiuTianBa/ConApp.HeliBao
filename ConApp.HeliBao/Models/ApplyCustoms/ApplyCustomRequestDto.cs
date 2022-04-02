using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jzh.PayPlugin.HeLiBao.Models.ApplyCustoms
{
    public class ApplyCustomRequestDto : HLBRequestBaseDto
    {
        ///// <summary>
        ///// 产品编码
        ///// String(20)
        ///// </summary>
        //public override string productCode
        //{
        //    get
        //    {
        //        return "APPLYCUSTOMS";
        //    }
        //}

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
        /// List
        /// 对应支付订单下多个报关信息信息
        /// </summary>
        public List<ApplyCustomerDetail> detailList { get; set; }
    }

    public class ApplyCustomerDetail : DetailBaseDto
    {
        /// <summary>
        /// 海关通道
        /// String(20)
        /// 前往附录查看《海关国检编码》
        /// </summary>
        public string customsType { get; set; }

        /// <summary>
        /// 支付运费
        /// Number(10.2)
        /// 单位：元;
        /// </summary>
        public string freight { get; set; }

        /// <summary>
        /// 支付货款
        /// Number(10.2)
        /// 单位：元;
        /// </summary>
        public decimal goodsAmount { get; set; }

        /// <summary>
        /// 商品单价
        /// Number(10.2)        
        /// </summary>
        public decimal goodsItemAmount { get; set; }

        /// <summary>
        /// 商品名称
        /// String(100)
        /// </summary>
        public string goodsName { get; set; }

        /// <summary>
        /// 商品数量
        /// Integer
        /// </summary>
        public int goodsNum { get; set; }

        /// <summary>
        /// 国检通道    ————可为空
        /// String(20)
        /// GUANGZHOUNS-广州南沙;目前支持广州南沙国检
        /// </summary>
        public string inspectionType { get; set; }

        /// <summary>
        /// 海关企业备案号
        /// String(50)
        /// 报关企业在海关的备案号
        /// </summary>
        public string merchantCommerceCode { get; set; }

        /// <summary>
        /// 海关企业备案名称
        /// String(200)
        /// 报关企业在海关的备案号
        /// </summary>
        public string merchantCommerceName { get; set; }

        /// <summary>
        /// 国检企业备案号    ————可为空
        /// String(50)
        /// 报关企业在国检的备案号,国检通道不为空时必录
        /// </summary>
        public string merchantInspectionCode { get; set; }

        /// <summary>
        /// 国检企业备案名称    ————可为空
        /// String(200)
        /// 报关企业在国检的备案名称
        /// </summary>
        public string merchantInspectionName { get; set; }

        /// <summary>
        /// 支付金额
        /// Number(10.2)
        /// 单位：元;支付金额=货款+税款+运费;支付金额不能大于原订单金额
        /// </summary>
        public decimal orderAmount { get; set; }

        /// <summary>
        /// 备注    ————可为空
        /// String(200)
        /// </summary>
        public string summary { get; set; }

        /// <summary>
        /// 支付税款
        /// Number(10.2)
        /// 单位：元;
        /// </summary>
        public decimal tax { get; set; }

    }
}
