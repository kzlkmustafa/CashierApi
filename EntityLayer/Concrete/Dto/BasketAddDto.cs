using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Dto
{
    public class BasketAddDto : IDtoEntity
    {
        public int ItemCount { get; set; }
        public float TotalPrice { get; set; }
        public bool Status { get; set; }
        public int AppUserId { get; set; }

    }
}
