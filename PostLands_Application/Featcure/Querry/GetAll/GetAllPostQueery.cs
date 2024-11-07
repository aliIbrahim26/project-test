using AutoMapper;
using MediatR;
using PostLands_Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLands_Application.Featcure.Querry.GetAll
{
    public class GetAllPostQueery:IRequest<List<GetPostViewModel>>
    {
    }

    public class GetAllPostHandler : IRequestHandler<GetAllPostQueery, List<GetPostViewModel>>
    {
        private readonly IMapper mapper;
        private readonly ISecondServicePost secondService;

        public GetAllPostHandler(IMapper mapper ,ISecondServicePost secondService)
        {
            this.mapper = mapper;
            this.secondService = secondService;
        }
        public async Task<List<GetPostViewModel>> Handle(GetAllPostQueery request, CancellationToken cancellationToken)
        {
            var result = await secondService.GetAll();
         return  mapper.Map<List<GetPostViewModel>>(result);
        }
    }
}
