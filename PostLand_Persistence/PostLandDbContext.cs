using Microsoft.EntityFrameworkCore;
using PostLands_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand_Persistence
{
    public class PostLandDbContext : DbContext
    {
        public PostLandDbContext(DbContextOptions<PostLandDbContext> options) : base(options)
        {

        }
        public DbSet<Post> posts { get; set; }
        public DbSet<Category> categories { get; set; }

       
    }
}
