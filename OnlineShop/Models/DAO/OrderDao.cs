using System;
using Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using System.Collections;
using PagedList;
using PagedList.Mvc;
using Common;

namespace Models.DAO
{
    /// <summary>
    /// OrderDao
    /// </summary>
    /// createdby:dvquan
    public class OrderDao
    {
        OnlineShopDbContext db = null;
        /// <summary>
        /// khởi tạo
        /// </summary>
        public OrderDao()
        {
            db = new OnlineShopDbContext();
        }
        /// <summary>
        /// thêm vào cơ sở dl
        /// </summary>
        /// <param name="order"></param>
        /// <returns>order.ID</returns>
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }


        public IEnumerable<Order> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Order> model = db.Orders;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ShipAddress.Contains(searchString) || x.ShipEmail.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public int ChangeStatusTrue(long id)
        {
            var order = db.Orders.Find(id);
            order.Status = 1;
            db.SaveChanges();
            return 1;
        }



    }
}
