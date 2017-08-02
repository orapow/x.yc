using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using X.Core.Utility;

namespace X.App.Com
{
    /// <summary>
    /// 常规配置
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 域名
        /// </summary>
        public string domain { get; set; }
        /// <summary>
        /// 网站名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 服务电话
        /// </summary>
        public string stel { get; set; }
        /// <summary>
        /// 缓存设置
        /// 1、memcached
        /// 2、WebCached
        /// </summary>
        public int cache { get; set; }

        #region 微信配置
        public string wx_appid { get; set; }
        public string wx_scr { get; set; }
        public string wx_mch_id { get; set; }
        /// <summary>
        /// 微信证书路径
        /// </summary>
        public string wx_certpath { get; set; }
        /// <summary>
        /// 微信支付Key
        /// </summary>
        public string wx_paykey { get; set; }
        #endregion

        /// <summary>
        /// 积分对应金额
        /// </summary>
        public int credit { get; set; }
        /// <summary>
        /// 退货天数
        /// </summary>
        public int refdays { get; set; }
        /// <summary>
        /// 提现审核
        /// </summary>
        public int cash_audit { get; set; }
        /// <summary>
        /// 最少提现
        /// </summary>
        public decimal cash_min { get; set; }
        /// <summary>
        /// 最多提现
        /// </summary>
        public decimal cash_max { get; set; }

        #region 等级提佣
        public decimal[] lv_cent { get; set; }
        #endregion

        public decimal free_ship { get; set; }
        public decimal shipfee { get; set; }

        /// <summary>
        /// 奖池提取
        /// </summary>
        public decimal brate { get; set; }
        /// <summary>
        /// 基金提取
        /// </summary>
        public decimal mrate { get; set; }

        /// <summary>
        /// 奖金池
        /// </summary>
        public decimal pool_lott { get; set; }
        /// <summary>
        /// 基金池
        /// </summary>
        public decimal pool_fund { get; set; }

        /// <summary>
        /// 订单数累计
        /// </summary>
        public int od_count { get; set; }
        /// <summary>
        /// 订单额累计
        /// </summary>
        public decimal od_amount { get; set; }

        private static string file = HttpContext.Current.Server.MapPath("/dat/cfg.x");//来自服务器的文件
        private static Config cfg = null;
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public static Config LoadConfig()
        {
            if (cfg == null)
            {
                var json = Tools.ReadFile(file);
                if (string.IsNullOrEmpty(json)) return new Config();
                cfg = Serialize.FromJson<Config>(json);
            }
            return cfg;
        }
        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="cfg"></param>
        public static void SaveConfig(Config cfg)
        {
            Tools.SaveFile(HttpContext.Current.Server.MapPath("/dat/cfg.x"), Serialize.ToJson(cfg));
        }

    }
}
