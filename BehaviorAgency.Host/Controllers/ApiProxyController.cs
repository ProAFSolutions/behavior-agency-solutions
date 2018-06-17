using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using BehaviorAgency.Host.Core;

namespace BehaviorAgency.Host.Controllers
{
    [Authorize]
    [Route("proxy/api")]
    public class ApiProxyController : Controller
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        private delegate Task<HttpResponseMessage> HttpCallAction();

        public ApiProxyController(IConfiguration config) {
            _config = config;
            _httpClient = new HttpClient();
            _apiBaseUrl = _config.GetValue<string>("BAgencyApiBaseUrl");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Query.ContainsKey("routeUrl")) {
                context.Result = BadRequest("RouteUrl is missing");
                return;
            } 
            base.OnActionExecuting(context);
        }

        
        [HttpGet]
        public async Task<IActionResult> Get(string routeUrl)
        {
            return await CallApiUsingUserAccessToken(() =>
            {
                return _httpClient.GetAsync($"{_apiBaseUrl}/{routeUrl}");
            });
        }
       
        [HttpPost]
        public async Task<IActionResult> Post(string routeUrl, [FromBody]object data)
        {
            return await CallApiUsingUserAccessToken(() =>
            {
                return _httpClient.PostAsync($"{_apiBaseUrl}/{routeUrl}", new JsonContent(data));
            });
        }

       
        [HttpPut]
        public async Task<IActionResult> Put(string routeUrl, [FromBody]object data)
        {
            return await CallApiUsingUserAccessToken(() =>
            {
                return _httpClient.PutAsync($"{_apiBaseUrl}/{routeUrl}", new JsonContent(data));
            });
        }

       
        [HttpDelete]
        public async Task<IActionResult> Delete(string routeUrl)
        {
            return await CallApiUsingUserAccessToken(() =>
            {
                return _httpClient.DeleteAsync($"{_apiBaseUrl}/{routeUrl}");
            });
        }
       

        private async Task<IActionResult> CallApiUsingUserAccessToken(HttpCallAction action) {

            var accessToken = await HttpContext.GetTokenAsync("access_token");

            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized();

            _httpClient.SetBearerToken(accessToken);
            HttpResponseMessage response = await action();
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
