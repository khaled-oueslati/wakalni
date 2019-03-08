using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using wakalni.DTO;
using wakalni.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace wakalni.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration _config { get; }
        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;
        public TokenController(IConfiguration config, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _config = config;
            this._signInManager = signInManager;
            this._userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginAction(LoginModel login)
        {
            IActionResult response = Unauthorized();
            
            var resultSigningIn = await _signInManager.PasswordSignInAsync(login.Username, login.Password, isPersistent: false, lockoutOnFailure: false);

            if (resultSigningIn.Succeeded)
            {
                var token = BuildToken(await GetClaimsToToken(login.Username));
                return Ok(new { token });
            }

            return response;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAction(UserDTO userDto)
        {
            IActionResult response = BadRequest();

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = userDto.Username,
                    Email = userDto.Email,
                    Name = userDto.FirstName,
                    LastName = userDto.LastName,
                    Birthdate = userDto.Birthdate
                };
                var createUserResult =await _userManager.CreateAsync(user,userDto.Password);
                if (createUserResult.Succeeded)
                {
                    //_logger.LogInformation("User created a new account with password.");

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { userId = user.Id, code = code },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                    await _userManager.AddToRoleAsync( user, "SuperAdmin");
                    await _signInManager.SignInAsync(user, isPersistent: false);


                    if (user != null)
                    {
                        var tokenString = BuildToken( await GetClaimsToToken(user.Email));
                        response = Ok(new { token = tokenString });
                    }

                    return response;
                }
            }
            return response;
        }

        private string BuildToken(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds,
              claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        private async Task<Claim[]> GetClaimsToToken(string clue)
        {
            ApplicationUser appUser = null;
            if (Utils.IsEmailValid(clue))
                appUser = await _userManager.FindByEmailAsync(clue);
            else
                appUser = await _userManager.FindByNameAsync(clue);
            return new Claim[] {
                  new Claim(ClaimTypes.Name,appUser.Name),
                  new Claim(ClaimTypes.Email,appUser.Email),
                  new Claim(ClaimTypes.DateOfBirth,appUser.Birthdate.ToString()),
                  new Claim(ClaimTypes.Role,String.Join(",",(await _userManager.GetRolesAsync(appUser)))),
              };
        }

    }
}