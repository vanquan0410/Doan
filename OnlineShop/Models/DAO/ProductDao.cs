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
    /// class product tương tác với cơ sở dữ liệu
    /// </summary>
    /// createdby:dvquan
    public class ProductDao
    {

        OnlineShopDbContext db = null;

        /// <summary>
        /// khởi tạo
        /// </summary>
        /// createdby:dvquan
        public ProductDao()
        {
            db = new OnlineShopDbContext();
        }

        /// <summary>
        /// lấy danh sách sản phẩm mới
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        /// createdby:dvquan
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        /// <summary>
        ///  //lay danh sach san pham tu Danh Muc San Pham
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        /// cfeatedby:dvquan
        public List<Product> ListByCategoryId(long categoryId)
        {
            return db.Products.Where(x => x.CategoryID == categoryId).ToList();
        }

        /// <summary>
        /// lấy danh sách sản phẩm theo đặc điểm
        /// </summary>
        /// <param name="top">top</param>
        /// <returns>ds sản phẩm</returns>
        /// createdby:dvquan
        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        /// <summary>
        /// lấy danh sách sản phẩm theo loại sản phẩm
        /// </summary>
        /// <param name="categoryID">categoryID</param>
        /// <param name="totalRecord"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns>ds sản phẩm</returns>
        /// createdby:dvquan
        public List<Product> ListProductPaging(long categoryID, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Where(x => x.CategoryID == categoryID).Count();
            var model = db.Products.Where(x => x.CategoryID == categoryID).OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }

        /// <summary>
        /// //San Pham Lien Quan
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// createdby:
        public List<Product> ListRelatedProducts(long productId)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.ID != productId && x.CategoryID == product.CategoryID).ToList();

        }

        /// <summary>
        ///         //tim kiem
        /// </summary>
        /// <param name="pireform"></param>
        /// <param name="pireto"></param>
        /// <param name="keyword"></param>
        /// <param name="totalRecord"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// createdby:
        public List<ProductViewModel> Search(int pireform, int pireto, string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 10)
        {
            if (pireform != 0 && pireto != 0)
            {
                totalRecord = db.Products.Where(x => x.Name == keyword).Count();
                var model2 = (from a in db.Products
                              join b in db.ProductCategories
                              on a.CategoryID equals b.ID
                              where a.Name.Contains(keyword) && a.Price <= pireto && a.Price >= pireform
                              select new
                              {
                                  CateMetaTitle = b.MetaTitle,
                                  CateName = b.Name,
                                  CreatedDate = a.CreatedDate,
                                  ID = a.ID,
                                  Images = a.Image,
                                  Name = a.Name,
                                  MetaTitle = a.MetaTitle,
                                  Price = a.Price
                              }).AsEnumerable().Select(x => new ProductViewModel()
                              {
                                  CateMetaTitle = x.MetaTitle,
                                  CateName = x.Name,
                                  CreatedDate = x.CreatedDate,
                                  ID = x.ID,
                                  Images = x.Images,
                                  Name = x.Name,
                                  MetaTitle = x.MetaTitle,
                                  Price = x.Price
                              });
                model2.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                return model2.ToList();
            }
            totalRecord = db.Products.Where(x => x.Name == keyword).Count();
            var model = (from a in db.Products
                         join b in db.ProductCategories
                         on a.CategoryID equals b.ID
                         where a.Name.Contains(keyword)
                         select new
                         {
                             CateMetaTitle = b.MetaTitle,
                             CateName = b.Name,
                             CreatedDate = a.CreatedDate,
                             ID = a.ID,
                             Images = a.Image,
                             Name = a.Name,
                             MetaTitle = a.MetaTitle,
                             Price = a.Price
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             CateMetaTitle = x.MetaTitle,
                             CateName = x.Name,
                             CreatedDate = x.CreatedDate,
                             ID = x.ID,
                             Images = x.Images,
                             Name = x.Name,
                             MetaTitle = x.MetaTitle,
                             Price = x.Price
                         });
            model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }

        /// <summary>
        ///         //Danh sach ten san pham
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        /// createdby:dvquan
        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }

        /// <summary>
        /// lấy chi tiết sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// createdby:dvquan
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }

        /// <summary>
        /// lấy danh sách sản phẩm tương tự sử dụng thuật toán KNN
        /// </summary>
        /// <param name="lable">nhãn của sản phẩm</param>
        /// <returns>ds sp</returns>
        /// createdby:dvquan
        public List<Product> GetListProductsSimilar(string lable)
        {
            return db.Products.Where(x => x.Lable == lable).ToList();
        }

        /// <summary>
        /// lấy tất cả danh sách sản phẩm có phân trang
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// createdby:dvquan
        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        /// <summary>
        /// thay đổi trạng thái user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// createdby:dvquan
        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }

        /// <summary>
        /// thay đổi thông tin sản phẩm
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// createdby:dvquan
        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        /// <summary>
        /// update lại image
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="images"></param>
        /// createdby:dvquan
        public void UpdateImages(long productId, string images)
        {
            var product = db.Products.Find(productId);
            product.MoreImages = images;
            db.SaveChanges();
        }

        /// <summary>
        /// update lại thông tin sản phẩm
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// createdby:dvqun
        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.ID);
                product.Name = entity.Name;
                product.MetaTitle = CommonConstants.convertToUnSign3(entity.Name);
                product.Description = product.Name;
                product.Code = entity.Code;
                product.Image = entity.Image;
                product.Price = entity.Price;
                product.PromotionPrice = entity.PromotionPrice;
                product.IncludedVAT = entity.IncludedVAT;
                product.ModifiedBy = entity.ModifiedBy;


                product.Quantity = entity.Quantity;


                product.ModifiedDate = DateTime.Now;
                product.Status = entity.Status;
                product.TopHot = DateTime.Now;
                product.MetaKeywords = product.MetaTitle;
                product.MetaDescriptions = product.MetaTitle;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //logging
                return false;
            }

        }

        /// <summary>
        /// xóa sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// createdby:dvquan
        public bool Delete(int id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
