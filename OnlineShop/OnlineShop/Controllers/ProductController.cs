using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;
using Models.Utilitie;
using PagedList;
using PagedList.Mvc;
using QuanShop.Service;
using RestSharp;

namespace OnlineShop.Controllers
{
    /// <summary>
    /// ProductController
    /// </summary>
    /// createdby:dvquan
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDao().ListAll();
            return PartialView(model);
        }

        public JsonResult ListName(string q)
        {

            var data = new ProductDao().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Phan trang danh sach san pham
        /// </summary>
        /// <param name="cateId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        ///createdby:dvquan
        public ActionResult Category(long cateId, int page = 1, int pageSize = 8)
        {
            var category = new CategoryDao().ViewDetail(cateId);
            ViewBag.Category = category;
            int totalRecord = 0;
            var model = new ProductDao().ListProductPaging(cateId, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;
            //Math.Ceiling lam tron len
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }

        /// <summary>
        /// constroller thực hiện chức năng tìm kiếm sản phẩm
        /// </summary>
        /// <param name="from">Giá từ</param>
        /// <param name="to">Giá đến</param>
        /// <param name="keyword">từ khóa tìm kiếm</param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// createdby:dvquan
        public ActionResult Search(string from, string to, string keyword, int page = 1, int pageSize = 1)
        {
            string fromDetail = from;
            string toDetail = to;
            int totalRecord = 0;
            if (string.IsNullOrEmpty(from))
            {
                fromDetail = "0";
            }
            if (string.IsNullOrEmpty(to))
            {
                toDetail = "0";
            }
            var model = new ProductDao().Search(Convert.ToInt32(fromDetail), Convert.ToInt32(toDetail), keyword, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.Keyword = keyword;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            ViewBag.from = from;
            ViewBag.to = to;

            return View(model);
        }

        /// <summary>
        /// trang xem chi tiết sản phẩm
        /// </summary>
        /// <param name="cateId">id sản phẩm</param>
        /// <returns></returns>
        /// createdby:dvquan
        public async Task<ActionResult> Detail(long cateId)
        {
            try
            {
                var product = new ProductDao().ViewDetail(cateId);
                ViewBag.Category = new ProductCategoryDao().ViewDetail(product.CategoryID.Value);
                var RelatedProducts = new ProductDao().ListRelatedProducts(cateId);
                //gọi api đến service KNN
                var client = new RestClient(Contains.HostServiceKNN + SubPathKNN.GetLable + product.Price);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                var res = response.Content;
                res = res.Replace("[", "");
                res = res.Replace("]", "");
                res = res.Replace("\n", "");
                if (!string.IsNullOrEmpty(res))
                {
                    var similar = await new ProductDao().GetListProductsSimilar(res, product.CategoryID.ToString());
                    List<Product> similarProduct = new List<Product>();
                    int i = 0;
                    foreach (Product rs in similar)
                    {
                        if (i < 8)
                        {
                            similarProduct.Add(rs);
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    ViewBag.SimilarProducts = similarProduct;
                }

                //lấy danh sách sản phẩm liên quan
                List<Product> relatedProduct = new List<Product>();
                int countRelated = 0;
                foreach (Product rs in RelatedProducts)
                {
                    if (countRelated < 8)
                    {
                        relatedProduct.Add(rs);
                        countRelated++;
                    }
                }
                ViewBag.RelatedProducts = relatedProduct;

                return View(product);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }
    }
}
