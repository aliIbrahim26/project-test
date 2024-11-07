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
    public class GetAllCategoryQuerry:IRequest<List<GetCategoryViewModel>>
    {
    }

    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuerry, List<GetCategoryViewModel>>
    {
        private readonly IMapper mapper;
        private readonly ISecondServiceCategory secondService;

        public GetAllCategoryHandler(IMapper mapper , ISecondServiceCategory secondService)
        {
            this.mapper = mapper;
            this.secondService = secondService;
        }
        public async Task<List<GetCategoryViewModel>> Handle(GetAllCategoryQuerry request, CancellationToken cancellationToken)
        {
            var result = await secondService.GetAll();
            return mapper.Map<List<GetCategoryViewModel>>(result);
        }
    }
}
