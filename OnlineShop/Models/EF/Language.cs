namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Language
    /// </summary>
    [Table("Language")]
    public partial class Language
    {
        /// <summary>
        /// ID
        /// </summary>
        [StringLength(2)]
        public string ID { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// IsDefault
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
