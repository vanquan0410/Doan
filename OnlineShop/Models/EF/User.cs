namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// user 
    /// </summary>
    [Table("User")]
    public partial class User
    {
        /// <summary>
        /// id
        /// </summary>
        public long ID { get; set; }
      
        /// <summary>
        /// tài khoản
        /// </summary>
        [StringLength(50)]
        [Display(Name = "Tài Khoản")]
        public string UserName { get; set; }
       
        /// <summary>
        /// mật khẩu
        /// </summary>
        [StringLength(32)]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }
      
        /// <summary>
        /// nhám
        /// </summary>
        [StringLength(20)]
        [Display(Name = "Nhóm")]
        public string GroupID { get; set; }
       
        /// <summary>
        /// họ và tên
        /// </summary>
        [StringLength(50)]
        [Display(Name = "Họ Tên")]
        public string Name { get; set; }
       
        /// <summary>
        /// địa chỉ
        /// </summary>
        [StringLength(50)]
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }

        /// <summary>
        /// email
        /// </summary>
        [StringLength(50)]
        public string Email { get; set; }
       
        /// <summary>
        /// số điện thoại
        /// </summary>
        [StringLength(50)]
        [Display(Name = "Số Điện Thoại")]
        public string Phone { get; set; }

        /// <summary>
        /// ProvinceID
        /// </summary>
        public int? ProvinceID { get; set; }

        /// <summary>
        /// DistrictID
        /// </summary>
        public int? DistrictID { get; set; }

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
        /// status
        /// </summary>
        public bool Status { get; set; }
    }
}
