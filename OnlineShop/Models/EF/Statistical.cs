using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EF
{
    /// <summary>
    /// Statistical
    /// </summary>
    public class Statistical
    {
        /// <summary>
        /// id
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// PromotionPrice
        /// </summary>
        [Display(Name = "Giá sô tiền")]
        public decimal? PromotionPrice { get; set; }

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
    }
}
