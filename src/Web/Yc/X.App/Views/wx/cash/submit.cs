using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Core.Utility;

namespace X.App.Views.wx.cash
{
    public class submit : _wx
    {
        protected override void InitDict()
        {
            base.InitDict();
            dict.Add("ce", cu.exp - cu.used_exp);
        }
    }
}
