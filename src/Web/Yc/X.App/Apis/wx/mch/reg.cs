using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Core.Utility;
using X.Web.Com;

namespace X.App.Apis.wx.mch
{
    public class reg : _wx
    {
        [ParmsAttr(name = "姓名", req = true)]
        public string name { get; set; }

        [ParmsAttr(name = "区域", req = true)]
        public string area { get; set; }

        [ParmsAttr(name = "手持身份证", req = true)]
        public string card { get; set; }

        [ParmsAttr(name = "营业执照", req = true)]
        public string cert { get; set; }

        protected override XResp Execute()
        {
            while (true)
            {
                var no = Tools.GetRandRom(4, 3).ToUpper();
                if (DB.x_user.Count(o => o.no == no) > 0) continue;
                cu.no = no;
                break;
            }

            cu.audit = 1;
            cu.type = 2;
            cu.area = area;
            cu.name = name;
            cu.card = card;
            cu.certificate = cert;
            cu.atime = DateTime.Now;

            SubmitDBChanges();

            return new XResp();
        }
    }
}
