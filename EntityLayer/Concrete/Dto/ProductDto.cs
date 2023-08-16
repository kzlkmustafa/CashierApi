using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Dto
{
    public class ProductDto : ProductAddDto, IDtoEntity
    {
        public int ProductId { get; set; }
    
    }
}
