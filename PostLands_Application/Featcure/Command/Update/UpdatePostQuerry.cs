using AutoMapper;
using MediatR;
using PostLands_Application.Contract;
using PostLands_Domain;

namespace PostLands_Application.Featcure.Command.Update
{
    public class UpdatePostQuerry:IRequest
    {

        public Guid PostId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Summary { get; set; }
        public string? Author { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime DateTime { get; set; }

        public class UpdatePostHandler : IRequestHandler<UpdatePostQuerry>
        {
            private readonly IMapper mapper;
            private readonly ISecondServicePost secondService;

            public UpdatePostHandler(IMapper mapper, ISecondServicePost secondService)
            {
                this.mapper = mapper;
                this.secondService = secondService;
            }
            public async Task<Unit> Handle(UpdatePostQuerry request, CancellationToken cancellationToken)
            {
                var result = mapper.Map<Post>(request);
                await secondService.Update(result);
                return Unit.Value;
            }
        }
    }
}
