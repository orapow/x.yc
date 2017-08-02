using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using X.Core.Utility;
using X.App;
using X.App.Com;
using X.Web.Com;
using X.Web;

namespace X.App.Apis.mgr
{
    public class setup : xmg
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
        public int refdays { get; set; }
        /// <summary>
        /// 现金审核
        /// </summary>
        public int cash_audit { get; set; }
        public decimal min_cash { get; set; }
        public decimal max_cash { get; set; }

        #region 等级提佣
        public decimal l0 { get; set; }
        public decimal l1 { get; set; }
        public decimal l2 { get; set; }
        public decimal l3 { get; set; }
        public decimal l4 { get; set; }
        public decimal l5 { get; set; }
        public decimal l6 { get; set; }
        public decimal l7 { get; set; }
        public decimal l8 { get; set; }
        public decimal l9 { get; set; }
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
        protected override Web.Com.XResp Execute()
        {
            cfg = Config.LoadConfig();
            cfg.domain = domain;
            cfg.name = name;
            cfg.stel = stel;
            cfg.credit = credit;
            cfg.refdays = refdays;

            cfg.cash_min = min_cash;
            cfg.cash_max = max_cash;
            cfg.cash_audit = cash_audit;

            cfg.wx_appid = wx_appid;
            cfg.wx_certpath = wx_certpath;
            cfg.wx_mch_id = wx_mch_id;
            cfg.wx_paykey = wx_paykey;
            cfg.wx_scr = wx_scr;

            cfg.free_ship = free_ship;
            cfg.shipfee = shipfee;

            cfg.brate = brate;
            cfg.mrate = mrate;

            cfg.lv_cent = new decimal[10] { l0, l1, l2, l3, l4, l5, l6, l7, l8, l9 };

            Config.SaveConfig(cfg);
            return new XResp();
        }
    }
}
