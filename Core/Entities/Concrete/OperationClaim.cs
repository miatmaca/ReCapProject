using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Entity
{
   public class OperationClaim:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
