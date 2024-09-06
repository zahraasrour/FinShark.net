using Finshark.Net.Data;
using Finshark.Net.Dtos.Stock;
using Finshark.Net.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task< IActionResult> GetAll()
        {
            var stocks = await _context.Stock.ToListAsync();
            var stockDto = stocks.Select(s=>s.toStockDto());
            return Ok(stocks);


        }
        [HttpGet("{id}")]
        public async Task< IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _context.Stock.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.toStockDto());

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto StockDto)
        {
            var stockModel = StockDto.ToStockFromCreateDto();
            await _context.Stock.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.toStockDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id ,[FromBody] UpdateStockRequestDto updateDto)
        {
            var stockModel = await _context.Stock.FindAsync(id);   
            if(stockModel == null)
            {
                return NotFound();
            }
            stockModel.Symbol = updateDto.Symbol;
            stockModel.CompanyName = updateDto.CompanyName;
            stockModel.Purchase = updateDto.Purchase;
            stockModel.LastDiv = updateDto.LastDiv;
            stockModel.Industry = updateDto.Industry;
            stockModel.MarketCap =  updateDto.MarketCap;

            await _context.SaveChangesAsync();
            return Ok(stockModel.toStockDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task <IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _context.Stock.FindAsync(id);
            if(stockModel == null) { return NotFound(); } 
            _context.Stock.Remove(stockModel);
            await _context.SaveChangesAsync();
            return NoContent();
           
        }

    }
}
