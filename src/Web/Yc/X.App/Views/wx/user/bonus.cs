using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.wx.user
{
    public class bonus : _wx
    {
        int c = 0;
        protected override void InitView()
        {
            base.InitView();
            var items = cu.x_user_prize.OrderByDescending(o => o.ctime).Select(o => new
            {
                id = o.user_prize_id,
                gtime = o.gtime?.ToString("yyyy-MM-dd"),
                o.title,
                o.item,
                o.remark,
                o.val,
                o.prize,
                o.isget,
                ctime = o.ctime?.ToString("yyyy-MM-dd"),
            });
            c = items.Count();
            if (c > 0) dict.Add("list", items);
            else
            {
                dict.Add("img", "/img/wx/uig.png");
                dict.Add("msg", "您还没有中奖记录");
            }
        }
        public override string GetTplFile()
        {
            if (c == 0) return "wx/no";
            return base.GetTplFile();
        }
    }
}
