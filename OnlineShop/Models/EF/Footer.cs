namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Footer
    /// </summary>
    [Table("Footer")]
    public partial class Footer
    {
        /// <summary>
        /// ID
        /// </summary>
        [StringLength(50)]
        public string ID { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public bool? Status { get; set; }
    }
}
