namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Credential
    /// </summary>
    [Table("Credential")]
    [Serializable]
    public partial class Credential
    {
        /// <summary>
        /// UserGroupID
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string UserGroupID { get; set; }

        /// <summary>
        /// RoleID
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string RoleID { get; set; }
    }
}
