using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SagamoreCarsDAL;

namespace SagamoreCarsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarAdsController : ControllerBase
    {
        private readonly SagamoreCarsDBContext _context;

        public CarAdsController(SagamoreCarsDBContext context)
        {
            _context = context;
        }

        // GET: api/CarAds
        [HttpGet(Name = "GetAll")]
        public async Task<ActionResult<IEnumerable<CarAd>>> GetCarAd()
        {
            return await _context.CarAd.ToListAsync();
        }

        // GET: api/CarAds/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<CarAd>> GetCarAd(int id)
        {
            var carAd = await _context.CarAd.FindAsync(id);

            if (carAd == null)
            {
                return NotFound();
            }

            return carAd;
        }

        // PUT: api/CarAds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}", Name = "Put")]
        public async Task<IActionResult> PutCarAd(int id, CarAd carAd)
        {
            if (id != carAd.Id)
            {
                return BadRequest();
            }

            _context.Entry(carAd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarAdExists(id))
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

        // POST: api/CarAds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost(Name = "Post")]
        public async Task<ActionResult<CarAd>> PostCarAd(CarAd carAd)
        {
            _context.CarAd.Add(carAd);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarAd", new { id = carAd.Id }, carAd);
        }

        // DELETE: api/CarAds/5
        [HttpDelete("{id}", Name = "Delete")]
        public async Task<ActionResult<CarAd>> DeleteCarAd(int id)
        {
            var carAd = await _context.CarAd.FindAsync(id);
            if (carAd == null)
            {
                return NotFound();
            }

            _context.CarAd.Remove(carAd);
            await _context.SaveChangesAsync();

            return carAd;
        }

        private bool CarAdExists(int id)
        {
            return _context.CarAd.Any(e => e.Id == id);
        }
    }
}
