namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Product
    /// </summary>
    [Table("Product")]
    public partial class Product
    {
        /// <summary>
        /// id
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// tên sản phẩm 
        /// </summary>
        [StringLength(250)]
        [Display(Name = "Tên Sản Phẩm")]
        public string Name { get; set; }

        /// <summary>
        /// mã sản phẩm
        /// </summary>
        [StringLength(10)]
        [Display(Name = "Mã Sản Phẩm")]
        public string Code { get; set; }

        /// <summary>
        /// MetaTitle
        /// </summary>
        [StringLength(250)]
        public string MetaTitle { get; set; }

        /// <summary>
        /// mô tả ngắn
        /// </summary>
        [StringLength(500)]
        public string Description { get; set; }

        /// <summary>
        /// hình ảnh
        /// </summary>
        [StringLength(250)]
        [Display(Name = "Hình Ảnh")]
        public string Image { get; set; }

        /// <summary>
        /// MoreImages
        /// </summary>
        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        /// <summary>
        /// giá gốc
        /// </summary>
        [Display(Name = "Giá Gốc")]
        public decimal? Price { get; set; }

        /// <summary>
        /// giá hiện tại
        /// </summary>
        [Display(Name = "Giá Hiện Tại")]
        public decimal? PromotionPrice { get; set; }

        /// <summary>
        /// thuế
        /// </summary>
        [Display(Name = "Thuế (True/False)")]
        public bool? IncludedVAT { get; set; }

        /// <summary>
        /// số lượng
        /// </summary>
        [Display(Name = "Số Lượng")]
        public int? Quantity { get; set; }


        /// <summary>
        /// loại sản phẩm
        /// </summary>
        [Display(Name = "Loại Sản Phẩm")]
        public long? CategoryID { get; set; }

        /// <summary>
        /// chitieets
        /// </summary>
        [Column(TypeName = "ntext")]
        [Display(Name = "Chi Tiết")]
        public string Detail { get; set; }

        /// <summary>
        /// Warranty
        /// </summary>
        public int? Warranty { get; set; }

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
        /// trạng thái
        /// </summary>
        [Display(Name = "Trạng Thái(True/False)")]
        public bool? Status { get; set; }

        /// <summary>
        /// top hot
        /// </summary>
        public DateTime? TopHot { get; set; }

        /// <summary>
        /// view count
        /// </summary>
        public int? ViewCount { get; set; }

        /// <summary>
        /// nhãn của sản phẩm
        /// </summary>
        public string Lable { get; set; }
    }
}
