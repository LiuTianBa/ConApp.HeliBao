using Jzh.PayPlugin.HeLiBao.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jzh.PayPlugin.HeLiBao
{
    public class HLBDto
    {
        /// <summary>
        /// 业务参数 aes加密的结果
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string merchantNo { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string orderNo { get; set; }

        /// <summary>
        /// 产品编码
        /// </summary>
        public string productCode { get; set; }

        /// <summary>
        /// sha256签名的结果
        /// </summary>
        public string sign { get; set; }


        /// <summary>
        /// 处理返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aesKey"></param>
        /// <param name="signKey"></param>
        /// <returns></returns>
        public T ProcessResponse<T>(string aesKey, string signKey) where T : HLBResponseBaseDto
        {
            string responseContent = HLBPluginUtils.DecryptByAES(content, aesKey);

            T responseDataDto = JsonConvert.DeserializeObject<T>(responseContent);
            //var jsonDto = JObject.Parse(responseContent);

            var responseDic = HLBPluginUtils.ToDic(responseDataDto);
            var responseSign = HLBPluginUtils.CreateSign(responseDic, signKey);

            if (responseSign != sign)
            {
                throw new Exception("合利宝验签错误！");
            }
            if (responseDataDto.ErrorCode != "0000")
                throw new Exception(responseDataDto.ErrorMessage);
            return responseDataDto;
        }
    }
}
