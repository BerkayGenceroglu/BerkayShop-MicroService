using BerkayShop.IdentityServer.Dtos;
using BerkayShop.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace BerkayShop.IdentityServer.Controllers
{

    //LocalApi.PolicyName şunu ister:
    //✔️ Token olacak
    //✔️ Token geçerli olacak
    ////✔️ Token içinde LocalApi scope(IdentityServerApi) olacak
    //[Authorize(LocalApi.PolicyName)] /*Bu endpoint, SADECE IdentityServer’ın kendi ürettiği ve IdentityServerApi scope’u olan token’larla açılır.”.*/
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto dto)
        {
            var user = new ApplicationUser
            {
                Name = dto.Name,
                Surname = dto.Surname,
                UserName = dto.UserName,
                Email = dto.Email
            };
           var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                return Ok("Kullanıcı Başarılı Bir Şekilde Oluşturuldu.");
            }
            return BadRequest("Kullanıcı Oluşturulurken Bir Hata Oluştu" + result.Errors.Select(y =>y.Description));
        }
    }
}
