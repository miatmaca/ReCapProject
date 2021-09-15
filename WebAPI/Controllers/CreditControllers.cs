using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditsController : ControllerBase
    {
        ICreditCardService _creditCardService;

        public CreditsController (ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpGet("getsell")]
        public IActionResult GetAll( int amount, string cardNumber, int ExpMonth, int ExpYear, int CVV, string CardType, string fullname)
        {
            // Thread.Sleep(5000);

            var result = _creditCardService.CreditControl(amount,cardNumber,ExpMonth,ExpYear,CVV,CardType,fullname);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}