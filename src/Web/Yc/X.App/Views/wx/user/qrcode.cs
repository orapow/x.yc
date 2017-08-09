using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using X.Core.Utility;

namespace X.App.Views.wx.user
{
    public class qrcode : _wx
    {
        protected override void InitDict()
        {
            base.InitDict();

            if (cu.type == 1) Context.Response.Redirect("/wx/user/index.html");//仅商户有邀请二维码

            var qr = new QrEncoder();
            var cd = qr.Encode("http://" + cfg.domain + "/wx/invite-" + cu.id + "-" + cu.no + ".html");
            var rd = new GraphicsRenderer(new FixedModuleSize(15, QuietZoneModules.Two));

            using (var ms = new MemoryStream())
            {
                rd.WriteToStream(cd.Matrix, ImageFormat.Jpeg, ms);
                dict.Add("qr", Convert.ToBase64String(ms.ToArray()));
            }
        }
    }
}
