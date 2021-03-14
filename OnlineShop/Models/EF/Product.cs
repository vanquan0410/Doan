﻿namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên Sản Phẩm")]
        public string Name { get; set; }

        [StringLength(10)]
        [Display(Name = "Mã Sản Phẩm")]
        public string Code { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(250)]
        [Display(Name = "Hình Ảnh")]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }
        [Display(Name = "Giá Gốc")]
        public decimal? Price { get; set; }
        [Display(Name = "Giá Hiện Tại")]
        public decimal? PromotionPrice { get; set; }
        [Display(Name = "Thuế (True/False)")]
        public bool? IncludedVAT { get; set; }
        [Display(Name = "Số Lượng")]
        public int? Quantity { get; set; }
        [Display(Name = "Loại Sản Phẩm")]
        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Chi Tiết")]
        public string Detail { get; set; }

        public int? Warranty { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }
        [Display(Name = "Trạng Thái(True/False)")]
        public bool? Status { get; set; }

        public DateTime? TopHot { get; set; }

        public int? ViewCount { get; set; }
    }
}
