using Finshark.Net.Data;
using Finshark.Net.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Finshark.Net.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : Controller
    {

        private readonly ApplicationDbContext _context;
        public StockController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]//Reading from db 
        public IActionResult GetAll()
        {
            var stocks = _context.Stock.ToList().Select(s=>s.toStockDto());
            return Ok(stocks);


        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stock.Find(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.toStockDto());

        }

    }
}
