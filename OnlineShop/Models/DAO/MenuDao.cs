using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.DAO
{
    /// <summary>
    /// lớp menu lấy dữ liệu từ db
    /// </summary>
    /// createdby:dvquan
    public class MenuDao
    {
        OnlineShopDbContext db = null;
        /// <summary>
        /// khởi tạo
        /// </summary>
        public MenuDao()
        {
            db = new OnlineShopDbContext();
        }
        /// <summary>
        /// danh sách ListByGroupID
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public List<Menu>ListByGroupID(int groupID)
        {
            return db.Menus.Where(x => x.TypeID == groupID && x.Status==true).OrderBy(x=>x.DisplayOrder).ToList();
        }
    }
}
