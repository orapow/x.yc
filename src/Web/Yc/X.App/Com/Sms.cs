using System;
using System.Text.RegularExpressions;
using X.Core.Plugin;
using X.Core.Utility;

namespace X.App.Com
{
    public class Sms
    {
        public static string SendSms(string to, string content)
        {
            var url = "http://smssh1.253.com/msg/send/json";
            try
            {
                var mb = new
                {
                    account = "N6664837",
                    password = "6ryS3cDq9M1d96",
                    msg = System.Web.HttpUtility.UrlEncode("【253云通讯】" + content),
                    phone = to
                };
                return Tools.PostHttpData(url, Serialize.ToJson(mb));
            }
            catch (Exception ex)
            {
                Loger.Error(String.Format("{0:yyyy-MM-dd hh:mm:ss}，{1}", DateTime.Now, ex.Message));
                return ex.Message;
            }
        }
    }
}
