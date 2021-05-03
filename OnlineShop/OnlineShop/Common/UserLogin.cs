using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Common
{
    /// <summary>
    /// UserLogin
    /// </summary>
    [Serializable]
    public class UserLogin
    {
        /// <summary>
        /// UserID
        /// </summary>
        public long UserID { set; get; }

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// GroupID
        /// </summary>
        public string GroupID { set; get; }
    }
}