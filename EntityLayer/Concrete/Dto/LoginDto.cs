using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Dto
{
    public class LoginDto : IDtoEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
