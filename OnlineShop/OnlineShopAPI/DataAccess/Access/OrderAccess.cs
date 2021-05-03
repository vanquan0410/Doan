using Dapper;
using OnlineShopAPI.DataAccess.inteface;
using OnlineShopAPI.DBContext;
using OnlineShopAPI.Models.OnlineShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopAPI.DataAccess.Access
{
    public class OrderAccess: inteface.IOrderAccess
    {
        private readonly IDBContext<OrderAndOrderDetail> _dBContext;
        public OrderAccess(IDBContext<OrderAndOrderDetail> dBContext)
        {
            _dBContext = dBContext;
        }

        /// <summary>
        /// lấy danh sách order theo id
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<IEnumerable<OrderAndOrderDetail>> GetOrder(DynamicParameters param)
        {
            string sql = "SELECT o.ID,od.Price,o.CreatedDate,p.Name,p.Code,p.Quantity,o.ShipName,o.ShipEmail,o.ShipMobile FROM [Order] o INNER JOIN OrderDetail od ON o.ID=od.OrderID INNER JOIN Product p ON od.ProductID=p.ID WHERE o.ID = @ID;";
            return await _dBContext.SelectList(sql, param);
        }

        /// <summary>
        /// lấy thông tin order theo id
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<OrderAndOrderDetail> GetOrderById(DynamicParameters param)
        {
            string sql = "SELECT o.ID,od.Price,o.CreatedDate,p.Name,p.Code,p.Quantity,o.ShipName,o.ShipEmail,o.ShipMobile FROM [Order] o INNER JOIN OrderDetail od ON o.ID=od.OrderID INNER JOIN Product p ON od.ProductID=p.ID WHERE o.ID = @ID;";
            return await _dBContext.SelectFirstOfDefault(sql,param);
        }
    }
}
