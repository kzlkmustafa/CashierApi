using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Dto
{
    public class KdvAddDto : IDtoEntity
    {
        public float KdvPercent { get; set; }
    }
}
