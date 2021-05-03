using Models.DAO;
using Models.ViewModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    /// <summary>
    /// màn hình slide nhưng chuyển sang thành thống kê báo cáo
    /// </summary>
    public class SlideController : Controller
    {
        //
        // GET: /Admin/Slide/
        /// <summary>
        /// trang danh sách thông kê
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// hiển thị danh sách thống kê báo cáo
        /// </summary>
        /// <param name="searchStringStart"></param>
        /// <param name="searchStringEnd"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        // xem san pham. co phan trang 
        public ActionResult Select(string searchStringStart, string searchStringEnd, int page = 1, int pageSize = 10)
        {
            DateTime ?start=null;
            DateTime ?end=null;
            if (!string.IsNullOrEmpty(searchStringStart)&&!string.IsNullOrEmpty(searchStringEnd))
            {
                start = DateTime.Parse(searchStringStart);
                end = DateTime.Parse(searchStringEnd);
            }
            var dao = new StatisticalDAO();
            var model = dao.ListAllPaging(start, end, page, pageSize);


            ViewBag.searchStringStart = searchStringStart;
            ViewBag.searchStringEnd = searchStringEnd;
            return View(model);
        }

        /// <summary>
        /// xuất bản danh sách thống kê
        /// </summary>
        /// <returns></returns>
        public ActionResult publish(string searchStart,string searchEnd)
        {

            Export_Excel(searchStart, searchEnd);
            return RedirectToAction("select", "Slide");
        }

        #region private func
        private void Export_Excel(string searchStringStart, string searchStringEnd)
        {
            //lấy dữ liệu
            var request_date = new StatisticalViewModel();
            var dao = new StatisticalDAO();
            DateTime? start = null;
            DateTime? end = null;
            if (!string.IsNullOrEmpty(searchStringStart) && !string.IsNullOrEmpty(searchStringEnd))
            {
                start = DateTime.Parse(searchStringStart);
                end = DateTime.Parse(searchStringEnd);
            }
            var list = dao.ListAllStatistical(start, end);
            //export
            ExcelPackage Ep = new ExcelPackage();
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Report");

            //định nghĩa title các cột
            Sheet.Cells["A1"].Value="Mã hóa đơn";
            Sheet.Cells["B1"].Value = "Tên sản phẩm";
            Sheet.Cells["C1"].Value = "Đơn giá";
            Sheet.Cells["D1"].Value = "Ngày thanh toán";
            Sheet.Cells["E1"].Value = "Người xác nhận";
            Sheet.Cells["F1"].Value = "Số lượng còn lại";
            Sheet.Cells["G1"].Value = "email";
            Sheet.Cells["H1"].Value = "Số điện thoại";
            int row = 2;
            if (list.Count() > 0)
            {
                int countPrice = 0;
                foreach(var item in list)
                {

                    //đổ dữ liệu vào các ô excel
                    Sheet.Cells[string.Format("A{0}", row)].Value = item.ID;
                    Sheet.Cells[string.Format("B{0}", row)].Value = item.Name;
                    Sheet.Cells[string.Format("C{0}", row)].Value = item.PromotionPrice;
                    Sheet.Cells[string.Format("C{0}", row)].Style.Numberformat.Format = "#,##.00";
                    Sheet.Cells[string.Format("D{0}", row)].Value = item.CreatedDate.ToString();
                    Sheet.Cells[string.Format("E{0}", row)].Value = item.ShipName;
                    Sheet.Cells[string.Format("F{0}", row)].Value = item.Quantity;
                    Sheet.Cells[string.Format("G{0}", row)].Value = item.Email;
                    Sheet.Cells[string.Format("H{0}", row)].Value = item.Phone;
                    row++;
                    countPrice = countPrice + Convert.ToInt32(item.PromotionPrice);
                }
                
                //đổ màu
                using (var range = Sheet.Cells[string.Format("B{0}", row)])
                {

                    range.Style.Font.Color.SetColor(Color.Red);
                    range.Style.Font.Bold = true;
                }
                using (var range = Sheet.Cells[string.Format("C{0}", row)])
                {

                    range.Style.Font.Color.SetColor(Color.Red);
                    range.Style.Font.Bold = true;
                }
                //tổng
                Sheet.Cells[string.Format("B{0}", row)].Value = "Tổng Thu";
                Sheet.Cells[string.Format("C{0}", row)].Value = countPrice;
                Sheet.Cells[string.Format("C{0}", row)].Style.Numberformat.Format = "#,##.00";
            }
            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            // Đây là content Type dành cho file excel
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //tên file excel
            Response.AddHeader("Content-Disposition", "attachment; filename = ExcelDemo.xlsx");
            // Lưu file excel của chúng ta như 1 mảng byte để trả về response
            Response.BinaryWrite(Ep.GetAsByteArray());
            Response.Flush();
            Response.End();
        }
        #endregion

    }
}
