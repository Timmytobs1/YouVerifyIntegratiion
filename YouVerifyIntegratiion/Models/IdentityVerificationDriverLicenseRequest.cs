using Org.BouncyCastle.Asn1.Cms;
    namespace YouVerifyIntegratiion.Models
    {
        public class IdentityVerificationDriverLicenseRequest
        {
            public string id { get; set; }  // Driver license number
            public bool isSubjectConsent { get; set; }  // Consent from the subject for the verification
            public Metadata metadata { get; set; }  // Metadata containing the request ID
        }

       
    }

