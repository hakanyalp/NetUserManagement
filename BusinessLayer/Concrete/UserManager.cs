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
    }
}
