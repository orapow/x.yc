﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Core.Utility;

namespace X.App.Views.wx.order
{
    public class list : _wx
    {
        public int st { get; set; }
        protected override string GetParmNames
        {
            get
            {
                return "st";
            }
        }

        int c = 0;

        protected override void InitDict()
        {
            base.InitDict();
            var ods = cu.x_order.Select(o => new
            {
                id = o.order_id,
                gs = o.x_order_detail.Select(d => new { d.name, d.cover }),
                o.rec_man,
                refund = o.x_refund.OrderByDescending(i => i.ctime).FirstOrDefault(),
                o.status,
                o.rec_tel,
                o.no,
                o.ctime,
                o.iscancel,
                o.isrefund,
                o.rec_addr,
                o.yf_amount
            });

            if (st > 0)
                ods = ods.Where(o => (o.isrefund != true && o.iscancel != true && o.status == st));

            c = ods.Count();
            if (c > 0) dict.Add("ods", ods.OrderByDescending(o => o.ctime));
            else
            {
                dict.Add("img", "/img/wx/uig.png");
                dict.Add("msg", "您还没有订单");
                dict.Add("bt_txt", "去下单");
                dict.Add("bt_url", "/wx/goods/list.html");
            }
        }
        public override string GetTplFile()
        {
            if (c == 0) return "wx/no";
            return base.GetTplFile();
        }
    }
}
