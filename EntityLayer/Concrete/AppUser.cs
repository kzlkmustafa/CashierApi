using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser : IEntity
    {
        [Key]
        public int AppUserId { get; set; }
        public string UserName { get; set; }
        public string NameSurname { get;set; }
        public byte[] PasswordHash { get;set; }
        public byte[] PasswordSalt { get;set; }
        public bool Status { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime Birthdate { get; set; }
        public string Telnr { get; set; }

        public List<Basket> Basket { get; set; }

    }
}
