using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectsManagment.Data.Interfaces;
using ProjectsManagment.Data.Services;
using ProjectsManagment.Entity;
using ProjectsManagment.Entity.ViewModels;
using ProjectsManagment.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;


namespace ProjectsManagment.Web.Controllers
{
    
    [Authorize]
    [RoutePrefix("api/Account")]
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class AccountController : ApiController
    {
        const string apiBaseUri = "http://localhost:61318";
        private IUserService _userService;

        public AccountController() : base()
        {
        }

        public AccountController(IUserService userService)
            : base()
        {
            _userService = userService;

        }
        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication; 
            }
        }

                
        
        [HttpPost]
        [Route("registration")]
        public async Task<IHttpActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName};
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var provider = new DpapiDataProtectionProvider("ApplicationName");
                    UserManager.UserTokenProvider = new DataProtectorTokenProvider<User>(provider.Create("ASP.NET Identity"));
                                        
                    // генерируем токен для подтверждения регистрации
                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // создаем ссылку для подтверждения
                    var  callbackUrl = Url.Link("Default", new { Controller = "api/Account", Action = "confirmEmail", code = code, userId = user.Id});

                    // отправка письма
                    await UserManager.SendEmailAsync(user.Id, "Подтверждение электронной почты",
                               "Для завершения регистрации перейдите по ссылке:: <a href=\""
                                                               + callbackUrl + "\">завершить регистрацию</a>");
                    
                    return Ok("На указанный электронный адрес отправлены дальнейшие инструкции по завершению регистрации"); 
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);

                    }
                }
            }

            return BadRequest(ModelState); ; 
        }
                       


        [AllowAnonymous]
        [HttpPost]
        [Route("Loginin")]
        public async Task<IHttpActionResult> Loginin(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await UserManager.FindAsync(model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    if (user.EmailConfirmed == true)
                    {
                        ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                        AuthenticationManager.SignOut();
                        AuthenticationManager.SignIn(new AuthenticationProperties
                        {
                            IsPersistent = true
                        }, claim);

                        var token = await GetAPIToken(model.Email, model.Password);
                        
                        return Ok(token);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Не подтвержден email.");
                    }
                   
                }
            }

            return BadRequest(ModelState);
        }

        private  async Task<JObject> GetAPIToken(string userName, string password)
        {
            using (var client = new HttpClient())
            {
                //setup client
                client.BaseAddress = new Uri(apiBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //setup login data
                var formContent = new FormUrlEncodedContent(new[]
                {
                 new KeyValuePair<string, string>("grant_type", "password"),
                 new KeyValuePair<string, string>("username", userName),
                 new KeyValuePair<string, string>("password", password),
                 });

                //send request
                HttpResponseMessage responseMessage = await client.PostAsync("/Token", formContent);

                //get access token from response body
                var responseJson = await responseMessage.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(responseJson);
                //return Json(jObject);
                return jObject;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("confirmEmail")]
        public async Task<IHttpActionResult> ConfirmEmail(string code, string userId)
        {
            
            if ((userId=="") || (code==""))
            {
                ModelState.AddModelError("", "Пользователь не зарегистрирован.");
                return BadRequest(ModelState);
            }

            var provider = new DpapiDataProtectionProvider("ApplicationName");
            UserManager.UserTokenProvider = new DataProtectorTokenProvider<User>(provider.Create("ASP.NET Identity"));

            IdentityResult result = await UserManager.ConfirmEmailAsync(userId, code);

            if (result.Succeeded)
            {
                //User user = UserManager.FindById(userId);
                //user.EmailConfirmed = true;
                //await UserManager.UpdateAsync(user);
                   
                return Ok("пользователь активирован");
            }
            else
            {
                    ModelState.AddModelError("", "Неверный email.");
            }
            
           
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("users")]
        public async Task<IHttpActionResult> GetAllUsers()
        {
            return Ok(UserManager.Users.ToList());
        }

        [HttpGet]
        [Route("user/{id:guid}", Name = "GetUserById")]
        public async Task<IHttpActionResult> GetUserById(string id)
        {
            var user = await UserManager.FindByIdAsync(id);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();

        }


        [HttpPost]
        [Route("edit-user")]
        public async Task<IHttpActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Get the current application user
                var user = await UserManager.FindByEmailAsync(model.Id.ToString());

                // Update the details
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                

                // This is the part that doesn't work
                var result = await UserManager.UpdateAsync(user);

                // However, it always succeeds inspite of not updating the database
                if (result.Succeeded)
                {
                    return Ok();
                } else
                {
                    return GetErrorResult(result);
                }
            }

            return BadRequest(ModelState);
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return this.Ok(new { message = "Logout successful." });
        }

        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword,
                model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        private IAuthenticationManager Authentication
        {
            get { return HttpContext.Current.GetOwinContext().Authentication; }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }      
       
}