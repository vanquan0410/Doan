using OnlineShop.Models;
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using OnlineShop.Common;
using System.Web.Script.Serialization;
using System.Configuration;
using Common;
namespace OnlineShop.Controllers
{
    /// <summary>
    /// controller cart
    /// </summary>
    /// Createdby:dvquan(13/2/2021)
    public class CartController : Controller
    {
        // GET: /Cart/
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var cart = Session[OnlineShop.Common.CommonConstants.CartSession];
            List<CartItem> list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }            
            return View(list);
        }       

        /// <summary>
        /// thêm item
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// createdby:dvquan
        public ActionResult AddItem(long productId, int quantity)
        {
            var product = new ProductDao().ViewDetail(productId);
            var cart = Session[OnlineShop.Common.CommonConstants.CartSession];
            List<CartItem> list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productId)
                        {
                            item.Quantity += quantity;                                                        
                        }
                       
                    }
                  
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[OnlineShop.Common.CommonConstants.CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[OnlineShop.Common.CommonConstants.CartSession] = list;
            }
            return RedirectToAction("Index");
        }
       
        /// <summary>
        /// xóa sản phâme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// createdby:dvquan
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[OnlineShop.Common.CommonConstants.CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[OnlineShop.Common.CommonConstants.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        /// <summary>
        /// xóa tất cả sản phẩm
        /// </summary>
        /// <returns></returns>
        /// createdby:dvquan
        public JsonResult DeleteAll()
        {
            Session[OnlineShop.Common.CommonConstants.CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        /// <summary>
        /// cập nhập sản phẩm
        /// </summary>
        /// <param name="cartModel">cartModel</param>
        /// <returns></returns>
        /// createdby:dvquan
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[OnlineShop.Common.CommonConstants.CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[OnlineShop.Common.CommonConstants.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        /// <summary>
        /// thanh toán
        /// </summary>
        /// <returns></returns>
        /// createdby:dvquan
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[OnlineShop.Common.CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        /// <summary>
        /// thanh toán
        /// </summary>
        /// <param name="shipName"></param>
        /// <param name="mobile"></param>
        /// <param name="address"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        /// createdby:dvquan
        [HttpPost]
        public ActionResult Payment(string shipName,string mobile,string address,string email)
        {
            var order = new Order();
            order.CreatedDate = DateTime.Now;
            order.ShipAddress = address;
            order.ShipMobile = mobile;
            order.ShipName = shipName;
            order.ShipEmail = email;
            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[OnlineShop.Common.CommonConstants.CartSession];
                var detailDao = new OrderDetailDao();
                decimal total = 0;
                foreach(var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.ProductID = item.Product.ID;
                    orderDetail.OrderID = id;
                    orderDetail.Price = item.Product.Price;
                    orderDetail.Quantity = item.Quantity;
                    detailDao.Insert(orderDetail);
                    //tinh tong tien
                    total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);                    
                }
                string content = System.IO.File.ReadAllText(Server.MapPath("~/assets/client/template/NewOrder.html"));

                content = content.Replace("{{CustomerName}}", shipName);
                content = content.Replace("{{Phone}}", mobile);
                content = content.Replace("{{Email}}", email);
                content = content.Replace("{{Address}}", address);
                //content=content.Replace("{{Product}}",);
                content = content.Replace("{{Total}}", total.ToString("N0"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new MailHelper().SendMail(email, "Đơn hàng mới từ OnlineShop", content);
                new MailHelper().SendMail(toEmail, "Đơn hàng mới từ OnlineShop", content);
            }
            catch (Exception ex)
            {
                //return Redirect("/loi-thanh-toan");
              //  throw ex;
            }
            return Redirect("/hoan-thanh");
        }

        /// <summary>
        /// thông báo
        /// </summary>
        /// <returns></returns>
        /// createdby: dvquan
        public ActionResult Success()
        {
            return View();
        }


    }
}
