using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager
    {
        Repository<User> repo = new Repository<User>();
        public List<User> GetAll()
        {
            return repo.List();
        }

        public int AddUserBL(User u)
        {
            if (false)  // TODO : filter // !u.Mail.Contains("@")
            {
                return -1;
            }
            return repo.Insert(u);
        }

        public User FindUser(int id)
        {
            return repo.Find(x => x.Id == id);
        }

        public int EditUserBL(User u)
        {
            User _user = repo.Find(x => x.Id == u.Id);
            if (false)  // TODO : filter
            {
                return -1;
            }

            _user.Username = u.Username;
            _user.Password = u.Password;
            _user.Name = u.Name;
            _user.Surname = u.Surname;
            _user.Mail = u.Mail;
            _user.PhoneNumber = u.PhoneNumber;
            _user.Role = u.Role;

            return repo.Update(_user);
        }

        public int DeleteUser(int id)
        {
            User u = repo.Find(x => x.Id == id);
            return repo.Delete(u);
        }
    }
}
