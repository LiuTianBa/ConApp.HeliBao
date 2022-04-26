using Jzh.PayPlugin.HeLiBao.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Jzh.PayPlugin.HeLiBao
{
    public class HLBPluginUtils
    {
        /// <summary>
        /// 签名字段
        /// </summary>
        public const string SignFiled = "sign";

        private const int Timeout = 100000;

        /// <summary>
        /// 组装请求参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="merchantNo"></param>
        /// <param name="aesKey"></param>
        /// <param name="signKey"></param>
        /// <param name="orderNo"></param>
        /// <param name="productCode"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static HLBDto ProcessRequestDto<T>(string merchantNo, string aesKey, string signKey, T model) where T : HLBRequestBaseDto
        {
            var setting = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            var contentStr = JsonConvert.SerializeObject(model, setting);
            var content = EncryptByAES(contentStr, aesKey);

            var requestDic = ToDic(model);
            var sign = CreateSign(requestDic, signKey);

            var requestDto = new HLBDto()
            {
                content = content,
                sign = sign,
                merchantNo = merchantNo,
                orderNo = model.orderNo,
                productCode = model.productCode
            };
            return requestDto;
        }

        /// <summary>
        /// 创建签名
        /// </summary>
        /// <param name="dictionary">需要签名的字典数据集</param>
        /// <param name="key">私钥</param>
        /// <returns></returns>
        public static string CreateSign(Dictionary<string, string> dictionary, string key)
        {
            var strSign = CreateSignString(dictionary, key);

            //sha256加密
            byte[] SHA256Data = Encoding.UTF8.GetBytes(strSign);
            SHA256Managed Sha256 = new SHA256Managed();
            byte[] Result = Sha256.ComputeHash(SHA256Data);

            return ByteArrayToHexString(Result);
        }

        /// <summary>
        /// 创建签名
        /// </summary>
        /// <param name="dictionary">需要签名的字典数据集</param>
        /// <param name="key">私钥</param>
        /// <returns></returns>
        public static string CreateSign(string source, string key)
        {
            var signstr = string.Concat(key, ',', source, ',', key);
            //sha256加密
            byte[] SHA256Data = Encoding.UTF8.GetBytes(signstr);
            SHA256Managed Sha256 = new SHA256Managed();
            byte[] Result = Sha256.ComputeHash(SHA256Data);
            return ByteArrayToHexString(Result);
        }

        /// <summary>
        /// 将一个byte数组转换成一个格式化的16进制字符串
        /// </summary>
        /// <param name="data">byte数组</param>
        /// <returns>格式化的16进制字符串</returns>
        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
            {
                //16进制数字
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 生成签名字符串
        /// </summary>
        /// <param name="dictionary">需要签名的字典数据集</param>
        /// <param name="key">私钥</param>
        /// <returns></returns>
        public static string CreateSignString(Dictionary<string, string> dictionary, string key)
        {
            if (dictionary.ContainsKey(SignFiled))
            {
                dictionary.Remove(SignFiled);
            }
            //把字典按Key的字母顺序排序
            dictionary = SortDictionary(dictionary);
            var strSign = key + "," + DictionaryToString(dictionary, ',', false) + "," + key;
            return strSign;
        }

        /// <summary>  
        /// AES加密算法  
        /// </summary>  
        /// <param name="input">明文字符串</param>  
        /// <param name="key">密钥（32位）</param>  
        /// <returns>字符串</returns>  
        public static string EncryptByAES(string input, string key)
        {
            //Base64.decode 
            byte[] keyBytes = Convert.FromBase64String(key);
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(input);

            RijndaelManaged rm = new RijndaelManaged
            {
                Key = keyBytes,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateEncryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);

        }

        /// <summary>  
        /// AES解密  
        /// </summary>  
        /// <param name="input">密文字节数组</param>  
        /// <param name="key">密钥（32位）</param>  
        /// <returns>返回解密后的字符串</returns>  
        public static string DecryptByAES(string input, string key)
        {
            try
            {
                byte[] inputBytes = Convert.FromBase64String(input);
                byte[] keyBytes = Convert.FromBase64String(key);

                RijndaelManaged rm = new RijndaelManaged
                {
                    Key = keyBytes,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };

                ICryptoTransform cTransform = rm.CreateDecryptor();
                Byte[] resultArray = cTransform.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                return Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception)
            {
                return input;
            }

        }


        private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        /// <summary>
        /// 执行HTTP POST请求。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>HTTP响应</returns>
        public static String DoPost(String url, string paramUrl)
        {
            var req = (HttpWebRequest)WebRequest.Create(url);
            req.ServicePoint.Expect100Continue = false;
            req.Method = "POST";
            req.KeepAlive = true;
            //req.UserAgent = "InterfaceService.JdSDK.NET V1.0 by StarPeng";
            req.Timeout = Timeout;
            req.ContentType = "application/json;charset=utf-8";
            //var paramUrl = DictionaryToString(parameters, '&', true);
            Byte[] postData = Encoding.UTF8.GetBytes(paramUrl);
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(postData, 0, postData.Length);
            reqStream.Close();

            ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
            var rsp = (HttpWebResponse)req.GetResponse();
            var encoding = Encoding.GetEncoding(rsp.CharacterSet);
            return GetResponseAsString(rsp, encoding);
        }


        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <param name="rsp">响应流对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>响应文本</returns>
        private static String GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            Stream stream = null;
            StreamReader reader = null;

            try
            {
                // 以字符流的方式读取HTTP响应
                stream = rsp.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                return reader.ReadToEnd();
            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (rsp != null) rsp.Close();
            }
        }

        /// <summary>
        /// 把所有参数名和参数值串在一起
        /// </summary>
        /// <param name="dictionary">字典数据集</param>
        /// <param name="separator">分隔符</param>
        /// <param name="isUrlEncode">是否使用UrlEncode编码</param>
        /// <returns></returns>
        public static string DictionaryToString(Dictionary<string, string> dictionary, char separator, bool isUrlEncode)
        {
            var query = new StringBuilder();
            var count = 0;
            var len = dictionary.Keys.Count;
            foreach (var key in dictionary.Keys)
            {
                count++;
                var value = dictionary[key];
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    if (isUrlEncode)
                        value = HttpUtility.UrlEncode(value);
                    if (count != len)
                    {
                        query.AppendFormat("{0}={1}{2}", key, value, separator);
                    }
                    else
                    {
                        query.AppendFormat("{0}={1}", key, value);
                    }
                }
            }

            return query.ToString();
        }

        /// <summary>
        /// 把字典按Key的字母顺序排序
        /// </summary>
        /// <param name="dictionary">字典数据集</param>
        /// <returns></returns>
        public static Dictionary<string, string> SortDictionary(Dictionary<string, string> dictionary)
        {
            Dictionary<string, string> newDic = dictionary.OrderBy(o => o.Key, StringComparer.Ordinal).ToDictionary(o => o.Key, p => p.Value);

            return newDic;
        }

        /// <summary>
        /// 把字典按Key的字母顺序排序
        /// </summary>
        /// <param name="dictionary">字典数据集</param>
        /// <returns></returns>
        public static Dictionary<string, object> SortDictionary(Dictionary<string, object> dictionary)
        {
            Dictionary<string, object> newDic = dictionary.OrderBy(o => o.Key, StringComparer.Ordinal).ToDictionary(o => o.Key, p => p.Value);
            return newDic;
        }

        /// <summary>
        /// 将字典数据集转换为json数据
        /// </summary>
        /// <param name="listPaymentBillArray">字典数据集</param>
        /// <returns></returns>
        public static string DictionaryToJson(List<Dictionary<string, string>> listPaymentBillArray)
        {
            if (listPaymentBillArray == null || listPaymentBillArray.Count < 1)
            {
                return "[]";
            }
            var json = new StringBuilder();
            foreach (var paymentBillArray in listPaymentBillArray)
            {
                var temp = "";
                foreach (var key in paymentBillArray.Keys)
                {
                    temp += string.Format("\"{0}\":\"{1}\",", key, paymentBillArray[key]);
                }
                if (temp.Length > 0)
                {
                    temp = temp.TrimEnd(new[] { ',' });
                    json.Append("{" + temp + "},");
                }

            }
            if (json.Length > 0)
            {
                return "[" + json.ToString().TrimEnd(new[] { ',' }) + "]";
            }
            else
            {
                return "[]";
            }
        }



        /// <summary>
        /// 构造表单提交HTML
        /// </summary>
        /// <param name="dictionary">字典数据集</param>
        /// <param name="isPost">提交方式，是否为post提交</param>
        /// <param name="isSubmit">是否需要提交</param>
        /// <returns>输出 表单提交HTML文本</returns>
        public static string BuildForm(string serviceApiUrlForPay, Dictionary<string, string> dictionary, bool isPost, bool isSubmit)
        {
            var sbHtml = new StringBuilder();
            sbHtml.Append("<div style='display:none;'>");//style='display:none;'

            //提交方式（GET与POST二必选一）
            if (!isPost)
            {
                //GET方式传递
                sbHtml.Append("<form id=\"yjfpaysubmit\" name=\"yjfpaysubmit\" action=\"" + serviceApiUrlForPay +
                               "\" method=\"get\">");
            }
            else
            {
                //POST方式传递
                sbHtml.Append("<form id=\"yjfpaysubmit\" name=\"yjfpaysubmit\" action=\"" + serviceApiUrlForPay +
                               "\" method=\"post\">");
            }
            foreach (KeyValuePair<string, string> temp in dictionary)
            {
                if (!string.IsNullOrEmpty(temp.Key) && !string.IsNullOrEmpty(temp.Value))
                    sbHtml.Append("<input type=\"hidden\" name=\"" + temp.Key + "\" value='" + temp.Value + "'/>");
            }

            //submit按钮控件请不要含有name属性
            sbHtml.Append("<input type=\"submit\" value=\"易极付确认付款\"></form>");
            if (isSubmit)
            {
                sbHtml.Append("<script>document.forms['yjfpaysubmit'].submit();</script>");
            }
            sbHtml.Append("</div>");

            return sbHtml.ToString();
        }


        /// <summary>
        /// 获取易极付GET过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public static Dictionary<string, string> GetDictionaryRequestGet(HttpRequest request)
        {
            //int i = 0;
            var sArray = new Dictionary<string, string>();
            var coll = request.QueryString;

            //var requestItem = coll.AllKeys;

            //for (i = 0; i < requestItem.Length; i++)
            //{
            //    sArray.Add(requestItem[i], request.QueryString[requestItem[i]]);
            //}
            return sArray;
        }


        /// <summary>
        /// 把对象转成字典，用作请求（去除为空的值）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ToDic(object input, List<string> ignores = null)
        {
            Dictionary<string, string> result = null;
            if (input == null)
                return result;

            Type type = input.GetType();
            if (type.IsValueType)
                return result;

            PropertyInfo[] propertyInfoArry = input.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfoArry == null || propertyInfoArry.Length > 0 == false)
                return result;

            result = new Dictionary<string, string>();
            foreach (PropertyInfo propertyInfo in propertyInfoArry)
            {
                string curValue = "";
                if (propertyInfo != null)
                {
                    if (ignores == null)
                        ignores = new List<string>();

                    if (!ignores.Contains(propertyInfo.Name))
                    {
                        object propertyValue = propertyInfo.GetValue(input, null);
                        if (propertyValue != null)
                        {
                            if (propertyValue.GetType().IsGenericType && propertyValue.GetType().GetGenericTypeDefinition().Name == "List`1")
                            {
                                var list = propertyValue as IEnumerable<DetailBaseDto>;
                                list = list.OrderBy(p => p.index).ToList();

                                List<Dictionary<string, object>> disResultList = new List<Dictionary<string, object>>();

                                foreach (var item in list)
                                {
                                    var dic = DetaioToDic(item);
                                    dic = SortDictionary(dic);
                                    disResultList.Add(dic);
                                }
                                curValue = JsonConvert.SerializeObject(disResultList, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });

                                //curValue = propertyValue.GetType().GetGenericTypeDefinition().Name == "List`1" ? JsonConvert.SerializeObject(propertyValue, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }) : propertyValue.ToString();
                            }

                            else
                            {
                                curValue = propertyValue.GetType() == typeof(bool) ? propertyValue.ToString().ToLower() : propertyValue.ToString();
                            }
                            result.Add(propertyInfo.Name, curValue);
                        }
                    }
                }
            }
            return result;
        }


        public static Dictionary<string, string> ToDic(JObject dto)
        {
            var dic = new Dictionary<string, string>();
            foreach (var item in dto)
            {
                dic.Add(item.Key, item.Value.ToString());
            }
            return dic;
        }


        public static Dictionary<string, object> DetaioToDic(object input)
        {
            Dictionary<string, object> result = null;
            if (input == null)
                return result;

            Type type = input.GetType();
            if (type.IsValueType)
                return result;

            PropertyInfo[] propertyInfoArry = input.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfoArry == null || propertyInfoArry.Length > 0 == false)
                return result;

            result = new Dictionary<string, object>();
            foreach (PropertyInfo propertyInfo in propertyInfoArry)
            {
                if (propertyInfo != null)
                {
                    object propertyValue = propertyInfo.GetValue(input, null);
                    if (propertyValue != null)
                    {
                        result.Add(propertyInfo.Name, propertyValue);
                    }
                }
            }
            return result;
        }
    }
}
