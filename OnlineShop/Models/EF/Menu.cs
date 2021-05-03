namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Menu
    /// </summary>
    [Table("Menu")]
    public partial class Menu
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Text
        /// </summary>
        [StringLength(50)]
        public string Text { get; set; }

        /// <summary>
        /// Link
        /// </summary>
        [StringLength(250)]
        public string Link { get; set; }

        /// <summary>
        /// DisplayOrder
        /// </summary>
        public int? DisplayOrder { get; set; }

        /// <summary>
        /// Target
        /// </summary>
        [StringLength(50)]
        public string Target { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public bool? Status { get; set; }

        /// <summary>
        /// TypeID
        /// </summary>
        public int? TypeID { get; set; }
    }
}
