using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FacebookAuth.Core.Constants;
using FacebookAuth.Core.Models;
using FacebookAuth.Core.ViewModels;
using FacebookAuth.Utils;
using Newtonsoft.Json;

namespace FacebookAuth.Core
{
    public class FacebookAuthentication
    {
        private readonly HttpClient _httpClient;
        private readonly FacebookAppSettings _settings;

        public FacebookAuthentication(FacebookAppSettings settings)
        {
            _httpClient = new HttpClient();
            _settings = settings;
        }


        private async Task<AuthTokenValidationResponse> ValidateAccessTokenAsync(string accessToken)
        {
            var accessTokenResponse = await _httpClient.GetStringAsync(
                $"{FacebookGraphApiConstants.GRAPH_API_URL}oauth/access_token?client_id={_settings.AppId}&client_secret={_settings.AppSecret}&grant_type=client_credentials");

            var deserializedTokenResponse = JsonConvert.DeserializeObject<AuthTokenAccess>(accessTokenResponse);
            if (deserializedTokenResponse == null) return null; //TODO:throw new exception

            var isDeserializedTokenResponseObjectValid = ObjectValidator.Validate(deserializedTokenResponse);
            if (!isDeserializedTokenResponseObjectValid) return null; //throw new exception

            var validAccessTokenResponse = await _httpClient.GetStringAsync(
                $"https://graph.facebook.com/debug_token?input_token={accessToken}&access_token={deserializedTokenResponse.AccessToken}");

            var validAccessToken =
                JsonConvert.DeserializeObject<AuthTokenValidationResponse>(validAccessTokenResponse);

            var isValidAccessTokenObjectValid = ObjectValidator.Validate(validAccessToken);
            return !isValidAccessTokenObjectValid ? null : validAccessToken;
        }

        /// <summary>
        /// This function will authenticate the user on facebook via an access token
        /// </summary>
        /// <param name="accessToken">AccessToken that should come from Facebook</param>
        /// <param name="fields">These are the field options which tell us which data to include. Example: id,email,first_name,last_name,name,gender,locale,birthday,picture</param>
        /// <returns></returns>
        public async Task<AuthUserResponse> GetAuthenticatedUserInformationAsync(string accessToken, string fields)
        {
            var validAccessToken = await ValidateAccessTokenAsync(accessToken);

            //TODO:VALIDATE
            //id,email,first_name,last_name,name,gender,locale,birthday,picture

            var userInfoResponse = await _httpClient.GetStringAsync(
                $"{FacebookGraphApiConstants.GRAPH_API_PROFILE_URL}?fields=${fields}&access_token={validAccessToken}");
            return JsonConvert.DeserializeObject<AuthUserResponse>(userInfoResponse);
        }

        /// <summary>
        /// This function will authenticate the user on facebook via an access token
        /// </summary>
        /// <param name="accessToken">AccessToken that should come from Facebook</param>
        /// <param name="fields">These are the field options which tell us which data to include. Example: list(id,email,first_name,last_name,name,gender,locale,birthday,picture)</param>
        /// <returns></returns>
        public async Task<AuthUserResponse> GetAuthenticatedUserInformationAsync(string accessToken, IReadOnlyList<string> fields)
        {
            var validAccessToken = await ValidateAccessTokenAsync(accessToken);

            var fieldsString = string.Join(",", fields);
            //TODO:VALIDATE
            //id,email,first_name,last_name,name,gender,locale,birthday,picture

            var userInfoResponse = await _httpClient.GetStringAsync(
                $"{FacebookGraphApiConstants.GRAPH_API_PROFILE_URL}?fields=${fieldsString}&access_token={validAccessToken}");
            return JsonConvert.DeserializeObject<AuthUserResponse>(userInfoResponse);
        }

    }
}
