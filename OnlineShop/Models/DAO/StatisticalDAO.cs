using Models.EF;
using Models.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class StatisticalDAO
    {

        OnlineShopDbContext db = null;
        /// <summary>
        /// khởi tạo
        /// </summary>
        public StatisticalDAO()
        {
            db = new OnlineShopDbContext();
        }


        public IEnumerable<StatisticalViewModel> ListAllPaging(string searchString, int page, int pageSize)
        {
            var model2 = (from a in db.Orders
                          join b in db.OrderDetails
                          on a.ID equals b.OrderID
                          select new
                          {
                              ID = b.OrderID,
                              Pirce = b.Price,
                              CreatedDate = a.CreatedDate,
                              ShipEmail = a.ShipEmail,
                              ShipMobile = a.ShipMobile
                          }).AsEnumerable().Select(x => new StatisticalViewModel()
                          {
                              ID = x.ID,
                              PromotionPrice = x.Pirce,
                              CreatedDate = x.CreatedDate,

                          });
            model2.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
            return model2.ToList();
        }
    }
}
