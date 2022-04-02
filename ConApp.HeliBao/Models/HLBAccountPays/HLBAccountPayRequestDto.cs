using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jzh.PayPlugin.HeLiBao.Models.HLBAccountPays
{
    public class HLBAccountPayRequestDto : HLBRequestBaseDto
    {
        /// <summary>
        /// 订单金额
        /// 单位：元
        /// </summary>
        public decimal orderAmount { get; set; }

        /// <summary>
        /// 小C商户编号
        /// String(10)
        /// </summary>
        public string subMerchantNo { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        public string currency
        {
            get
            {
                return "CNY"; //"RMB";//
            }
        }

        /// <summary>
        /// 商品列表
        /// Json
        /// </summary>
        public List<HLBAccountPayGoodsDetail> goods { get; set; }
    }

    public class HLBAccountPayGoodsDetail : DetailBaseDto
    {
        /// <summary>
        /// 商品价格
        /// 单位：元
        /// </summary>
        public decimal amount { get; set; }

        /// <summary>
        /// 商品名称
        /// String(150)
        /// </summary>
        public string goodsName { get; set; }

        #region 非必填

        ///// <summary>
        ///// 收货人
        ///// String(150)
        ///// </summary>
        //public string receiver { get; set; }

        ///// <summary>
        ///// 商品数量
        ///// int
        ///// </summary>
        //public string quantity { get; set; }

        ///// <summary>
        ///// 商品描述
        ///// String(150)
        ///// </summary>
        //public string description { get; set; } 

        #endregion
    }
}
