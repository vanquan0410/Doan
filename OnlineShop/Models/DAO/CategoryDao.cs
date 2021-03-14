using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;

namespace Models.DAO
{
    /// <summary>
    /// lớp CategoryDao
    /// </summary>
    /// CreatedBy:DVquan(05/3/2021)
    public class CategoryDao
    {
        OnlineShopDbContext db = null;
        /// <summary>
        /// khởi tạo
        /// </summary>
        public CategoryDao()
        {
            db = new OnlineShopDbContext();
        }

        /// <summary>
        /// thêm category
        /// </summary>
        /// <param name="category">category</param>
        /// <returns>category.ID</returns>
        /// CreatedBy:DVquan(05/3/2021)
        public long Insert(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return category.ID;
        }

        /// <summary>
        /// lấy danh sách Category
        /// </summary>
        /// <returns>danh sách Category</returns>
        /// CreatedBy:DVquan(05/3/2021)
        public List<Category> AllList()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }

        /// <summary>
        /// tìm kiếm danh sách sản phẩm có phân trang
        /// </summary>
        /// <param name="searchString">searchString</param>
        /// <param name="page">page</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns>danh sách sản phẩm</returns>
        /// CreatedBy:DVquan(05/3/2021)
        public object ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        /// <summary>
        /// danh sách sản phẩn theo id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>id sản phẩm</returns>
        /// CreatedBy:DVquan(05/3/2021)
        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }

    }
}
