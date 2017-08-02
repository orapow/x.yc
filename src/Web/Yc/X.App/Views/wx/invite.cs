using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Data;

namespace X.App.Views.wx
{
    public class invite : _wx
    {
        public int uid { get; set; }
        protected override string GetParmNames
        {
            get
            {
                return "uid";
            }
        }
        protected override void InitView()
        {
            base.InitView();
            if (cu.invter == 0 && uid > 0)
            {
                cu.invter = uid;
                SubmitDBChanges();
                Context.Response.Redirect("/wx/goods/list.html");
            }
        }
    }
}
