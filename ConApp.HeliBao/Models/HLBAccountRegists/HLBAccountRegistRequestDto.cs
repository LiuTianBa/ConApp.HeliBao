using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jzh.PayPlugin.HeLiBao.Models.HLBAccountRegists
{
    public class HLBAccountRegistRequestDto : HLBRequestBaseDto
    {
        /// <summary>
        /// 商户姓名
        /// String(50)
        /// </summary>
        public string merchantName { get; set; }

        /// <summary>
        /// 身份证号
        /// String(20)
        /// </summary>
        public string legalPersonID { get; set; }

        /// <summary>
        /// 用户类型
        /// String(20)
        /// INDIVIDUAL(小C)和MERCHANT(小B)两种类型
        /// </summary>
        public string merchantType { get { return "INDIVIDUAL"; } }

        /// <summary>
        /// 手机号
        /// String(20)
        /// </summary>
        public string bindMobile { get; set; }

        /// <summary>
        /// 币种
        /// String(100)
        /// </summary>
        public string currencys { get { return "CNY"; } }

        /// <summary>
        /// 绑定扣款
        /// String(20)
        /// </summary>
        public string bindPayment { get { return "TRUE"; } }

        /// <summary>
        /// 资金账户类型
        /// String(20)
        /// </summary>
        public string accountType { get { return "JOINT_ACCOUNT"; } }

    }
}
