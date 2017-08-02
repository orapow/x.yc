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
        }
    }
}
