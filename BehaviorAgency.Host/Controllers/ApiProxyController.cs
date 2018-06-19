using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using BehaviorAgency.Host.Core;
using System.Linq;
using BehaviorAgency.Infrastructure;
using BehaviorAgency.Infrastructure.Security;

namespace BehaviorAgency.Host.Controllers
{
    [Authorize]
    [Route("proxy/api")]
    public class ApiProxyController : Controller
    {
        private readonly IConfiguration _config;
        private readonly string _apiBaseUrl;

        private delegate Task<HttpResponseMessage> HttpCallAction(HttpClient httpClient);

        public ApiProxyController(IConfiguration config) {
            _config = config;
            _apiBaseUrl = _config.GetValue<string>("BAgencyApiBaseUrl");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Query.ContainsKey("apiRouteUrl")) {
                context.Result = BadRequest("RouteUrl is missing");
                return;
            } 
            base.OnActionExecuting(context);
        }

        
        [HttpGet]
        public async Task<IActionResult> Get(string apiRouteUrl)
        {
            return await CallApiUsingUserAccessToken((HttpClient httpClient) =>
            {
                return httpClient.GetAsync($"{_apiBaseUrl}/{apiRouteUrl}");
            });
        }
       
        [HttpPost]
        public async Task<IActionResult> Post(string apiRouteUrl, [FromBody]object data)
        {
            return await CallApiUsingUserAccessToken((HttpClient httpClient) =>
            {
                return httpClient.PostAsync($"{_apiBaseUrl}/{apiRouteUrl}", new JsonContent(data));
            });
        }

       
        [HttpPut]
        public async Task<IActionResult> Put(string apiRouteUrl, [FromBody]object data)
        {
            return await CallApiUsingUserAccessToken((HttpClient httpClient) =>
            {
                return httpClient.PutAsync($"{_apiBaseUrl}/{apiRouteUrl}", new JsonContent(data));
            });
        }

       
        [HttpDelete]
        public async Task<IActionResult> Delete(string apiRouteUrl)
        {
            return await CallApiUsingUserAccessToken((HttpClient httpClient) =>
            {
                return httpClient.DeleteAsync($"{_apiBaseUrl}/{apiRouteUrl}");
            });
        }
       

        private async Task<IActionResult> CallApiUsingUserAccessToken(HttpCallAction action) {

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var agencyCodesClaim = User.Claims.Where(C => C.Type == "agency_code").SingleOrDefault();

            if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(agencyCodesClaim.Value))
                return Unauthorized();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("AgencyCode", CryptoManager.Encrypt(agencyCodesClaim.Value));
            httpClient.SetBearerToken(accessToken);

            HttpResponseMessage response = await action(httpClient);
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(jsonContent))
                    return Ok();

                return Content(jsonContent, "application/json");
            }

            return StatusCode((int) response.StatusCode);
        }

    }
}
