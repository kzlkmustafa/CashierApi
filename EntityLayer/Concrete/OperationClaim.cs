using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class OperationClaim :IEntity
    {
        [Key]
        public int OperationClaimId { get; set; }
        public int Name { get; set; }

        public List<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
