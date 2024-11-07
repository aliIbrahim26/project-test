using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostLand_Api.Model;
using PostLand_Api.Serfvices;

namespace PostLand_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
     private readonly IServicePostLand _postLand;
        public JWTController(IServicePostLand postLand)
        {
            _postLand = postLand;
        }
        [HttpPost]
      public  async Task <ActionResult> RigsterAsync([FromBody]RigsterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _postLand.RigsterAsync(model);
            if(!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn([FromBody] SignIn model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _postLand.SignInAsync(model);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("AddRole")]
        public async Task<ActionResult> AddRole([FromBody] AddRole model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _postLand.AddRoleAsync(model);
            if (string.IsNullOrEmpty(result))
            {
                return Ok(model);
            }
           
            return BadRequest(result);
        }

    }
}
