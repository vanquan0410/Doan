using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopAPI.Models.OnlineShop.ViewModel
{
    /// <summary>
    /// bảng hóa đơn
    /// </summary>
    public class Order
    {

        /// <summary>
        /// ID
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// CreatedDate
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// CustomerID
        /// </summary>
        public long? CustomerID { get; set; }

        /// <summary>
        /// ShipName
        /// </summary>
        public string ShipName { get; set; }

        /// <summary>
        /// ShipMobile
        /// </summary>
        public string ShipMobile { get; set; }

        /// <summary>
        /// ShipAddress
        /// </summary>
        public string ShipAddress { get; set; }

        /// <summary>
        /// ShipEmail
        /// </summary>
        public string ShipEmail { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public int? Status { get; set; }

    }
}
