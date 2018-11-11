using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using ProjectsManagment.Data.Interfaces;
using ProjectsManagment.Data.Services;
using ProjectsManagment.Entity;
using ProjectsManagment.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace ProjectsManagment.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
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
                    //await UserManager.SendEmailAsync(user.Id, "Подтверждение электронной почты",
                    //           "Для завершения регистрации перейдите по ссылке:: <a href=\""
                    //                                           + callbackUrl + "\">завершить регистрацию</a>");
                    
                    return Ok(callbackUrl); 
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
        [Route("Logini")]
        public async Task<IHttpActionResult> Logini(LoginModel model)
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

                        return Ok("пользователь авторизован");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Не подтвержден email.");
                    }
                   
                }
            }

            return BadRequest(ModelState);
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

        

        [HttpPost]
        [AllowAnonymous]
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return this.Ok(new { message = "Logout successful." });
        }

        private IAuthenticationManager Authentication
        {
            get { return HttpContext.Current.GetOwinContext().Authentication; }
        }
    }      
       
}