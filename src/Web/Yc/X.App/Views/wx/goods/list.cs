using System.Linq;
namespace X.App.Views.wx.goods
{
    public class list : _wx
    {
        protected override bool nd_user
        {
            get
            {
                return false;
            }
        }
        protected override void InitDict()
        {
            base.InitDict();
            dict.Add("gs", DB.x_goods.Where(o => o.status == 2).Select(o => new
            {
                id = o.goods_id,
                o.cover,
                title = o.name,
                price = o.new_price
            }).ToList());
        }
    }
}
