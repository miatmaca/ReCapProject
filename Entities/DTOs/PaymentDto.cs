using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PaymentDto : IDto
    {
        public int CreditCartId { get; set; }
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public int ExpMounth { get; set; }
        public int ExpYear { get; set; }
        public int CVV { get; set; }
        public string CardType { get; set; }
        public int CardLimit { get; set; }
        public int Amount { get; set; }
       
    }
}
