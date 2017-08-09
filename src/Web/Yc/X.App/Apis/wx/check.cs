using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.App.Com;
using X.Web.Com;

namespace X.App.Apis.wx
{
    public class check : _wx
    {
        public string no { get; set; }

        protected override XResp Execute()
        {
            var r = new back();
            var sc = DB.x_secode.FirstOrDefault(o => o.outcode == no);
            if (sc == null) { r.ct = -1; }
            else if (sc.user_id > 0)
            {
                if (sc.user_id == cu.user_id) r.self = true;
                r.lt = sc.stime?.ToString("yyyy-MM-dd HH:mm:ss");
                r.ct = sc.scount ?? 0;
                sc.scount = r.ct + 1;
                sc.stime = DateTime.Now;
            }
            else
            {
                r.self = true;
                sc.user_id = cu.user_id;
                sc.stime = DateTime.Now;
                sc.scount = 1;
            }
            SubmitDBChanges();
            return r;
        }

        class back : XResp
        {
            public int ct { get; set; }
            public string lt { get; set; }
            public bool self { get; set; }
        }
    }
}
