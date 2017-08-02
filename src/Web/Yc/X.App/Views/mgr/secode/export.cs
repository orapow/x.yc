using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.mgr.secode
{
    public class export : xmg
    {
        public int bat { get; set; }
        protected override string GetParmNames
        {
            get
            {
                return "bat";
            }
        }
        protected override int powercode
        {
            get
            {
                return 1;
            }
        }
        protected override void InitView()
        {
            base.InitView();
            Context.Response.ContentType = "application/vnd.ms-excel";
            Context.Response.Headers.Add("Content-Disposition", "attachment;filename=" + Context.Server.UrlEncode("批次【" + bat + "】防伪码") + ".xls");
        }
        protected override void InitDict()
        {
            base.InitDict();
            dict.Add("ses", DB.x_secode.Where(o => o.batch == bat).Select(o => o.outcode).ToList());
        }
    }
}
