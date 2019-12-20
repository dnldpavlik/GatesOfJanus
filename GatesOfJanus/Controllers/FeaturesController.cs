namespace GatesOfJanus.Controllers
{
    using System.Threading.Tasks;
    using GatesOfJanus.Models;
    using Microsoft.AspNetCore.Mvc;

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
        /// Gets a feature by id
        /// </summary>
        /// <returns>The feature by the supplied id</returns>
        /// <response code="200">The feature for the supplied id</response>
        /// <response code="400">If the feature was not found</response>
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
    }
}
