namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// slide
    /// </summary>
    [Table("Slide")]
    public partial class Slide
    {
        /// <summary>
        /// id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// image
        /// </summary>
        [StringLength(250)]
        public string Image { get; set; }

        /// <summary>
        /// DisplayOrder
        /// </summary>
        public int? DisplayOrder { get; set; }

        /// <summary>
        /// link
        /// </summary>
        [StringLength(250)]
        public string Link { get; set; }

        /// <summary>
        /// CreatedDate
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// status
        /// </summary>
        public bool? Status { get; set; }
    }
}
