using AutoMapper;
using MediatR;
using PostLands_Application.Contract;
using PostLands_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLands_Application.Featcure.Command.Create
{
    public class CreatePostQuerry:IRequest<Guid>
    {
        public Guid PostId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Summary { get; set; }
        public string? Author { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime DateTime { get; set; }
    }
    public class CreatePostHandler : IRequestHandler<CreatePostQuerry, Guid>
    {
        private readonly IMapper mapper;
        private readonly ISecondServicePost secondService;

        public CreatePostHandler(IMapper mapper , ISecondServicePost secondService)
        {
            this.mapper = mapper;
            this.secondService = secondService;
        }
        public async Task<Guid> Handle(CreatePostQuerry request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<Post>(request);
            await secondService.Add(result);
            return result.PostId;
        }
    }
}
