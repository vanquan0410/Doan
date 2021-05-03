using Dapper;
using OnlineShopAPI.Models.OnlineShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopAPI.DataAccess.inteface
{
    public interface IOrderAccess
    {
        /// <summary>
        /// lấy thông tin theo id
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<OrderAndOrderDetail> GetOrderById(DynamicParameters param);

        /// <summary>
        /// lấy danh sách order theo id
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<IEnumerable<OrderAndOrderDetail>> GetOrder(DynamicParameters param);
    }
}
