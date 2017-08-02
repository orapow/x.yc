using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.mgr.lottery
{
    public class edit : xmg
    {
        public int id { get; set; }
        protected override string GetParmNames
        {
            get
            {
                return "id";
            }
        }
        protected override void InitDict()
        {
            base.InitDict();
            if (id > 0)
            {
                var ent = DB.x_lottery.SingleOrDefault(o => o.lottery_id == id);
                dict.Add("item", ent);
                if (ent.runtp == 2)
                {
                    var tj = "";
                    foreach (var r in ent.rules.Split(','))
                    {
                        var _r = r.Split('-');
                        if (_r[0] == "1") { tj += "[1]"; dict.Add("hc", _r[1]); }
                        if (_r[0] == "2") { tj += "[2]"; dict.Add("oc", _r[1]); }
                        if (_r[0] == "3") { tj += "[3]"; dict.Add("ac", _r[1]); }
                    }
                    dict.Add("tj", tj);
                }
            }
        }
    }
}
