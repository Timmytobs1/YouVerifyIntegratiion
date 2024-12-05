namespace YouVerifyIntegratiion.Interface
{
    public interface IIdentityVerificationService
    {
        Task<string> VerifyBvnAsync(string identityId);
        Task<string> VerifyNinAsync(string identityId);
        Task<string> VerifyDriverLicenseAsync(string identityId);
        Task<string> VerifyPhoneNo(string identityId);
    }
}
