using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BasketDetail : IEntity
    {
        [Key]
        public int BasketDetailId { get; set; }
        public int ItemCount { get; set; }
        public float Price { get; set; }
        public float TotalPrice { get; set; }
        public DateTime CreateDate { get; set; }

        public int BasketId { get; set; }
        public Basket Basket { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
