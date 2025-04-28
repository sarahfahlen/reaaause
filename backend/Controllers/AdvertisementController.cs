using Microsoft.AspNetCore.Mvc;
using backend.Repository;
using shared;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/advertisements")]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementRepository adRepo;

        public AdvertisementController(IAdvertisementRepository adRepo)
        {
            this.adRepo = adRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Advertisement>> GetAll()
        {
            return await adRepo.GetAllAdvertisements();
        }

        [HttpGet("active")]
        public async Task<IEnumerable<Advertisement>> GetActive()
        {
            return await adRepo.GetAllActiveAdvertisements();
        }

        [HttpGet("myads/{email}")]
        public async Task<IEnumerable<Advertisement>> GetMyAds(string email)
        {
            Console.WriteLine($"[DEBUG] MyAds kaldt med email: {email}");
            var result = await adRepo.GetMyAdvertisements(email);
            Console.WriteLine($"[DEBUG] Antal annoncer fundet: {result.Count}");
            return result;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddAd([FromBody] Advertisement ad)
        {
            await adRepo.AddAdvertisement(ad);
            return Ok();
        }


    }
}