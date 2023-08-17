using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserOperationClaim : IEntity
    {
        [Key]
        public int UserOperationClaimId { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int OperationClaimId { get; set; }
        public OperationClaim OperationClaim { get; set; }
    }
}
