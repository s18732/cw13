using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw13.Models;
using cw13.Services;
using Microsoft.AspNetCore.Mvc;

namespace cw13.Controllers
{
    //[Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private IDbService _context;
        public ClientsController(IDbService context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        [Route("api/clients/{id}/orders")]  
        public IActionResult PrzyjmijZamowienie(int id, DTOs.Requests.PrzyjecieZamowienia z)
        {
            var cos = _context.PrzyjmijZamowienie(z, id);
            if(cos == "Nie ma takiego wyrobu")
            {
                return BadRequest(cos);
            }
            else
            {
                return Ok(cos);
            }
        }
    }
}