using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Dto
{
    public class BasketDetailAddDto :IDtoEntity
    {
        public int ItemCount { get; set; }
        public float Price { get; set; }
        public float TotalPrice { get; set; }
        public int BasketId { get; set; }
        public int ProductId { get; set; }
    }
}
