using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Kdv : IEntity
    {
        [Key]
        public int KdvId { get; set; }
        public float KdvPercent { get; set; }
        public List<Product> Products { get; set; }
    }
}
