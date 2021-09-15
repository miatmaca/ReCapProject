using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class Payment:IEntity
    {
        public int CustomerId { get; set; }
        public int PaymentId { get; set; }
        public int Amaunt { get; set; }
        public int CreditCardId { get; set; }
    }
}
