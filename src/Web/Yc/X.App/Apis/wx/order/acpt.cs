using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.App.Com;
using X.Core.Cache;
using X.Core.Utility;
using X.Data;
using X.Web;
using X.Web.Com;

namespace X.App.Apis.wx.order
{
    public class acpt : _wx
    {
        [ParmsAttr(name = "订单id", min = 1)]
        public int id { get; set; }

        protected override XResp Execute()
        {
            var od = cu.x_order.FirstOrDefault(o => o.order_id == id);
            if (od.status != 3) throw new XExcep("T订单当前状态不能收货");

            od.status = 4;

            SubmitDBChanges();
            return new XResp();

        }
    }
}
