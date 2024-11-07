using Microsoft.EntityFrameworkCore;
using PostLands_Application.Contract;
using PostLands_Domain;

namespace PostLand_Persistence.Repositories
{
    public class ServicePostRepo : GenricRepo<Post>, ISecondServicePost
    {
        public ServicePostRepo(PostLandDbContext Db) : base(Db)
        {
        }
    }
}
