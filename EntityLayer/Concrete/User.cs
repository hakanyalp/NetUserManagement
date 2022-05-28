using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Username { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(30)]
        public string Surname { get; set; }
        [StringLength(30)]
        public string Mail { get; set; }
        [StringLength(14)]
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }
    }

    public enum Role
    {
        [Description("User")]
        User,
        [Description("Admin")]
        Admin
    }
}