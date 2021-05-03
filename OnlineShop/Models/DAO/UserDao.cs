using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;
using System.Configuration;
using Common;

namespace Models.DAO
{
    /// <summary>
    /// lớp user tượng tác với csdl
    /// </summary>
    public class UserDao
    {
        OnlineShopDbContext db = null;

        /// <summary>
        /// khởi tạo
        /// </summary>
        public UserDao()
        {
            db = new OnlineShopDbContext();
        }

        /// <summary>
        /// đăng nhập
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <param name="isLoginAdmin"></param>
        /// <returns></returns>
        //Dang nhap
        public int Login(string userName, string passWord, bool isLoginAdmin = true)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            if (result == null)            
                return 0;
          
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.GroupID == CommonConstants.ADMIN_GROUP || result.GroupID == CommonConstants.MOD_GROUP)
                    {
                        if (result.Status == false)                       
                            return -1;                     
                        else
                        {
                            if (result.Password == passWord)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else                  
                        return -3;                   
                }
                else
                {
                    if (result.Status == false)                   
                        return -1;                    
                    else
                    {
                        if (result.Password == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
        }

        /// <summary>
        /// thêm user
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        /// <summary>
        /// thêm user
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long InsertForFacebook(User entity)
        {
            var user = db.Users.SingleOrDefault(x => x.UserName == entity.UserName);
            if (user == null)
            {
                db.Users.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            else
            {
                return user.ID;
            }

        }

        /// <summary>
        /// cập nhập
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                user.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                //logging
                return false;
            }

        }

        /// <summary>
        /// lấy tất cả danh sách phan trang
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        /// <summary>
        /// lấy thông tin user
        /// </summary>
        /// <param name="userName">userName</param>
        /// <returns></returns>
        /// createdby:dvquan
        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }

        /// <summary>
        /// thông tin chi t user theo id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }

        /// <summary>
        /// GetListCredential
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<string> GetListCredential(string userName)
        {
            var user = db.Users.Single(x => x.UserName == userName);
            var data = (from a in db.Credentials
                        join b in db.UserGroups on a.UserGroupID equals b.ID
                        join c in db.Roles on a.RoleID equals c.ID
                        where b.ID == user.GroupID
                        select new
                        {
                            RoleID = a.RoleID,
                            UserGroupID = a.UserGroupID
                        }).AsEnumerable().Select(x => new Credential()
                        {
                            RoleID = x.RoleID,
                            UserGroupID = x.UserGroupID
                        });
            return data.Select(x => x.RoleID).ToList();

        }
      
        /// <summary>
        /// thay đổi trạng thái
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }

        /// <summary>
        /// xóa user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// kiểm tra theo tên
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        /// createdby:dvquan
        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.UserName == userName) > 0;
        }

        /// <summary>
        /// kiểm tra email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// createdby:dvquan
        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
    }
}
