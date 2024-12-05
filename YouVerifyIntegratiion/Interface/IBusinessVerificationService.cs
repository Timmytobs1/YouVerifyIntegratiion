namespace YouVerifyIntegratiion.Interface
{
    public interface IBusinessVerificationService
    {
        Task<string> VerifyBusiness(string identityId);
    }
}
