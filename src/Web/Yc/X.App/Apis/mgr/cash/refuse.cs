using System;
using System.Linq;
using X.Web;
using X.Web.Com;

namespace X.App.Apis.mgr.cash
{
    public class refuse : xmg
    {
        public int id { get; set; }
        public string reason { get; set; }
        protected override int powercode
        {
            get
            {
                return 1;
            }
        }

        protected override XResp Execute()
        {
            var cit = DB.x_cash_log.FirstOrDefault(o => o.cash_log_id == id);
            if (cit == null) throw new XExcep("T提现记录不存在");
            if (cit.status != 1) throw new XExcep("T提现记录当前不在待审状态");

            cit.status = 3;
            cit.atime = DateTime.Now;
            cit.remark = "审核人：" + mg.name + "审核时间：" + DateTime.Now + "，拒绝申请，原因：" + reason;
            SubmitDBChanges();

            return new XResp();
        }
    }
}
