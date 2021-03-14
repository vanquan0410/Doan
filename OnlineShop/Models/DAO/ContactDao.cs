using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    /// <summary>
    /// lớp contactDao
    /// </summary>
    /// CreatedBy:DVquan(05/3/2021)
    public class ContactDao
    {
        OnlineShopDbContext db = null;
        /// <summary>
        /// khởi tạo
        /// </summary>
        public ContactDao()
        {
            db = new OnlineShopDbContext();
        }

        /// <summary>
        /// lấy thông tin contact đang hoạt động
        /// </summary>
        /// <returns>thông tin contact</returns>
        /// CreatedBy:DVquan(05/3/2021)
        public Contact GetActiveContact()
        {
            return db.Contacts.Single(x => x.Status == true);
        }

        /// <summary>
        /// thêm FeedBack
        /// </summary>
        /// <param name="fb">FeedBack</param>
        /// <returns>id của FeedBack</returns>
        /// CreatedBY:DVquan(05/3/2021)
        public int InsertFeedBack(Feedback fb)
        {
            db.Feedbacks.Add(fb);
            db.SaveChanges();
            return fb.ID;
        }
    }
}
