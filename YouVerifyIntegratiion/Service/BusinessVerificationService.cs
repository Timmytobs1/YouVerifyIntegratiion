


using System.Text;
using YouVerifyIntegratiion.Interface;
using YouVerifyIntegratiion.Models;
using Newtonsoft.Json;

namespace YouVerifyIntegratiion.Service
{
    public class BusinessVerificationService : IBusinessVerificationService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public BusinessVerificationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> VerifyBusiness(string identityId)
        {

            string endpoint = _configuration["YouVerify:BusinessEndpoint"];

            var request = new IdentityVerificationBusiness
            {

                registrationNumber = "RC0000000",
                countryCode = "NG",
                isConsent = true
            };

            var jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return jsonResponse;
                }

                return "Error: " + response.ReasonPhrase;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
