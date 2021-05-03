namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// SystemConfig
    /// </summary>
    [Table("SystemConfig")]
    public partial class SystemConfig
    {
        /// <summary>
        /// id
        /// </summary>
        [StringLength(50)]
        public string ID { get; set; }

        /// <summary>
        /// name
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// type
        /// </summary>
        [StringLength(50)]
        public string Type { get; set; }

        /// <summary>
        /// value
        /// </summary>
        [StringLength(250)]
        public string Value { get; set; }

        /// <summary>
        /// status
        /// </summary>
        public bool? Status { get; set; }
    }
}
