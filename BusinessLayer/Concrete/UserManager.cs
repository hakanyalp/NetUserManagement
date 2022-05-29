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

        Repository<User> repo = new Repository<User>();
        public List<User> GetAll()
        {
            return repo.List();
        }

        public User FindUser(int id)
        {
            return repo.Find(x => x.Id == id);
        }

        public void DeleteUser(int id)
        {
            User u = repo.Find(x => x.Id == id);
            repo.Delete(u);
        }

        public List<User> GetList()
        {
            return _userDal.List();
        }

        public void AddUser(User user)
        {
            _userDal.Insert(user);
        }

        public User GetUserByUsername(string username)
        {
            return _userDal.Find(x => x.Username == username);
        }

        public void DeleteUser(User user)
        {
            _userDal.Delete(user);
        }

        public void UpdateUser(User user)
        {
            _userDal.Update(user);
        }
    }
}
