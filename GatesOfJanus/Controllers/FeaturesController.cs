using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatesOfJanus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GatesOfJanus.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly FeatureContext _context;

        public FeaturesController(FeatureContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all features
        /// GET: api/Features
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feature>>> GetFeature()
        {
            return await _context.Feature.ToListAsync();
        }

        // GET: api/Features/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feature>> GetFeature(long id)
        {
            var feature = await _context.Feature.FindAsync(id);

            if (feature == null)
            {
                return NotFound();
            }

            return feature;
        }

        // PUT: api/Features/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeature(long id, Feature feature)
        {
            if (id != feature.ID)
            {
                return BadRequest();
            }

            _context.Entry(feature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeatureExists(id))
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

        // POST: api/Features
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Creates a Feature Flag
        /// </summary>
        /// <remarks>
        /// Sample request: 
        /// 
        /// 
        /// </remarks>
        /// <returns>A newly created feature</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        public async Task<ActionResult<Feature>> PostFeature(Feature feature)
        {
            _context.Feature.Add(feature);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeature", new { id = feature.ID }, feature);
        }

        // DELETE: api/Features/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Feature>> DeleteFeature(long id)
        {
            var feature = await _context.Feature.FindAsync(id);
            if (feature == null)
            {
                return NotFound();
            }

            _context.Feature.Remove(feature);
            await _context.SaveChangesAsync();

            return feature;
        }

        private bool FeatureExists(long id)
        {
            return _context.Feature.Any(e => e.ID == id);
        }
    }
}
