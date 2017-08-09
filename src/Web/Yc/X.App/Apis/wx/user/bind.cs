﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Core.Cache;
using X.Web;
using X.Web.Com;

namespace X.App.Apis.wx.user
{
    public class bind : _wx
    {
        [ParmsAttr(name = "短信验证码", req = true)]
        public string code { get; set; }
        [ParmsAttr(name = "电话号码", req = true)]
        public string tel { get; set; }
        protected override XResp Execute()
        {
            var mcode = CacheHelper.Get<string>("sms.code." + tel);
            if (string.IsNullOrEmpty(mcode) || mcode != code) throw new XExcep("T验证码不正确");
            CacheHelper.Remove("sms.code." + tel);

            cu.tel = tel;
            SubmitDBChanges();

            return new XResp();
        }
    }
}
