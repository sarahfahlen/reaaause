using backend.Repository;
using Microsoft.AspNetCore.Mvc;
using shared;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/purchases")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseRepository purchaseRepo;

        public PurchaseController(IPurchaseRepository purchaseRepo)
        {
            this.purchaseRepo = purchaseRepo;
        }

        [HttpGet("my/{userEmail}")]
        public async Task<ActionResult<List<PurchaseWithAd>>> GetMyPurchases(string userEmail)
        {
            var purchases = await purchaseRepo.GetPurchasesByUserEmail(userEmail);
            return Ok(purchases);
        }

        [HttpPost("add/{adId}")]
        public async Task<IActionResult> AddPurchase(string adId, [FromBody] Purchase purchase)
        {
            await purchaseRepo.AddPurchase(adId, purchase);
            return Ok();
        }
        
        [HttpPut("status/{adId}/{purchaseId}")]
        public async Task<IActionResult> UpdatePurchaseRequestStatus(string adId, string purchaseId, [FromBody] string newStatus)
        {
            await purchaseRepo.UpdatePurchaseRequestStatus(adId, purchaseId, newStatus);
            return Ok();
        }


    }
}