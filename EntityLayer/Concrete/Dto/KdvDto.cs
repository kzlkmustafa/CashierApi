using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Dto
{
    public class KdvDto : KdvAddDto, IDtoEntity
    {
        public int KdvId { get; set; }
        public float Percent { get; set; }
    }
}
