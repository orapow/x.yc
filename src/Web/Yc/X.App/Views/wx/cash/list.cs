using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.wx.cash
{
    public class list : _wx
    {
        int c = 0;
        protected override void InitView()
        {
            base.InitView();
            var items = cu.x_cash_log.OrderByDescending(o => o.ctime).Select(o => new
            {
                id = o.cash_log_id,
                st_name = o.status == 3 ? "已拒绝" : (o.status == 2 ? "已同意" : "待审核"),
                o.status,
                amount = o.amount?.ToString("F2"),
                ctime = o.ctime?.ToString("yyyy-MM-dd HH:mm:ss"),
                o.remark
            });
            c = items.Count();
            if (c > 0) dict.Add("list", items);
            else
            {
                dict.Add("img", "/img/wx/uig.png");
                dict.Add("msg", "您还没有兑换记录");
                dict.Add("bt_txt", "去兑换");
                dict.Add("bt_url", "/wx/cash/submit.html");
            }
        }
        public override string GetTplFile()
        {
            if (c == 0) return "wx/no";
            return base.GetTplFile();
        }
    }
}
