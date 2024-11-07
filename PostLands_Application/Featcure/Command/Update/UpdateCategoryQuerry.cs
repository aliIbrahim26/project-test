using AutoMapper;
using MediatR;
using PostLands_Application.Contract;
using PostLands_Domain;

namespace PostLands_Application.Featcure.Command.Update
{
    public class UpdateCategoryQuerry:IRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryQuerry>
    {
        private readonly IMapper mapper;
        private readonly ISecondServiceCategory secondService;

        public UpdateCategoryHandler(IMapper mapper,ISecondServiceCategory secondService)
        {
            this.mapper = mapper;
            this.secondService = secondService;
        }
        public async Task<Unit> Handle(UpdateCategoryQuerry request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<Category>(request);
            await secondService.Update(result);
            return Unit.Value;
        }
    }
}
