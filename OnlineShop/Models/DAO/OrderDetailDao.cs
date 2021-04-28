using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.DAO
{
    /// <summary>
    /// chi tiết hóa đơn
    /// </summary>
    /// createdby:dvquan
    public class OrderDetailDao
    {
        OnlineShopDbContext db = null;

        /// <summary>
        /// khởi tạo
        /// </summary>
        public OrderDetailDao()
        {
            db = new OnlineShopDbContext();
        }

        /// <summary>
        /// thêm chi tiết hóa đơn
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        /// createdby:dvquan
        public bool Insert(OrderDetail detail)
        {
            try
            {
                db.OrderDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}
