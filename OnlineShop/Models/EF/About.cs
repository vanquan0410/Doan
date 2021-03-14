namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    /// <summary>
    /// [Table("About")]
    /// </summary>
    [Table("About")]
    public partial class About
    {
        /// <summary>
        /// id
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// tên
        /// </summary>
        [StringLength(250)]
        public string Name { get; set; }

        /// <summary>
        /// tiêu đề
        /// </summary>
        [StringLength(250)]
        public string MetaTitle { get; set; }

        /// <summary>
        /// mo tả ngắn
        /// </summary>
        [StringLength(500)]
        public string Description { get; set; }

        /// <summary>
        /// ảnh
        /// </summary>
        [StringLength(250)]
        public string Image { get; set; }

        /// <summary>
        /// chi tiết
        /// </summary>
        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        /// <summary>
        /// ngày tạo
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
    }
}
