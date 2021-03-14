namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// loại sản phẩm
    /// </summary>
    [Table("Category")]
    public partial class Category
    {
        /// <summary>
        /// id loại sản phẩm
        /// </summary>
        [Key]
        public long ID { get; set; }

        /// <summary>
        /// tên loại sản phẩm
        /// </summary>
        [StringLength(250)]
        public string Name { get; set; }

        /// <summary>
        /// MetaTitle loại sản phẩm
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
        /// nagyf tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// người tạo
        /// </summary>
        [StringLength(50)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// ngày chỉnh sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// người chỉnh sửa
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
        /// trạng thái
        /// </summary>
        public bool? Status { get; set; }

        /// <summary>
        /// ShowOnHome
        /// </summary>
        public bool? ShowOnHome { get; set; }

        /// <summary>
        /// ngôn ngữ
        /// </summary>
        [StringLength(2)]
        public string Language { get; set; }
    }
}
