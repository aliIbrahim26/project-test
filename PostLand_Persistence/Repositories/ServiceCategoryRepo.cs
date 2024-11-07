using PostLands_Application.Contract;
using PostLands_Domain;

namespace PostLand_Persistence.Repositories
{
    public class ServiceCategoryRepo : GenricRepo<Category>, ISecondServiceCategory
    {
        public ServiceCategoryRepo(PostLandDbContext Db) : base(Db)
        {
        }
    }
}
