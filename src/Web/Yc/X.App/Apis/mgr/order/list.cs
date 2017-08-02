using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Web.Com;

namespace X.App.Apis.mgr.order
{
    public class list : xmg
    {
        public int page { get; set; }
        public int limit { get; set; }
        public int st { get; set; }
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
            var q = from o in DB.x_order
                    select o;

            if (st > 0)
                q = q.Where(o => o.status == st && o.iscancel != true && o.isrefund != true);

            if (!string.IsNullOrEmpty(key)) q = q.Where(o => o.no == key || o.user_remark.Contains(key) || o.rec_man.Contains(key) || o.rec_tel.Contains(key));

            r.count = q.Count();

            var sts = "|待付款|待发货|待签收|已完成".Split('|');
            r.items = q.OrderByDescending(o => o.ctime).Skip((page - 1) * limit).Take(limit).ToList().Select(o => new
            {
                id = o.order_id,
                uid = o.user_id,
                un = o.x_user.nickname,
                up = o.x_user.headimg,
                gs = string.Join(" ", o.x_order_detail.Select(d => "<img src='" + d.cover + "' class='gd' title='" + d.name + "' />").ToArray()),
                o.no,
                way = o.pay_way == 1 ? "在线支付" : "货到付款",
                o.rec_man,
                o.rec_tel,
                o.status,
                o.isrefund,
                o.iscancel,
                st_name = o.iscancel == true ? "已取消" : o.isrefund == true ? "退款中" : o.status > 0 && o.status < 5 ? sts[o.status.Value] : "未知：" + o.status,
                o.rec_addr,
                o.yf_amount,
                o.pay_amount,
                o.send_ec,
                o.send_en,
                send_time = o.send_time?.ToString("yyyy-MM-dd HH:mm:ss"),
                ctime = o.ctime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                remark = o.user_remark
            });

            r.page = page;

            return r;
        }

    }
}
