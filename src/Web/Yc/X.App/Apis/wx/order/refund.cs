using System;
using System.Linq;
using X.Data;
using X.Web;
using X.Web.Com;

namespace X.App.Apis.wx.order
{
    public class refund : _wx
    {
        [ParmsAttr(name = "订单id", min = 1)]
        public int id { get; set; }
        public String reason { get; set; }

        protected override XResp Execute()
        {
            var od = cu.x_order.FirstOrDefault(o => o.order_id == id);
            if (od == null) throw new XExcep("订单不存在");
            if (od.status != 2) throw new XExcep("T订单已经发货不能退款");

            var refundItem = new x_refund();

            od.isrefund = true;
            refundItem.amount = cu.x_order.FirstOrDefault(o => o.order_id == id).pay_amount;//默认用户全款申请
            refundItem.ctime = DateTime.Now;
            refundItem.reason = reason;
            refundItem.rsource = (od.pay_way == 1 ? "微信支付" : "帐号余额");
            refundItem.x_order = od;
            refundItem.status = 1;

            od.x_refund.Add(refundItem);

            SubmitDBChanges();
            return new XResp();

        }
    }
}
