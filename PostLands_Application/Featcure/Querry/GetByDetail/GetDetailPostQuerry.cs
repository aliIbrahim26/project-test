using AutoMapper;
using MediatR;
using PostLands_Application.Contract;

namespace PostLands_Application.Featcure.Querry.GetByDetail
{
    public class GetDetailPostQuerry:IRequest<GetPostDetailViewModel>
    {
        public Guid PostId { get; set; }

    }
    public class GetDetailPostHandler : IRequestHandler<GetDetailPostQuerry, GetPostDetailViewModel>
    {
        private readonly IMapper mapper;
        private readonly ISecondServicePost secondService;

        public GetDetailPostHandler(IMapper mapper,ISecondServicePost secondService)
        {
            this.mapper = mapper;
            this.secondService = secondService;
        }

        public async Task<GetPostDetailViewModel> Handle(GetDetailPostQuerry request, CancellationToken cancellationToken)
        {
           var result = await secondService.GetById(request.PostId);
           var resul =   mapper.Map<GetPostDetailViewModel>(result);
            return resul;

        }
    }
}
