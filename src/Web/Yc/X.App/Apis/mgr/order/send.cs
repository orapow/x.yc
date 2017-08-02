using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Core.Cache;
using X.Data;
using X.Web;
using X.Web.Com;

namespace X.App.Apis.mgr.order
{
    public class send : xmg
    {
        public int id { get; set; }
        public string ec { get; set; }
        public string en { get; set; }

        protected override int powercode
        {
            get
            {
                return 1;
            }
        }

        protected override XResp Execute()
        {
            var od = DB.x_order.FirstOrDefault(o => o.order_id == id);

            if (od == null) throw new XExcep("T订单不存在");
            if (od.status != 2) throw new XExcep("T订单当前状态不能发货");

            od.status = 3;
            od.send_ec = GetDictName("sys.express", ec);
            od.send_en = en;
            od.send_time = DateTime.Now;

            SubmitDBChanges();

            return new XResp();
        }
    }
}
