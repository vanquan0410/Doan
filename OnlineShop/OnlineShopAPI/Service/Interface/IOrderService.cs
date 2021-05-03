using Dapper;
using OnlineShopAPI.Models.OnlineShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopAPI.Service.Interface
{
    /// <summary>
    /// inter face 
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// lấy thông tin order theo id
        /// </summary>
        /// <returns></returns>
        Task<OrderAndOrderDetail> GetOrderById();

        /// <summary>
        /// lấy danh sách đơn hàng theo id
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<OrderAndOrderDetail>> GetOrder(long id);
    }
}
