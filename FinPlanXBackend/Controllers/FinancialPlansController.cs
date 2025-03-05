using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinPlanXBackend.Data;
using FinPlanXBackend.Models;

namespace FinPlanXBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialPlansController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FinancialPlansController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/FinancialPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinancialPlan>>> GetFinancialPlans()
        {
            return await _context.FinancialPlans.ToListAsync();
        }

        // GET: api/FinancialPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinancialPlan>> GetFinancialPlan(int id)
        {
            var financialPlan = await _context.FinancialPlans.FindAsync(id);

            if (financialPlan == null)
            {
                return NotFound();
            }

            return financialPlan;
        }

        // PUT: api/FinancialPlans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinancialPlan(int id, FinancialPlan financialPlan)
        {
            if (id != financialPlan.Id)
            {
                return BadRequest();
            }

            _context.Entry(financialPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancialPlanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FinancialPlans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FinancialPlan>> PostFinancialPlan(FinancialPlan financialPlan)
        {
            _context.FinancialPlans.Add(financialPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinancialPlan", new { id = financialPlan.Id }, financialPlan);
        }

        // DELETE: api/FinancialPlans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinancialPlan(int id)
        {
            var financialPlan = await _context.FinancialPlans.FindAsync(id);
            if (financialPlan == null)
            {
                return NotFound();
            }

            _context.FinancialPlans.Remove(financialPlan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinancialPlanExists(int id)
        {
            return _context.FinancialPlans.Any(e => e.Id == id);
        }
    }
}
