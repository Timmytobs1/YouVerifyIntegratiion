using Microsoft.AspNetCore.Mvc;
using YouVerifyIntegratiion.Interface;

namespace YouVerifyIntegratiion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityVerificationController : Controller
    {
        private readonly IIdentityVerificationService _identityVerificationService;

        public IdentityVerificationController(IIdentityVerificationService identityVerificationService)
        {
            _identityVerificationService = identityVerificationService;
        }

        // Endpoint to verify BVN
        [HttpPost("verify/bvn/{identityId}")]
        public async Task<IActionResult> VerifyBvn(string identityId)
        {
            var response = await _identityVerificationService.VerifyBvnAsync(identityId);
            return Ok(response);
        }

        // Endpoint to verify NIN
        [HttpPost("verify/nin/{identityId}")]
        public async Task<IActionResult> VerifyNin(string identityId)
        {
            var response = await _identityVerificationService.VerifyNinAsync(identityId);
            return Ok(response);
        }

        // Endpoint to verify Driver's License
        [HttpPost("verify/driver-license/{identityId}")]
        public async Task<IActionResult> VerifyDriverLicense(string identityId)
        {
            var response = await _identityVerificationService.VerifyDriverLicenseAsync(identityId);
            return Ok(response);
        }

        [HttpPost("verify/phone-no/{identityId}")]
        public async Task<IActionResult> VerifyPhoneNo(string identityId)
        {
            var response = await _identityVerificationService.VerifyPhoneNo(identityId);
            return Ok(response);
        }

    }

}
