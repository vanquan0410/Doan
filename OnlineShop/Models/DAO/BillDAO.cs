using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    /// <summary>
    /// hóa đơn
    /// </summary>
    public class BillDAO
    {
        OnlineShopDbContext db = null;
        public BillDAO()
        {
            db = new OnlineShopDbContext();
        }

        //lấy danh sách đơn hàng
    }
}
