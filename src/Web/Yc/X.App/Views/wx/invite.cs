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

        public string no { get; set; }

        protected override string GetParmNames
        {
            get
            {
                return "uid-no";
            }
        }
        protected override void InitView()
        {
            base.InitView();
            if (cu.invter == 0 && uid > 0)
            {
                var u = DB.x_user.FirstOrDefault(o => o.user_id == uid);
                if (u != null)
                {
                    cu.invter = u.id;
                    SubmitDBChanges();
                }
            }
            Context.Response.Redirect("/wx/goods/list.html");
        }
    }
}
