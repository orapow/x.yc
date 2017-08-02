using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Web.Com;

namespace X.App.Apis.wx.user
{
    public class save : _wx
    {
        public string name { get; set; }
        public string area { get; set; }
        public string card { get; set; }
        public string cert { get; set; }

        protected override XResp Execute()
        {
            cu.name = name;
            cu.area = area;
            cu.card = card;
            cu.certificate = cert;

            SubmitDBChanges();
            return new XResp();
        }
    }
}
