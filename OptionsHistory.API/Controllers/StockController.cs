using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptionsHistory.API.Data;
using OptionsHistory.API.Models;

namespace OptionsHistory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly DataContext _context;
        public StockController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Stock>>> GetAll()
        {
            return Ok(await _context.Stocks.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Stock>>> Get(int id)
        {
            var stockItem = await _context.Stocks.FindAsync(id);
            if (stockItem == null)
                return BadRequest("Stock Not Found.");
            return Ok(stockItem);
        }

        [HttpPost]
        public async Task<ActionResult<List<Stock>>> Create(Stock stock)
        {
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();

            return Ok(await _context.Stocks.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Stock>>> Update(Stock stock)
        {
            var stockItem = await _context.Stocks.FindAsync(stock.Id);
            if (stockItem == null)
                return BadRequest("Stock Not Found.");

            stockItem.Name = stock.Name;
            await _context.SaveChangesAsync();

            return Ok(await _context.Stocks.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var stockItem = await _context.Stocks.FindAsync(id);
            if (stockItem == null)
                return BadRequest("Stock Not Found.");

            _context.Stocks.Remove(stockItem);
            await _context.SaveChangesAsync();

            return Ok(await _context.Stocks.ToListAsync());
        }
    }
}
