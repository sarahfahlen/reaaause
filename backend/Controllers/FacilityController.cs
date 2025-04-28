using backend.Repository;
using Microsoft.AspNetCore.Mvc;
using shared;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/facilities")]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityRepository facilityRepo;

        public FacilityController(IFacilityRepository facilityRepo)
        {
            this.facilityRepo = facilityRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Facility>> GetAll()
        {
            return await facilityRepo.GetAllFacilities();
        }

        [HttpPost]
        public async Task<IActionResult> AddFacility([FromBody] Facility facility)
        {
            await facilityRepo.AddFacility(facility);
            return Ok();
        }
    }
}