using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product : IEntity
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float Price { get; set; }
        public float TotalPrice { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int KdvId { get; set; }
        public Kdv Kdv { get; set; }

        public List<BasketDetail> BasketDetails { get; set; }

    }
}
