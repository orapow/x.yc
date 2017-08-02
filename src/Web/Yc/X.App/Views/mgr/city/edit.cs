using System.Linq;
using X.Web;

namespace X.App.Views.mgr.city
{
    public class edit : xmg
    {
        public int id { get; set; }
        public int pid { get; set; }
        protected override int powercode
        {
            get
            {
                return 1;
            }
        }


        protected override string GetParmNames
        {
            get
            {
                return "id-pid";
            }
        }
        protected override void InitDict()
        {
            base.InitDict();
            var upv = "";
            if (id > 0)
            {
                var ent = DB.x_dict.FirstOrDefault(o => o.dict_id == id);
                if (ent == null) throw new XExcep("0x0005");
                dict.Add("item", ent);
                upv = ent.upval;
            }

            if (pid > 0)
            {
                var up = DB.x_dict.FirstOrDefault(o => o.value == pid + "");
                if (up != null)
                {
                    if (up.upval == "0") upv = up.value;
                    else upv = up.upval + "-" + up.value;
                }
            }

            if (!string.IsNullOrEmpty(upv))
            {
                dict.Add("ups", DB.x_dict.Where(o => o.code == "sys.city" && upv.Split('-').Contains(o.value)).ToList());
            }

        }
    }
}
