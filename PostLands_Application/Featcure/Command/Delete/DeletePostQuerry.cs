using AutoMapper;
using MediatR;
using PostLands_Application.Contract;
using PostLands_Domain;

namespace PostLands_Application.Featcure.Command.Delete
{
    public class DeletePostQuerry:IRequest
    {
        public Guid Id { get; set; }
   
    }
    public class DeletePostHandler : IRequestHandler<DeletePostQuerry>
    {
        private readonly IMapper mapper;
        private readonly ISecondServicePost secondService;

        public DeletePostHandler(IMapper mapper ,ISecondServicePost secondService)
        {
            this.mapper = mapper;
            this.secondService = secondService;
        }
        public async Task<Unit> Handle(DeletePostQuerry request, CancellationToken cancellationToken)
        {
       
            await secondService.Delete(request.Id);
            return Unit.Value;
           
        }
    }
}
