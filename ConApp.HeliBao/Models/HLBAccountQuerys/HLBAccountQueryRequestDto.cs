using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jzh.PayPlugin.HeLiBao.Models.HLBAccountQuerys
{
    public class HLBAccountQueryRequestDto : HLBRequestBaseDto
    {
        /// <summary>
        /// 小B/小C商商户编号
        /// String(20)
        /// </summary>
        public string subMerchantNo { get; set; }

        /// <summary>
        /// 币种
        /// String(30)
        /// </summary>
        public string currency { get { return "CNY"; } }
    }
}
