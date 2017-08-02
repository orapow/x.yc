using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Data;
using X.Web.Com;

namespace X.App.Apis.wx.addr
{
    public class save : _wx
    {
        public int id { get; set; }
        public int p { get; set; }
        public int c { get; set; }
        public int x { get; set; }
        public int s { get; set; }
        public string name { get; set; }
        public string tel { get; set; }
        public string addr { get; set; }
        protected override XResp Execute()
        {
            x_address ad = null;
            if (id > 0) ad = cu.x_address.FirstOrDefault(o => o.address_id == id);
            if (ad == null) ad = new x_address() { ctime = DateTime.Now, user_id = cu.id };

            ad.sheng = GetDictName("sys.city", p);
            ad.shi = GetDictName("sys.city", c);
            ad.qu = GetDictName("sys.city", x);
            ad.zhen = GetDictName("sys.city", s);
            ad.tel = tel;
            ad.addr = addr;
            ad.name = name;

            if (ad.address_id == 0) DB.x_address.InsertOnSubmit(ad);
            SubmitDBChanges();

            return new XResp() { msg = ad.address_id + "" };
        }
    }
}
