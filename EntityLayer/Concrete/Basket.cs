using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Basket : IEntity
    {
        [Key]
        public int BasketId { get; set; }
        public int ItemCount { get; set; }
        public float TotalPrice { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<BasketDetail> BasketDetails { get; set; }

    }
}
