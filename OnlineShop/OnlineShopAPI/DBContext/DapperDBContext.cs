using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Options;
using OnlineShopAPI.Models.OnlineShop.AppSetting;

namespace OnlineShopAPI.DBContext
{
    /// <summary>
    /// DapperDBContext
    /// </summary>
    public class DapperDBContext<T>:IDisposable, IDBContext<T>
    {
        private readonly DBConnection _dBConnection;
        private readonly IDbConnection _db;

        /// <summary>
        /// khởi tạo
        /// </summary>
        public DapperDBContext(DBConnection dBConnection)
        {
            _dBConnection = dBConnection;
            _db = new SqlConnection(_dBConnection.ConnectionString);
            _db.Open();
        }

        /// <summary>
        /// lấy thông tin 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<T> SelectFirstOfDefault(string sql, DynamicParameters param)
        {
            return _db.Query<T>(sql, param, commandType: CommandType.Text).FirstOrDefault();
        }

        /// <summary>
        /// lấy danh sách
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> SelectList(string sql, DynamicParameters param)
        {
            return _db.Query<T>(sql, param, commandType: CommandType.Text).ToList();
        }

        /// <summary>
        /// Public implementation of Dispose pattern callable by consumers.
        /// </summary>
        public void Dispose()
        {
            _db.Close();
        }
    }
}
