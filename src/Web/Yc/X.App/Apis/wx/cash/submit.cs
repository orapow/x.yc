using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Data;
using X.Web;
using X.Web.Com;

namespace X.App.Apis.wx.cash
{
    public class submit : _wx
    {
        public decimal val { get; set; }

        protected override XResp Execute()
        {
            var ce = cu.exp - cu.used_exp;
            if (val <= 0) throw new XExcep("T兑换积分要大于0");
            if (ce <= 0 || ce < val) throw new XExcep("T您的积分不够，请刷新后重新输入可兑换的积分额度。");

            cu.used_exp += val;

            var lg = new x_cash_log()
            {
                amount = val * cfg.credit,//转换成金额
                ctime = DateTime.Now,
                remark = "",
                status = 1
            };
            cu.x_cash_log.Add(lg);
            SubmitDBChanges();
            return new XResp();
        }
    }
}
