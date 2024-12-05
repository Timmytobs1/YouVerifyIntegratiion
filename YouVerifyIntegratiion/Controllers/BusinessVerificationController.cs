using Microsoft.AspNetCore.Mvc;
using YouVerifyIntegratiion.Interface;


namespace YouVerifyIntegratiion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessVerificationController : Controller
    {
        private readonly IBusinessVerificationService _businessVerificationService;
        public BusinessVerificationController(IBusinessVerificationService businessVerificationService)
        {
            _businessVerificationService = businessVerificationService;
        }

        [HttpPost("verify/business/{identityId}")]
        public async Task<IActionResult> VerifyBusiness(string identityId)
        {
            var response = await _businessVerificationService.VerifyBusiness(identityId);
            return Ok(response);
        }
    }
}
