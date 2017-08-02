using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Web;

namespace X.App.Views.wx.user
{
    public class subuser : _wx
    {
        public long up { get; set; }
        public int lv { get; set; }
        protected override string GetParmNames
        {
            get
            {
                return "up-lv";
            }
        }
        protected override void InitView()
        {
            base.InitView();
            if (lv == 0) up = cu.id;
            if (cu.id != getid(up, lv)) throw new XExcep("T参数错误");
        }

        long? getid(long? id, int lv)
        {
            var u = DB.x_user.FirstOrDefault(o => o.user_id == id);
            if (u == null) return 0;
            if (lv == 0) return u.id;
            return getid(u.invter, lv - 1);
        }

        protected override void InitDict()
        {
            base.InitDict();
            if (up > 0 && up != cu.id) dict.Add("upuser", DB.x_user.FirstOrDefault(o => o.user_id == up));
            dict.Add("nlv", lv + 1);
            dict.Add("plv", lv - 1);
            dict.Add("items", DB.x_user.Where(o => o.invter == up).Select(o => new { o.headimg, o.id, o.nickname }));
        }
    }
}
