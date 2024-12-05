﻿


using System.Text;
using YouVerifyIntegratiion.Interface;
using YouVerifyIntegratiion.Models;
using Newtonsoft.Json;

namespace YouVerifyIntegratiion.Service
{
    public class IdentityVerificationService : IIdentityVerificationService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public IdentityVerificationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        // Method for BVN verification (as before)
        public async Task<string> VerifyBvnAsync(string identityId)
        {
            string endpoint = _configuration["YouVerify:BVNEndpoint"];

            var request = new IdentityVerificationRequest
            {
                id = "11111111111",
                isSubjectConsent = true,
                premiumBVN = false,
                metadata = new Metadata { requestId = "636347" }
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

      

        // New method for NIN verification
        public async Task<string> VerifyNinAsync(string identityId)
        {
            string endpoint = _configuration["YouVerify:NINEndpoint"];

            var request = new IdentityVerificationNinRequest
            {
                id = "11111111111",
                premiumNin = true,
                isSubjectConsent = true
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

        public async Task<string> VerifyDriverLicenseAsync(string identityId)
        {
            string endpoint = _configuration["YouVerify:DriverLicenseEndpoint"];

            var request = new IdentityVerificationDriverLicenseRequest
            {
                id = "AAA00000AA00",
                isSubjectConsent = true,
                metadata = new Metadata { requestId = "sbaddaaqdkqdb" }
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

                return "Error:: " + response.ReasonPhrase;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public async Task<string> VerifyPhoneNo(string identityId)
        {
            string endpoint = _configuration["YouVerify:PhoneNoEndpoint"];

            var request = new IdentityVerificationPhone
            {
                
                mobile = "08000000000",
                isSubjectConsent = true
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
