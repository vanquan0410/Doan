using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopAPI.DBContext
{
    /// <summary>
    /// interface IDBContext
    /// </summary>
    public interface IDBContext<T>
    {
        /// <summary>
        /// lấy thông tin 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<T> SelectFirstOfDefault(string sql, DynamicParameters param);

        /// <summary>
        /// lấy danh sách
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> SelectList(string sql, DynamicParameters param);


    }
}
