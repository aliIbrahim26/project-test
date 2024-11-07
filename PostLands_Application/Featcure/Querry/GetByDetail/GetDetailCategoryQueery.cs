using AutoMapper;
using MediatR;
using PostLands_Application.Contract;
using PostLands_Application.Featcure.Querry.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLands_Application.Featcure.Querry.GetByDetail
{
    public class GetDetailCategoryQueery:IRequest<GetCategoryDetailViewModel>
    {
        public Guid Id { get; set; }
     
    }
    public class GetDetailCategoryHandler : IRequestHandler<GetDetailCategoryQueery, GetCategoryDetailViewModel>
    {
        private readonly IMapper mapper;
        private readonly ISecondServiceCategory secondService;

        public GetDetailCategoryHandler(IMapper mapper,ISecondServiceCategory secondService)
        {
            this.mapper = mapper;
            this.secondService = secondService;
        }
        public async Task<GetCategoryDetailViewModel> Handle(GetDetailCategoryQueery request, CancellationToken cancellationToken)
        {
            var result  = await secondService.GetById(request.Id);
            return mapper.Map<GetCategoryDetailViewModel>(result);    
        }
    }
}
