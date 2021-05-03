namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Content
    /// 
    /// </summary>
    /// createdby:
    [Table("Content")]
    public partial class Content
    {
        /// <summary>
        /// ID
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// tên
        /// </summary>
        [StringLength(250)]
        public string Name { get; set; }

        /// <summary>
        /// MetaTitle
        /// </summary>
        [StringLength(250)]
        public string MetaTitle { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [StringLength(500)]
        public string Description { get; set; }

        /// <summary>
        /// Image
        /// </summary>
        [StringLength(250)]
        public string Image { get; set; }

        /// <summary>
        ///
        /// </summary>
        public long? CategoryID { get; set; }

        /// <summary>
        /// Detail
        /// </summary>
        [Column(TypeName = "ntext")]
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
        /// Status
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// TopHot
        /// </summary>
        public DateTime? TopHot { get; set; }

        /// <summary>
        /// ViewCount
        /// </summary>
        public int? ViewCount { get; set; }

        /// <summary>
        /// Tags
        /// </summary>
        [StringLength(500)]
        public string Tags { get; set; }

        /// <summary>
        /// 
        /// Language
        /// </summary>
        [StringLength(2)]
        public string Language { get; set; }
    }
}
