using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.DAO
{
    /// <summary>
    /// class loại sản phẩm tương tác với cơ sở dl
    /// </summary>
    public class ProductCategoryDao
    {
        OnlineShopDbContext db = null;

        /// <summary>
        /// khỏi tạo
        /// </summary>
        public ProductCategoryDao()
        {
            db = new OnlineShopDbContext();
        }

        /// <summary>
        /// lấy danh sách tất cả các sản phẩm
        /// </summary>
        /// <returns></returns>
        /// createdby:dvquan
        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        /// <summary>
        /// lấy thông tin của sản phẩm thông qua id của sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// createdby:dvquan
        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }
    }
}
