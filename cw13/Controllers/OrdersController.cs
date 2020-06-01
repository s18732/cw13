using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw13.Models;
using cw13.Services;
using Microsoft.AspNetCore.Mvc;

namespace cw13.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IDbService _context;
        public OrdersController(IDbService context)
        {
            _context = context;
        }
        [HttpGet("{nazwisko}")]
        public IActionResult GetOrders(string nazwisko)
        {
            var list = _context.GetOrders(nazwisko);
            return Ok(list);
        }
        [HttpGet]
        public IActionResult GetOrders()
        {
            var list = _context.GetOrders();
            return Ok(list);
        }
    }
}