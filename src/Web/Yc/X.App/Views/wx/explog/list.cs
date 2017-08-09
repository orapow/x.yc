using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.wx.explog
{
    public class list : _wx
    {
        int c = 0;
        protected override void InitView()
        {
            base.InitView();
            var items = cu.x_exp_log.OrderByDescending(o => o.ctime).Select(o => new
            {
                id = o.exp_log_id,
                o.val,
                o.remark,
                o.ctime
            });
            c = items.Count();
            if (c > 0) dict.Add("list", items);
            else
            {
                dict.Add("img", "/img/wx/uig.png");
                dict.Add("msg", "您还没记录变动记录");
            }
        }
        public override string GetTplFile()
        {
            if (c == 0) return "wx/no";
            return base.GetTplFile();
        }
    }
}
