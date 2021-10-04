using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public  class UserClaimDto:IDto
    {
        public string  firstName { get; set; }
        public string lastName { get; set; }
        public int Id { get; set; }
        public string claim { get; set; }
        public string email { get; set; }
    
    }
}
