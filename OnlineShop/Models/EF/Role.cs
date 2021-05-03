namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// role
    /// </summary>
    [Table("Role")]
    public partial class Role
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
    }
}
