using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.wx.mch
{
    public class reg : _wx
    {
        protected override void InitView()
        {
            base.InitView();
            if ((cu.audit > 0 || cu.type == 2) && cu.audit != 3) Context.Response.Redirect("/wx/mch/audit.html");
            if (string.IsNullOrEmpty(cu.tel))
            {
                dict.Add("img", "/img/wx/bphone.png");
                dict.Add("msg", "您还没有绑定手机号码");
                dict.Add("bt_txt", "去绑定");
                dict.Add("bt_url", "/wx/user/bind.html");
            }
        }
        public override string GetTplFile()
        {
            if (string.IsNullOrEmpty(cu.tel)) return "wx/no";
            return base.GetTplFile();
        }
    }
}
