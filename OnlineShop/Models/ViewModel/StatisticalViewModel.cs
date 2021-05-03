using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    /// <summary>
    /// StatisticalViewModel
    /// </summary>
    public class StatisticalViewModel
    {

        /// <summary>
        /// id
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// PromotionPrice
        /// </summary>
        public decimal? PromotionPrice { get; set; }

        /// <summary>
        /// CreatedDate
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// ModifiedDate
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// ModifiedBy
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// tên sản phẩm
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// mã sản phẩm
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// số lượng sản phẩm
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// người xác nhận
        /// </summary>
        public string ShipName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// số điện thoại
        /// </summary>
        public string Phone { get; set; }
    }
}
