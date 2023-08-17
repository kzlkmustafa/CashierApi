using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Dto
{
    public class AppUserDto
    {
        [Key]
        public int AppUserId { get; set; }
        public string UserName { get; set; }
        public string NameSurname { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string Telnr { get; set; }

    }
}
