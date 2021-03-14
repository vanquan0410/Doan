using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
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
    }
}
