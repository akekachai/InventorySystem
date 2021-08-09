using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YcgItInventorySystem_V2.Data;
using YcgItInventorySystem_V2.Models;

namespace YcgItInventorySystem_V2.Controllers
{
    public class ProfileController : Controller
    {
        public ApplicationDbContext _ApplicationDbContext;
        private readonly ILogger _logger;
        public class PostData
        {
            public string URL { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public IActionResult Login2(string usernames, string returnUrl = null)
        {
        //https://localhost:44345/Profile/Login2?usernames=akekachai.jar&ReturnUrl=%2F
            returnUrl = returnUrl ?? Url.Content("~/");
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Name,usernames )
            };
            var identity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var props = new AuthenticationProperties();
            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
            return LocalRedirect(returnUrl);
        }
        public IActionResult Login()
        {
            return View();
        }

        public ProfileController(ILogger<ProfileController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _ApplicationDbContext = applicationDbContext;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string txtusername, string txtpassword, string returnUrl = null)
        {
            ViewData["Message"] = "";
         var user = new PostData
            {
                Username = txtusername,
                Password = txtpassword
            };

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync("http://10.68.2.118:5002/api/values", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json")))

                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        if (JsonConvert.DeserializeObject(apiResponse).ToString() != "success")
                        {
                            ViewData["Message"] = JsonConvert.DeserializeObject(apiResponse);
                            //ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                            // ViewBag.StatusCode = response.StatusCode;
                            return View();
                        }
                    }


                }
            }

            returnUrl = returnUrl ?? Url.Content("~/");

          var Emp_Info= _ApplicationDbContext.EmpMstEmployee.Where(d => d.Username == txtusername).ToList();

            if (Emp_Info.Count != 0)
            {
                var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Name,txtusername ) 
            };
                var identity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                return LocalRedirect(returnUrl);
            }
            else
            {
                return View();
            }

        }

        [HttpPost]

        public async Task<IActionResult> logout()
        {

            await HttpContext.SignOutAsync();
            return RedirectToAction("login");
        }
    }
}
