using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.DAO
{
    /// <summary>
    /// lớp footer tương tác với csdl
    /// </summary>
    /// createdby:dvquan
    public class FooterDao
    {
        OnlineShopDbContext db = null;
        /// <summary>
        /// khỏi tạo 
        /// </summary>
        public FooterDao()
        {
            db = new OnlineShopDbContext();
        }

        /// <summary>
        /// lấy thông tin footer
        /// </summary>
        /// <returns></returns>
        /// createdby:dvquan
        public Footer GetFooter()
        {
            return db.Footers.SingleOrDefault(x => x.Status == true);
        }
    }
}
