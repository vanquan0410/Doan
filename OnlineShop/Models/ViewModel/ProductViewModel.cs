using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    /// <summary>
    /// ProductViewModel
    /// </summary>
    public class ProductViewModel
    {
        /// <summary>
        /// id
        /// </summary>
        public long ID { set; get; }

        /// <summary>
        /// ảnh sản phẩm
        /// </summary>
        public string Images { set; get; }

        /// <summary>
        /// tên sản phẩm
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// giá sản phẩm
        /// </summary>
        public decimal? Price { set; get; }

        /// <summary>
        /// CateName
        /// </summary>
        public string CateName { set; get; }

        /// <summary>
        /// CateMetaTitle
        /// </summary>
        public string CateMetaTitle { set; get; }

        /// <summary>
        /// MetaTitle
        /// </summary>
        public string MetaTitle { set; get; }

        /// <summary>
        /// CreatedDate
        /// </summary>
        public DateTime? CreatedDate { set; get; }
    }
}
