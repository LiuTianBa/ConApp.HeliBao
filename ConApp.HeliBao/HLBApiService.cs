using Jzh.PayPlugin.HeLiBao.Models.ApplyCustomQuerys;
using Jzh.PayPlugin.HeLiBao.Models.ApplyCustoms;
using Jzh.PayPlugin.HeLiBao.Models.HLBAccountPays;
using Jzh.PayPlugin.HeLiBao.Models.HLBAccountQuerys;
using Jzh.PayPlugin.HeLiBao.Models.HLBAccountRegists;
using Jzh.PayPlugin.HeLiBao.Models.HLBAccountTransfers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jzh.PayPlugin.HeLiBao
{
    public class HLBApiService
    {

        /// <summary>
        /// 注册联名账户
        /// </summary>
        /// <param name="config"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static HLBAccountRegistResponseDto HLBAccountRegist(HLBConfig config, HLBAccountRegistRequestDto model)
        {
            //var //logger = LogHelper.GetLogger("合利宝—注册联名账户");

            var requestDto = HLBPluginUtils.ProcessRequestDto<HLBAccountRegistRequestDto>(config.MerchantNo, config.AesKey, config.SignKey, model);

            ////logger.InfoFormat("【合利宝—注册联名账户】请求信息Model：{0}", JsonConvert.SerializeObject(model));

            var requestDtoStr = JsonConvert.SerializeObject(requestDto);
            ////logger.InfoFormat("【合利宝—注册联名账户】请求信息：{0}\r\n{1}", config.ApiUrl, requestDtoStr);

            var result = HLBPluginUtils.DoPost(config.ApiUrl, requestDtoStr);

            ////logger.InfoFormat("【合利宝—注册联名账户】返回信息：{0}", result);

            var response = JsonConvert.DeserializeObject<HLBDto>(result);

            var resultData = response.ProcessResponse<HLBAccountRegistResponseDto>(config.AesKey, config.SignKey);
            ////logger.InfoFormat("【合利宝—注册联名账户】返回信息Model：{0}", JsonConvert.SerializeObject(resultData));

            return resultData;
        }

        /// <summary>
        /// 联名账户查询
        /// </summary>
        /// <param name="config"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static HLBAccountQueryResponseDto HLBAccountQuery(HLBConfig config, HLBAccountQueryRequestDto model)
        {
            //var //logger = LogHelper.GetLogger("合利宝—联名账户查询");

            var requestDto = HLBPluginUtils.ProcessRequestDto<HLBAccountQueryRequestDto>(config.MerchantNo, config.AesKey, config.SignKey, model);

            ////logger.InfoFormat("【合利宝—联名账户查询】请求信息Model：{0}", JsonConvert.SerializeObject(model));

            var requestDtoStr = JsonConvert.SerializeObject(requestDto);
            ////logger.InfoFormat("【合利宝—联名账户查询】请求信息：{0}\r\n{1}", config.ApiUrl, requestDtoStr);

            var result = HLBPluginUtils.DoPost(config.ApiUrl, requestDtoStr);

            ////logger.InfoFormat("【合利宝—联名账户查询】返回信息：{0}", result);

            var response = JsonConvert.DeserializeObject<HLBDto>(result);

            var resultData = response.ProcessResponse<HLBAccountQueryResponseDto>(config.AesKey, config.SignKey);

            ////logger.InfoFormat("【合利宝—联名账户查询】返回信息Model：{0}", JsonConvert.SerializeObject(resultData));

            return resultData;
        }

        /// <summary>
        /// 联名账户转账
        /// </summary>
        /// <param name="config"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static HLBAccountTransferResponseDto HLBAccountTransfer(HLBConfig config, HLBAccountTransferRequestDto model)
        {
            //var logger = LogHelper.GetLogger("合利宝—联名账户转账");

            var requestDto = HLBPluginUtils.ProcessRequestDto<HLBAccountTransferRequestDto>(config.MerchantNo, config.AesKey, config.SignKey, model);

            //logger.InfoFormat("【合利宝—联名账户转账】请求信息Model：{0}", JsonConvert.SerializeObject(model));

            var requestDtoStr = JsonConvert.SerializeObject(requestDto);
            //logger.InfoFormat("【合利宝—联名账户转账】请求信息：{0}\r\n{1}", config.ApiUrl, requestDtoStr);

            var result = HLBPluginUtils.DoPost(config.ApiUrl, requestDtoStr);

            //logger.InfoFormat("【合利宝—联名账户转账】返回信息：{0}", result);

            var response = JsonConvert.DeserializeObject<HLBDto>(result);

            var resultData = response.ProcessResponse<HLBAccountTransferResponseDto>(config.AesKey, config.SignKey);

            //logger.InfoFormat("【合利宝—联名账户转账】返回信息Model：{0}", JsonConvert.SerializeObject(resultData));

            return resultData;
        }

        /// <summary>
        /// 联名账户支付
        /// </summary>
        /// <param name="config"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static HLBAccountPayResponseDto HLBAccountPay(HLBConfig config, HLBAccountPayRequestDto model)
        {
            //var logger = LogHelper.GetLogger("合利宝—联名账户支付");

            var requestDto = HLBPluginUtils.ProcessRequestDto<HLBAccountPayRequestDto>(config.MerchantNo, config.AesKey, config.SignKey, model);

            //logger.InfoFormat("【合利宝—联名账户支付】请求信息Model：{0}", JsonConvert.SerializeObject(model));

            var requestDtoStr = JsonConvert.SerializeObject(requestDto);
            //logger.InfoFormat("【合利宝—联名账户支付】请求信息：{0}\r\n{1}", config.ApiUrl, requestDtoStr);

            var result = HLBPluginUtils.DoPost(config.ApiUrl, requestDtoStr);

            //logger.InfoFormat("【合利宝—联名账户支付】返回信息：{0}", result);

            var response = JsonConvert.DeserializeObject<HLBDto>(result);

            var resultData = response.ProcessResponse<HLBAccountPayResponseDto>(config.AesKey, config.SignKey);

            //logger.InfoFormat("【合利宝—联名账户支付】返回信息Model：{0}", JsonConvert.SerializeObject(resultData));

            return resultData;
        }

        /// <summary>
        /// 申报海关（支付单）
        /// </summary>
        /// <param name="config"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ApplyCustomResponsetDto ApplyCustom(HLBConfig config, ApplyCustomRequestDto model)
        {
            //var logger = LogHelper.GetLogger("合利宝—申报支付单");

            var requestDto = HLBPluginUtils.ProcessRequestDto<ApplyCustomRequestDto>(config.MerchantNo, config.AesKey, config.SignKey, model);

            //logger.InfoFormat("【合利宝—申报支付单】请求信息Model：{0}", JsonConvert.SerializeObject(model));

            var requestDtoStr = JsonConvert.SerializeObject(requestDto);
            //logger.InfoFormat("【合利宝—申报支付单】请求信息：{0}\r\n{1}", config.ApiUrl, requestDtoStr);

            var result = HLBPluginUtils.DoPost(config.ApiUrl, requestDtoStr);

            //logger.InfoFormat("【合利宝—申报支付单】返回信息：{0}", result);

            var response = JsonConvert.DeserializeObject<HLBDto>(result);

            var resultData = response.ProcessResponse<ApplyCustomResponsetDto>(config.AesKey, config.SignKey);

            //logger.InfoFormat("【合利宝—申报支付单】返回信息Model：{0}", JsonConvert.SerializeObject(resultData));

            return resultData;
        }

        /// <summary>
        /// 申报支付单查询
        /// </summary>
        /// <param name="config"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ApplyCustomQueryResponsetDto ApplyCustomQuery(HLBConfig config, ApplyCustomQueryRequestDto model)
        {
            //var logger = LogHelper.GetLogger("合利宝—申报支付单查询");

            var requestDto = HLBPluginUtils.ProcessRequestDto<ApplyCustomQueryRequestDto>(config.MerchantNo, config.AesKey, config.SignKey, model);

            //logger.InfoFormat("【合利宝—申报支付单查询】请求信息Model：{0}", JsonConvert.SerializeObject(model));

            var requestDtoStr = JsonConvert.SerializeObject(requestDto);
            //logger.InfoFormat("【合利宝—申报支付单查询】请求信息：{0}\r\n{1}", config.ApiUrl, requestDtoStr);

            var result = HLBPluginUtils.DoPost(config.ApiUrl, requestDtoStr);

            //logger.InfoFormat("【合利宝—申报支付单查询】返回信息：{0}", result);

            var response = JsonConvert.DeserializeObject<HLBDto>(result);

            var resultData = response.ProcessResponse<ApplyCustomQueryResponsetDto>(config.AesKey, config.SignKey);

            //logger.InfoFormat("【合利宝—申报支付单查询】返回信息Model：{0}", JsonConvert.SerializeObject(resultData));


            return resultData;
        }
    }
}
