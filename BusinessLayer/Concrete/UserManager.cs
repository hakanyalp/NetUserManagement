using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<User> GetList()
        {
            return _userDal.List();
        }

        public void AddUser(User user)
        {
            _userDal.Insert(user);
        }

        public void DeleteUser(User user)
        {
            _userDal.Delete(user);
        }

        public void UpdateUser(User user)
        {
            _userDal.Update(user);
        }

        public User FindUser(int id)
        {
            return _userDal.Find(x => x.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return _userDal.Find(x => x.Username == username);
        }
    }
}
