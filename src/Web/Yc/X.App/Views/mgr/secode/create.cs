using System;
using System.Collections.Generic;
using System.Linq;
using X.Web;

namespace X.App.Views.mgr.secode
{
    public class create : xmg
    {
        protected override void InitDict()
        {
            base.InitDict();
            dict.Add("batch", DateTime.Now.ToString("yyyyMMdd"));
        }
    }
}
