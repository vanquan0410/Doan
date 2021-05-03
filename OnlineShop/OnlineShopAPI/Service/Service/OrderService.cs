using Dapper;
using OnlineShopAPI.DataAccess.inteface;
using OnlineShopAPI.Models.OnlineShop.ViewModel;
using OnlineShopAPI.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopAPI.Service.Service
{
    /// <summary>
    /// lớp sử lý nghiệp vụ order
    /// </summary>
    public class OrderService:IOrderService
    {

        private readonly IOrderAccess _orderDetailAccess;

        /// <summary>
        /// khởi tạo
        /// </summary>
        public OrderService(IOrderAccess orderDetailAccess)
        {
            _orderDetailAccess = orderDetailAccess;
        }

        /// <summary>
        /// lấy dánh sách đơn hàng theo id
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<OrderAndOrderDetail>> GetOrder(long id)
        {
            var param = new DynamicParameters(new { ID = id });
            return _orderDetailAccess.GetOrder(param);
        }

        /// <summary>
        /// lấy thông tin đơn hàng theo id
        /// </summary>
        /// <returns></returns>
        public Task<OrderAndOrderDetail> GetOrderById()
        {
            var pram = new DynamicParameters(new { ID = 1 });
            return _orderDetailAccess.GetOrderById(pram);
        }
    }
}
