using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostLands_Application.Featcure.Command.Create;
using PostLands_Application.Featcure.Command.Delete;
using PostLands_Application.Featcure.Command.Update;
using PostLands_Application.Featcure.Querry.GetAll;
using PostLands_Application.Featcure.Querry.GetByDetail;

namespace PostLand_Api.Controllers
{
    [ProducesResponseType(200)]
    [ProducesResponseType(201)]
    [ProducesResponseType(202)]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [Route("api/[controller]")]
    [ApiController]
    public class PostLandController : ControllerBase
    {
        private readonly IMediator mediator;

        public PostLandController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("GetAll", Name ="GetAll")]
        public async Task<ActionResult<GetPostViewModel>> GetAllPost()
        {
            var result = await mediator.Send(new GetAllPostQueery());
            return Ok(result);
        }

        [HttpGet("GetById", Name = "GetById")]

        public async Task<ActionResult<GetPostDetailViewModel>> GetById(Guid id)
        {

            var result = new GetDetailPostQuerry() { PostId = id };
            if(result is null)
            {
                return NotFound();
            }
               

            return Ok(await mediator.Send(result));
        }
        [HttpPost("CreatePost")]
        public async Task<ActionResult<Guid>> CreatePostLand([FromBody] CreatePostQuerry createPostQuerry)
        {
            var result = await mediator.Send(createPostQuerry);
            return Ok(createPostQuerry.PostId);
        }
        [HttpPut("UpdatePost")]
        public async Task<ActionResult> UpdatePostLand([FromBody] UpdatePostQuerry updatePostQuerry)
        {
            var result = await mediator.Send(updatePostQuerry);
            return Ok(result);
        }
        [HttpDelete("DeletePost")]
        public async Task<ActionResult> DeletePost(Guid id)
        {
 
           var result = await mediator.Send(new DeletePostQuerry() { Id = id});
            return Ok(result);
        }

    }
}
