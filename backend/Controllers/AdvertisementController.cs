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
            var result = await adRepo.GetMyAdvertisements(email);
            return result;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddAd([FromBody] Advertisement ad)
        {
            await adRepo.AddAdvertisement(ad);
            return Ok();
        }

        [HttpPut("status/{adId}")]
        public async Task<IActionResult> UpdateStatus(string adId, [FromBody] string newStatus)
        {
            await adRepo.UpdateAdStatus(adId, newStatus);
            return Ok();
        }
        [HttpDelete("{id}")]
        public void Remove(string id)
        {
            Console.WriteLine($"Sletter tøj med id {id}");
            adRepo.Remove(id);
        } 
        [HttpPut]
        public void Update([FromBody] Advertisement ad)
        {
            adRepo.UpdateAd(ad);
        }

    }
}