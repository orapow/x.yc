using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Data;
using X.Web;
using X.Web.Com;

namespace X.App.Apis.wx.cash
{
    public class del : _wx
    {
        public long id { get; set; }

        protected override XResp Execute()
        {
            var c = cu.x_cash_log.FirstOrDefault(o => o.cash_log_id == id);
            if (c == null) throw new XExcep("T兑换记录不存在");

            DB.x_cash_log.DeleteOnSubmit(c);
            SubmitDBChanges();

            return new XResp();
        }
    }
}
