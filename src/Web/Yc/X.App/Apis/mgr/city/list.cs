using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using X.Data;
using X.Web.Com;

namespace X.App.Apis.mgr.city
{
    public class list : xmg
    {
        public string up { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
        public string key { get; set; }

        protected override int powercode
        {
            get
            {
                return 1;
            }
        }

        protected override XResp Execute()
        {
            var r = new Resp_List();

            if (up != "0")
            {
                var d = DB.x_dict.FirstOrDefault(o => o.code == "sys.city" && o.value == up);
                if (d.upval != "0") up = d.upval + "-" + d.value;
            }
            var q = DB.x_dict.Where(o => o.code == "sys.city" && o.upval == up);
            if (!string.IsNullOrEmpty(key)) q = q.Where(o => o.jp.Contains(key) || o.name.Contains(key));

            r.items = q.Skip((page - 1) * limit).Take(limit).ToList();
            r.page = page;
            r.count = q.Count();

            return r;
        }

    }
}
