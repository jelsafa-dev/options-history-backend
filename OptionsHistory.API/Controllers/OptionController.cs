using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptionsHistory.API.Data;
using OptionsHistory.API.Models;

namespace OptionsHistory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly DataContext _context;
        public OptionController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Option>>> GetAll()
        {
            return Ok(await _context.Options.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Option>>> Get(int id)
        {
            var optionItem = await _context.Options.FindAsync(id);
            if (optionItem == null)
                return BadRequest("Option Not Found.");
            return Ok(optionItem);
        }

        [HttpPost]
        public async Task<ActionResult<List<Option>>> Create(Option option)
        {
            _context.Options.Add(option);
            await _context.SaveChangesAsync();

            return Ok(await _context.Options.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Option>>> Update(Option option)
        {
            var optionItem = await _context.Options.FindAsync(option.Id);
            if (optionItem == null)
                return BadRequest("Option Not Found.");

            optionItem.Name = option.Name;
            optionItem.StockId = option.StockId;
            await _context.SaveChangesAsync();

            return Ok(await _context.Options.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var optionItem = await _context.Options.FindAsync(id);
            if (optionItem == null)
                return BadRequest("Option Not Found.");

            _context.Options.Remove(optionItem);
            await _context.SaveChangesAsync();

            return Ok(await _context.Options.ToListAsync());
        }

    }
}
