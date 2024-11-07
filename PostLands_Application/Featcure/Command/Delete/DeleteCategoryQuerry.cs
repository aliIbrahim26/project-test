using AutoMapper;
using MediatR;
using PostLands_Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLands_Application.Featcure.Command.Delete
{
    public class DeleteCategoryQuerry:IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryQuerry>
    {
        private readonly IMapper mapper;
        private readonly ISecondServiceCategory secondService;

        public DeleteCategoryHandler(IMapper mapper,ISecondServiceCategory secondService)
        {
            this.mapper = mapper;
            this.secondService = secondService;
        }


        public async Task<Unit> Handle(DeleteCategoryQuerry request, CancellationToken cancellationToken)
        {
            await secondService.Delete(request.Id);
            return Unit.Value;
         
        }
    }
}
