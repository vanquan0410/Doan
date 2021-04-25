using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DBContext
{
    public class SQLServerContext<T> where T: class
    {
        private readonly string sqlConnect= "data source=DESKTOP-J3U84ON;initial catalog=OnlineShop;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        private readonly IDbConnection _db;
        public SQLServerContext()
        {
            _db = new SqlConnection(sqlConnect);
        }

        /// <summary>
        /// lấy thông tin 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<T>SelectFirstOfDefault(string sql, DynamicParameters param)
        {
            return default;
        }

        /// <summary>
        /// lấy danh sách
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> SelectList (string sql, DynamicParameters param)
        {
            return default;
        }
    }
}
