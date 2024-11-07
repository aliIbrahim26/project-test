using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PostLand_Api.Helper;
using PostLand_Api.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PostLand_Api.Serfvices
{
    public class ServicePostLand : IServicePostLand
    {
       private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IOptions<JWT> jwt;
        private readonly JWT _Jwt;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ServicePostLand(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager, IOptions<JWT> jwt, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            this.signInManager = signInManager;
            this.jwt = jwt;
            _Jwt = jwt.Value;
            _roleManager = roleManager;
        }

        public async Task<Authmodel> RigsterAsync(RigsterModel model)
        {
           
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return new Authmodel { Message = " This email is used ! change It" };
            if (await _userManager.FindByNameAsync(model.UserName) is not null)
                return new Authmodel { Message = "This userName is used ! change It" };

           
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
               
            };
            var result =  await _userManager.CreateAsync(user,model.Password);
            await _userManager.AddToRoleAsync(user, "user");
            var JwtSecurityTokn = await CreateToken(user);

            var Eror = string.Empty;
            if (!result.Succeeded)
            {
                foreach (var eror in result.Errors)
                    Eror += eror.Description;
                return new Authmodel { Message = Eror };
            }

            return new Authmodel
            {
                
                Email = model.Email,
                IsAuthenticated = true,
                Expired = JwtSecurityTokn.ValidTo,
                Roles = new List<string> { "user" },
                Username = model.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(JwtSecurityTokn)
            };
            
            
        }
        public async Task <JwtSecurityToken> CreateToken(ApplicationUser user)
        {
            var userClaim = await _userManager.GetClaimsAsync(user);
            var roles= await _userManager.GetRolesAsync(user);
            var roleClaim = new List<Claim>();
            foreach (var role in roles)
            {
                roleClaim.Add(new Claim("user",role));
            }
            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,user.Id),
                new Claim("uid",user.Id),
            }
            .Union(roleClaim)
            .Union(userClaim);

           var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Jwt.Key));
           var signingCredentials = new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
             issuer: _Jwt.Issure,
             audience:_Jwt.Audeence,
             expires: DateTime.Now.AddDays(_Jwt.DurationOfDays),
             signingCredentials: signingCredentials,
             claims : Claims);
            return jwtSecurityToken;
            
        }

        public async Task<Authmodel> SignInAsync(SignIn model)
        {
            var authmodal = new Authmodel();
           var result = await _userManager.FindByEmailAsync(model.Email);
      
         
            if (result == null || !await _userManager.CheckPasswordAsync(result, model.Password))
            {
                authmodal.Message = "your email or password wrong";
                return authmodal;
            }
            var jwts = await CreateToken(result);
            var role = await _userManager.GetRolesAsync(result);

            authmodal.Email = result.Email;
            authmodal.Username = result.UserName;
            authmodal.IsAuthenticated = true;
            authmodal.Expired = jwts.ValidTo;
            authmodal.Roles = role.ToList();
            authmodal.Token = new JwtSecurityTokenHandler().WriteToken(jwts);

            return authmodal;
            
        }

        public async Task<string> AddRoleAsync(AddRole model)
        {
            var result = await _userManager.FindByIdAsync(model.Id);
            if (result is null || !await _roleManager.RoleExistsAsync(model.Name))
                return "yon not here";
            if (await _userManager.IsInRoleAsync(result, model.Name))
                return "you already have this role";

            var user = await _userManager.AddToRoleAsync(result, model.Name);
            if (!user.Succeeded)
            {
                return "some thing wrong";
            }
            return string.Empty;
                


        }
    }
}
