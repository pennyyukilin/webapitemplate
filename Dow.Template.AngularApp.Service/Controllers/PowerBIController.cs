using Dow.Core.Library.Azure;
using Dow.Template.AngularApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;
using Microsoft.Rest;
using Microsoft.PowerBI.Api.V2;
using Microsoft.PowerBI.Api.V2.Models;
using Dow.Core.Library.ExceptionHandling;

namespace Dow.Template.AngularApp.Service.Controllers
{
    [Authorize]
    [RoutePrefix("api/powerbi")]
    public class PowerBIController : ApiController
    {
        public PowerBIController()
        {
        }

        [HttpGet]
        [Route("token/{groupId}/{type}/{id}")]
        public async Task<EmbedToken> GetToken(string groupId, string type, string id)
        {
            try
            {
                string secretValue = KeyValutHelper.GetSecret(CommonConfig.PbiSecretUri);
                string[] splitValue = secretValue.Split(new String[] { Constants.PbiSecretSplit }, StringSplitOptions.None);
                string userName = splitValue[0];
                string password = splitValue[1];

                string token = await GetTokenAsync(userName, password);
                var tokenCredentials = new TokenCredentials(token, Constants.PbiTokenType);

                // Create a Power BI Client object. It will be used to call Power BI APIs.
                using (var client = new PowerBIClient(new Uri(CommonConfig.PbiApiUrl), tokenCredentials))
                {
                    // Generate Embed Token.
                    var generateTokenRequestParameters = new GenerateTokenRequest(accessLevel: Constants.PbiDefaultAccessLevel);

                    EmbedToken tokenResponse = null;

                    if (Constants.PbiTypeReport.Equals(type, StringComparison.OrdinalIgnoreCase))
                    {
                        tokenResponse = await client.Reports.GenerateTokenInGroupAsync(groupId, id, generateTokenRequestParameters);
                    }
                    else if (Constants.PbiTypeDashboard.Equals(type, StringComparison.OrdinalIgnoreCase))
                    {
                        tokenResponse = await client.Dashboards.GenerateTokenInGroupAsync(groupId, id, generateTokenRequestParameters);
                    }

                    return tokenResponse;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleServiceException(ex);
                return null;
            }
        }



        private async Task<string> GetTokenAsync(string userName, string password)
        {
            // Create a user password cradentials.
            var credential = new UserPasswordCredential(userName, password);

            var authenticationContext = new AuthenticationContext(CommonConfig.PbiAuthorityUrl);
            var authenticationResult = await authenticationContext.AcquireTokenAsync(
                CommonConfig.PbiResourceUrl, CommonConfig.PbiClientIDUrl, credential);

            // Return the access token.
            return authenticationResult.AccessToken;
        }

    }
}
