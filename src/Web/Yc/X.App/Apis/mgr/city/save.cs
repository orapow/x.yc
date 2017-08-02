using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Core.Cache;
using X.Data;
using X.Web;
using X.Web.Com;

namespace X.App.Apis.mgr.city
{
    public class save : xmg
    {
        public int upv { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int sort { get; set; }
        public string jp { get; set; }
        public string no { get; set; }
        public int val { get; set; }

        string code = "sys.city";
        protected override int powercode
        {
            get
            {
                return 1;
            }
        }

        protected override XResp Execute()
        {
            x_dict ent = null;

            if (id > 0) ent = DB.x_dict.FirstOrDefault(o => o.dict_id == id);
            if (ent == null) ent = new x_dict() { code = code };

            ent.name = name;
            ent.sort = sort;
            ent.jp = jp;

            if (upv > 0)
            {
                var up = DB.x_dict.FirstOrDefault(o => o.value == upv + "");
                if (up == null) ent.upval = "0";
                else if (up.upval == "0") ent.upval = up.value;
                else ent.upval = up.upval + "-" + up.value;
            }
            else ent.upval = "0";

            if (ent.dict_id == 0)
                DB.x_dict.InsertOnSubmit(ent);

            if (val == 0)
            {
                SubmitDBChanges();
                ent.value = ent.dict_id + "";
            }
            else
            {
                ent.value = val + "";
            }

            SubmitDBChanges();

            CacheHelper.Remove("dict." + ent.code);

            return new XResp();
        }
    }
}
