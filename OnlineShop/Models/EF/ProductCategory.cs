namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// ProductCategory
    /// </summary>
    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        /// <summary>
        /// ID
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [StringLength(250)]
        public string Name { get; set; }

        /// <summary>
        /// MetaTitle
        /// </summary>
        [StringLength(250)]
        public string MetaTitle { get; set; }

        /// <summary>
        /// ParentID
        /// </summary>
        public long? ParentID { get; set; }

        /// <summary>
        /// DisplayOrder
        /// </summary>
        public int? DisplayOrder { get; set; }

        /// <summary>
        /// SeoTitle
        /// </summary>
        [StringLength(250)]
        public string SeoTitle { get; set; }

        /// <summary>
        /// CreatedDate
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// CreatedBy
        /// </summary>
        [StringLength(50)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// ModifiedDate
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// ModifiedBy
        /// </summary>
        [StringLength(50)]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// MetaKeywords
        /// </summary>
        [StringLength(250)]
        public string MetaKeywords { get; set; }

        /// <summary>
        /// MetaDescriptions
        /// </summary>
        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public bool? Status { get; set; }

        /// <summary>
        /// ShowOnHome
        /// </summary>
        public bool? ShowOnHome { get; set; }
    }
}
