namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Contact table
    /// </summary>
    [Table("Contact")]
    public partial class Contact
    {
        /// <summary>
        /// id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// content
        /// </summary>
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        /// <summary>
        /// status
        /// </summary>
        public bool? Status { get; set; }
    }
}
