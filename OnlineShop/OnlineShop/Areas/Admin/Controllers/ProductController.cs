using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using Common;


namespace OnlineShop.Areas.Admin.Controllers
{
    /// <summary>
    /// ProductController
    /// </summary>
    /// createdby:dvquan
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        OnlineShopDbContext db = new OnlineShopDbContext();

        public ActionResult Index()
        {
            return View();
        }


        // xem san pham. co phan trang 
        public ActionResult Select(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }


        [HttpGet] //  truyen viewbag len view them san pham
        public ActionResult Create()
        {
            SetViewBag();
            return View("Create");
        }



        [HttpPost] // them san pham
        public ActionResult Create(Product product)
        {
            if (product.Name != null)
            {
                if (ModelState.IsValid)
                { 
                    var dao = new ProductDao();
                    product.MetaTitle = CommonConstants.convertToUnSign3(product.Name);
                    product.Description = product.Name;
                    product.MoreImages = ("<Images></Images>").ToString();
                    product.CreatedDate = DateTime.Now;
                    var session = (Common.UserLogin)Session[OnlineShop.Common.CommonConstants.USER_SESSION];
                    product.CreatedBy = session.UserName;
                    product.MetaKeywords = product.MetaTitle;
                    product.MetaDescriptions = product.MetaTitle;
                    product.TopHot = DateTime.Now;
                    product.ViewCount = 0;
                    long id = dao.Insert(product);
                    if (id > 0)
                    {

                        SetAlert("Thêm sản phẩm thành công", "success");
                        return RedirectToAction("Create", "Product");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm sản phẩm không thành công");
                    }
                }

            }
            SetViewBag();
           // SetAlert("Thêm sản phẩm  không thành công", "success");
            SetAlert("Tên sản phẩm bắt buộc", "error");
            return View("Create");
        }


        public ActionResult Edit(int id)
        {
            SetViewBag();
            var product = new ProductDao().ViewDetail(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                product.MetaTitle = CommonConstants.convertToUnSign3(product.Name);
                product.Description = product.Name;
                var session = (Common.UserLogin)Session[OnlineShop.Common.CommonConstants.USER_SESSION];
                product.ModifiedBy = session.UserName;
                product.MetaKeywords = product.MetaTitle;
                product.MetaDescriptions = product.MetaTitle;
                product.TopHot = DateTime.Now;
                var result = dao.Update(product);
                if (result)
                {
                    SetAlert("Cập nhật sản phẩm thành công", "success");
                    return RedirectToAction("Select", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật sản phẩm không thành công");
                }
            }
            SetViewBag();
            return View("Select");
        }


        [HttpDelete] // xoa san pham
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);
            SetAlert("Xoá sản phẩm thành công", "success");
            return RedirectToAction("Index");
        }

        // viewbag truyen dropdownlist category
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.AllList(), "ID", "Name", selectedId);
        }

        // thay doi trang thai san pham
        public JsonResult ChangeStatus(long id)
        {
            var result = new ProductDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

        /// <summary>
        /// luu nhiu hinh anh cho san pham
        /// </summary>
        /// <param name="id"></param>
        /// <param name="images"></param>
        /// <returns></returns>
        /// createdby:dvquan
        public JsonResult SaveImages(long id, string images)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var listImages = serializer.Deserialize<List<string>>(images);

            XElement xElement = new XElement("Images");

            foreach (var item in listImages)
            {
                var subStringItem = item.Substring(21);
                xElement.Add(new XElement("Image", subStringItem));
            }
            ProductDao dao = new ProductDao();
            try
            {
                dao.UpdateImages(id, xElement.ToString());
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception)
            {
                return Json(new
                {
                    status = false
                });
            }

        }
        /// <summary>
        /// cap nhat hinh anh cho san pham
        /// </summary>
        /// <param name="id"></param>
        /// <returns>view</returns>
        /// createdby:dvquan
        public JsonResult LoadImages(long id)
        {
            ProductDao dao = new ProductDao();
            var product = dao.ViewDetail(id);
            if (product.MoreImages == null)
            {
                return Json(new
                {
                    status = false
                });
            }
            var images = product.MoreImages;
            XElement xImages = XElement.Parse(images);
            List<string> listImagesReturn = new List<string>();

            foreach (XElement element in xImages.Elements())
            {
                listImagesReturn.Add(element.Value);
            }
            return Json(new
            {
                data = listImagesReturn
            }, JsonRequestBehavior.AllowGet);
        }
    }
}