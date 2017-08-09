using System;
using System.Linq;
using X.Core.Utility;
using X.Web;
using X.Web.Com;

namespace X.App.Apis.mgr.user
{
    /// <summary>
    /// 设置属性
    /// </summary>
    public class audit : xmg
    {
        public int id { get; set; }
        public int st { get; set; }
        public string remark { get; set; }

        protected override int powercode
        {
            get
            {
                return 1;
            }
        }

        protected override XResp Execute()
        {
            var u = DB.x_user.FirstOrDefault(o => o.user_id == id);
            if (u == null) throw new XExcep("T商户不存在");
            if (u.audit != 1) throw new XExcep("T商户不在待审状态");

            if (st == 1) { u.audit = 2; u.type = 2; }
            else if (st == 2) u.audit = 3;

            u.remark = remark;
            u.atime = DateTime.Now;

            SubmitDBChanges();

            return new XResp();
        }

    }
}
