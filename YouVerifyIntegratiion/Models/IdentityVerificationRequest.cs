using Org.BouncyCastle.Asn1.Cms;

namespace YouVerifyIntegratiion.Models
{
    public class IdentityVerificationRequest
    {
        public string id{ get; set; }
        public bool isSubjectConsent { get; set; }
        public bool premiumBVN { get; set; }
        public Metadata metadata { get; set; }
    }

    public class Metadata
    {
        public string requestId { get; set; }
    }
}
