using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OnlineShopAPI.Models.OnlineShop.ViewModel
{
    /// <summary>
    /// OrderAndOrderDetail
    /// </summary>
    public class OrderAndOrderDetail
    {
        /// <summary>
        /// id
        /// </summary>
        [DataMember(Name = "ID", EmitDefaultValue = false)]
        public long ID { get; set; }

        /// <summary>
        /// PromotionPrice
        /// </summary>
        [DataMember(Name = "Price", EmitDefaultValue = false)]
        public decimal? Price { get; set; }

        /// <summary>
        /// CreatedDate
        /// </summary>
        [DataMember(Name = "CreatedDate", EmitDefaultValue = false)]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// name
        /// </summary>
        [DataMember(Name = "Name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// mã sản phẩm
        /// </summary>
        [DataMember(Name = "Code", EmitDefaultValue = false)]
        public string Code { get; set; }

        /// <summary>
        /// số lượng sản phẩm
        /// </summary>
        [DataMember(Name = "Quantity", EmitDefaultValue = false)]
        public int Quantity { get; set; }

        /// <summary>
        /// người xác nhận
        /// </summary>
        [DataMember(Name = "ShipName", EmitDefaultValue = false)]
        public string ShipName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [DataMember(Name = "ShipEmail", EmitDefaultValue = false)]
        public string ShipEmail { get; set; }

        /// <summary>
        /// số điện thoại
        /// </summary>
          [DataMember(Name = "ShipMobile", EmitDefaultValue = false)]
        public string ShipMobile { get; set; }
    }
}
