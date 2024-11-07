using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLands_Application.Featcure.Querry.GetByDetail
{
    public class GetPostDetailViewModel
    {
        public Guid PostId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Summary { get; set; }
        public string? Author { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
