using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.mgr
{
    public class main : xmg
    {

        public int st { get; set; }
        protected override string GetParmNames
        {
            get
            {
                return "st";
            }
        }
        protected override void InitDict()
        {
            base.InitDict();
            dict.Add("refundCount", DB.x_refund.Where(o => o.status == 1).Count());
            dict.Add("sendCount", DB.x_order.Where(o => o.status == 2).Count());//待发货
            if (cfg.cash_audit == 1) dict.Add("auditCount", DB.x_cash_log.Where(o => o.status == 1).Count());
        }
    }
}
