using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.wx
{
    public class check : _wx
    {
        public string no { get; set; }
        protected override string GetParmNames
        {
            get
            {
                return "no";
            }
        }
        protected override void InitView()
        {
            base.InitView();
            if (cu.type == 2) Context.Response.Redirect("/wx/user/index.html");
        }
    }
}
