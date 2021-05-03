namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Feedback
    /// </summary>
    [Table("Feedback")]
    public partial class Feedback
    {
        /// <summary>
        /// id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// name
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [StringLength(50)]
        public string Phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [StringLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        [StringLength(50)]
        public string Address { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        [StringLength(250)]
        public string Content { get; set; }

        /// <summary>
        /// CreatedDate
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public bool? Status { get; set; }
    }
}
