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
    /// createdby:dvquan
    public class BillDAO
    {

        OnlineShopDbContext db = null;

        /// <summary>
        /// khởi tạo
        /// </summary>
        /// createdby:dvquan
        public BillDAO()
        {
            db = new OnlineShopDbContext();
        }

        //lấy danh sách đơn hàng
    }
}
