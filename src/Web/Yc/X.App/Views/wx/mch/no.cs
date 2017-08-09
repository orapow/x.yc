using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.wx.mch
{
    public class no : _wx
    {
        protected override void InitView()
        {
            base.InitView();
            if (cu.audit == 1 || cu.audit == 3) Context.Response.Redirect("/wx/mch/audit.html");
            else if (cu.audit == 2) Context.Response.Redirect("/wx/user/index.html");
        }
    }
}
