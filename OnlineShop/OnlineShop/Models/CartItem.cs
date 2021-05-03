using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    /// <summary>
    /// CartItem
    /// </summary>
    [Serializable]
    public class CartItem
    {
        /// <summary>
        /// Product
        /// </summary>
        public Product Product { set; get; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { set; get; }
        
    }
}