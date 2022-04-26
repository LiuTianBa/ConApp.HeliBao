using Jzh.PayPlugin.HeLiBao;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ConApp.HeliBao
{
    class Program
    {
        static void Main(string[] args)
        {

            var wx = new WXScanRequest
            {
                ProductCode = "WXPAYSCAN",
                OrderNo = "p_20170302185347",
                MerchantNo = "Me10047006",
                OrderAmout = 0.01F,
                MemberName = "张三",
                MemberID = "110101200001012999",
                MemberMobile = "13701234567",
                GoodsName = "Iphone7",
                OrderIp = "1.1.1.1",
                Period = "1",
                PeriodUnit = "Hour",
                ServerCallbackUrl = "https://www.badiu.com",
                PlatMerchantNo = "pNo1",
                ReportId = "123123",
                ShareList = new List<WXScanRequest.WXScanShare> {
                new WXScanRequest.WXScanShare{ index =1,ShareAmout = 5.33F, ShareMerchantNo="Me10000001"},
                new WXScanRequest.WXScanShare{ index =2,ShareAmout = 5.33F, ShareMerchantNo="Me10000002"},
                }
            };
            var context = new ValidationContext(wx, null, null);
            var results = new List<ValidationResult>();
            if (Validator.TryValidateObject(wx, context, results, true))
            {
                Console.WriteLine("验证成功");
            }
            else
            {
                results.Select(x => x.ErrorMessage).ToList().ForEach(Console.WriteLine);
            }

            var key = "ldGY8VRomQRmldBbVEMHrw==";
            var secret = "A4T7J8oFpyQDBhxi";
            var url = "	https://cbtrxtest.helipay.com/cbtrx/rest/pay/appScan";

            var j = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var input = JsonConvert.SerializeObject(wx, j);
            var dto = HLBPluginUtils.ProcessRequestDto(wx.MerchantNo, key, secret, wx); // 包装传输对象
            
            var reqStr = JsonConvert.SerializeObject(dto);
            var result = HLBPluginUtils.DoPost(url, reqStr);

            var response = JsonConvert.DeserializeObject<HLBDto>(result); // 返回
            var resultData = response.ProcessResponse<WXScanResponse>(key, secret);

        }


    }
}
