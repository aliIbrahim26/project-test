using AutoMapper;
using MediatR;
using PostLands_Application.Contract;
using PostLands_Domain;

namespace PostLands_Application.Featcure.Command.Create
{
    public class CreateCategoryQuerry:IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryQuerry, Guid>
    {
        private readonly IMapper mapper;
        private readonly ISecondServiceCategory secondService;

        public CreateCategoryHandler(IMapper mapper , ISecondServiceCategory secondService)
        {
            this.mapper = mapper;
            this.secondService = secondService;
        }
        public async Task<Guid> Handle(CreateCategoryQuerry request, CancellationToken cancellationToken)
        {
            var result =  mapper.Map<Category>(request);
            await secondService.Add(result);
            return result.Id;
        }
    }
}
