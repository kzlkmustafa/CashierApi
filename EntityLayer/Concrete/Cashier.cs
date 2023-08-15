using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Cashier : IEntity
    {
        [Key]
        public int CashierId { get; set; }
        public string UserName { get; set; }
        public string NameSurname { get;set; }
        public string CashierPassword { get;set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime Birthdate { get; set; }
        public string Telnr { get; set; }

        public List<Basket> Basket { get; set; }

    }
}
