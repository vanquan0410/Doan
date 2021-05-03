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
    /// <summary>
    /// StatisticalDAO
    /// </summary>
    /// createdby:dvquan
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

        /// <summary>
        /// lấy tất cả danh sách đơn hàng có phân trang
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<StatisticalViewModel> ListAllPaging(DateTime? start, DateTime? end, int page, int pageSize)
        {
            var model2 = (from a in db.Orders
                          join b in db.OrderDetails
                          on a.ID equals b.OrderID
                          join c in db.Products
                          on b.ProductID equals c.ID
                          select new
                          {
                              ID = b.OrderID,
                              Pirce = b.Price,
                              CreatedDate = a.CreatedDate,
                              ShipName = a.ShipName,
                              ShipEmail = a.ShipEmail,
                              ShipMobile = a.ShipMobile,
                              Name = c.Name,
                              Code = c.Code,
                              Quantity = c.Quantity

                          }).AsEnumerable().Select(x => new StatisticalViewModel()
                          {
                              ID = x.ID,
                              PromotionPrice = x.Pirce,
                              CreatedDate = x.CreatedDate,
                              Name = x.Name,
                              Code = x.Code,
                              Quantity = (int)x.Quantity,
                              ShipName = x.ShipName


                          });
            if (!string.IsNullOrEmpty(start.ToString()) && !string.IsNullOrEmpty(end.ToString()))
            {
                model2 = model2.Where(x => (x.CreatedDate >= start) && (x.CreatedDate <= end));
            }
            return model2.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
            /*return model2.ToList();*/
        }

        /// <summary>
        /// lấy danh sách thống kê ko phân trang
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public IEnumerable<StatisticalViewModel> ListAllStatistical(DateTime? start, DateTime? end)
        {
            var model2 = (from a in db.Orders
                          join b in db.OrderDetails
                          on a.ID equals b.OrderID
                          join c in db.Products
                          on b.ProductID equals c.ID
                          select new
                          {
                              ID = b.OrderID,
                              Pirce = b.Price,
                              CreatedDate = a.CreatedDate,
                              ShipName = a.ShipName,
                              ShipEmail = a.ShipEmail,
                              ShipMobile = a.ShipMobile,
                              Name = c.Name,
                              Code = c.Code,
                              Quantity = c.Quantity

                          }).AsEnumerable().Select(x => new StatisticalViewModel()
                          {
                              ID = x.ID,
                              PromotionPrice = x.Pirce,
                              CreatedDate = x.CreatedDate,
                              Name = x.Name,
                              Code = x.Code,
                              Quantity = (int)x.Quantity,
                              ShipName = x.ShipName,
                              Email=x.ShipEmail,
                              Phone=x.ShipMobile,
                          });
            if (!string.IsNullOrEmpty(start.ToString()) && !string.IsNullOrEmpty(end.ToString()))
            {
                model2 = model2.Where(x => (x.CreatedDate >= start) && (x.CreatedDate <= end));
            }
            return model2.OrderByDescending(x => x.CreatedDate);
        }


    }
}
