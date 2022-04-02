using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jzh.PayPlugin.HeLiBao.Models
{
    public class HLBResponseBaseDto
    {
        /// <summary>
        /// 响应码
        /// 0000 代表请求成功
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 响应信息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 响应时间
        /// </summary>
        public string Current { get; set; }

    }
}
