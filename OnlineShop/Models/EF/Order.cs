namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Order
    /// </summary>
    [Table("Order")]
    public partial class Order
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
        [StringLength(50)]
        public string ShipName { get; set; }

        /// <summary>
        /// ShipMobile
        /// </summary>
        [StringLength(50)]
        public string ShipMobile { get; set; }

        /// <summary>
        /// ShipAddress
        /// </summary>
        [StringLength(50)]
        public string ShipAddress { get; set; }

        /// <summary>
        /// ShipEmail
        /// </summary>
        [StringLength(50)]
        public string ShipEmail { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public int? Status { get; set; }
    }
}
