using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Web;

namespace X.App.Views.mgr.mch
{
    public class audit : xmg
    {
        public int id { get; set; }
        protected override int powercode
        {
            get
            {
                return 1;
            }
        }

        protected override string GetParmNames
        {
            get
            {
                return "id";
            }
        }
        protected override void InitDict()
        {
            base.InitDict();
            if (id > 0)
            {
                var u = DB.x_user.SingleOrDefault(o => o.user_id == id);
                if (u == null) throw new XExcep("0x0005");
                dict.Add("item", u);
            }
        }
    }
}
