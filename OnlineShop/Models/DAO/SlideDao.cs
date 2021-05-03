using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.DAO
{
    /// <summary>
    /// class SlideDao tương tác với cơ sở dl
    /// </summary>
    public class SlideDao
    {
        OnlineShopDbContext db = null;
        /// <summary>
        /// khởi tạo
        /// </summary>
        public SlideDao()
        {
            db = new OnlineShopDbContext();
        }

        /// <summary>
        /// lấy danh sách tất cả slide
        /// </summary>
        /// <returns></returns>
        /// creaedby:dvquan
        public List<Slide>ListAll()
        {
            return db.Slides.Where(x => x.Status == true).OrderBy(y => y.DisplayOrder).ToList();
        }
    }
}
