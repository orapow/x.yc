using System.Linq;

namespace X.App.Views.wx.user
{
    public class index : _wx
    {
        protected override void InitView()
        {
            base.InitView();

            dict.Add("o1", cu.x_order.Count(o => o.status == 1 && o.iscancel != true));
            dict.Add("o2", cu.x_order.Count(o => o.status == 2 && o.isrefund != true));
            dict.Add("o3", cu.x_order.Count(o => o.status == 3 && o.isrefund != true));

        }
    }
}
