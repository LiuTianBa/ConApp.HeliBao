using Jzh.PayPlugin.HeLiBao;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace ConApp.HeliBao
{
    class Program
    {
        static void Main(string[] args)
        {
            var wx = new WXScanRequest
            {
                productCode = "WXPAYSCAN",
                orderNo = "p_20170302185348",
                merchantNo = "Me10047006",
                orderAmount = 0.02F,
                memberName = "张三",
                memberID = "110101200001012999",
                memberMobile = "13701234567",
                goodsName = "Iphone7",
                orderIp = "1.1.1.1",
                period = "1",
                periodUnit = "Hour",
                serverCallbackUrl = "https://www.badiu.com",
                platMerchantNo = "pNo1",
                reportId = "",
                //shareList = new List<WXScanRequest.WXScanShare> {
                //new WXScanRequest.WXScanShare{ index =1,shareAmount = 0.01F, shareMerchantNo="Me10047006"},
                //new WXScanRequest.WXScanShare{ index =2,shareAmount = 0.01F, shareMerchantNo="Me10047006"},
                //}
            };
            var context = new ValidationContext(wx, null, null);
            var results = new List<ValidationResult>();
            if (Validator.TryValidateObject(wx, context, results, true))
            {

            }
            else
            {
                results.Select(x => x.ErrorMessage).ToList().ForEach(Console.WriteLine);
            }

            var aeskey = "EMGVuR9HAZGSdeaxIfPCWw==";
            var signsecret = "Xj1pd4Lh73DccrUM";
            var url = "https://cbtrxtest.helipay.com/cbtrx/rest/pay/appScan";

            var dto = HLBPluginUtils.ProcessRequestDto(wx.merchantNo, aeskey, signsecret, wx);

            var reqStr = JsonConvert.SerializeObject(dto);
            var result = HLBPluginUtils.DoPost(url, reqStr);

            var response = JsonConvert.DeserializeObject<HLBDto>(result);
            var resultData = response.ProcessResponse<WXScanResponse>(aeskey, signsecret);

        }


    }
}
