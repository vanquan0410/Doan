using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class StatisticalViewModel
    {
        public long ID { get; set; }

      
        public decimal? PromotionPrice { get; set; }

        public DateTime? CreatedDate { get; set; }

       
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

       
        public string ModifiedBy { get; set; }
    }
}
