using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Utilitie
{
    /// <summary>
    /// các host của các service
    /// </summary>
    public static class Contains
    {
        /// <summary>
        /// host KNNService
        /// </summary>
        public static string HostServiceKNN = "http://localhost:4000/";
    }

    /// <summary>
    /// subpath service KNN
    /// </summary>
    public static class SubPathKNN
    {
        /// <summary>
        /// subpath lấy lable của sản phẩm tương tự khi xem chi tết của 1 sản phẩm
        /// </summary>
        public static string GetLable = "api/knn/";
    }
}
