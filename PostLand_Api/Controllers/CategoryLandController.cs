using MediatR;
using Microsoft.AspNetCore.Mvc;
using PostLands_Application.Featcure.Command.Create;
using PostLands_Application.Featcure.Command.Delete;
using PostLands_Application.Featcure.Command.Update;
using PostLands_Application.Featcure.Querry.GetAll;
using PostLands_Application.Featcure.Querry.GetByDetail;

namespace PostLand_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryLandController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryLandController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("GetAll", Name = "Get All")]
        public async Task<ActionResult<GetCategoryViewModel>> GetAllCategory()
        {
            var result = await mediator.Send(new GetAllCategoryQuerry());
            return Ok(result);
        }

        [HttpGet("GetById", Name = "GetBy Id")]
        public async Task<ActionResult<GetDetailCategoryQueery>> GetById(Guid id)
        {
            var result = new GetDetailCategoryQueery() { Id = id };

            return Ok(await mediator.Send(result));
        }
        

        [HttpPost]
        public async Task <ActionResult<Guid>> CreateCategory([FromBody]CreateCategoryQuerry createCategoryQuerry)
        {
            var result = await mediator.Send(createCategoryQuerry);
            return Ok(createCategoryQuerry.Id);
        }

        [HttpPut("UpdateCategory")]
        public async Task<ActionResult> UpdatePostLand([FromBody] UpdateCategoryQuerry updateCategoryQuerry)
        {
            var result = await mediator.Send(updateCategoryQuerry);
            return Ok(result);
        }
        [HttpDelete("DeleteCategory")]
        public async Task<ActionResult> DeletePost(Guid id)
        {

            var result = await mediator.Send(new DeleteCategoryQuerry() { Id = id });
            return Ok(result);

        }
    }
}
