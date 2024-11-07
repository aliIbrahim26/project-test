using Microsoft.EntityFrameworkCore;
using PostLands_Application.Contract;
using PostLands_Domain;
using System.Security.Cryptography.X509Certificates;

namespace PostLand_Persistence.Repositories
{
    public class GenricRepo<T> : IBasicService<T> where T : class
    {
        private readonly PostLandDbContext db;

        public GenricRepo(PostLandDbContext Db)
        {
            db = Db;
        }

        public async Task Add(T entity)
        {
           var result =  db.Set<T>().Add(entity);
          await db.SaveChangesAsync();   
        }

        public async Task Delete(Guid id)
        {

          var result = await db.Set<T>().FindAsync(id);
            db.Remove(result);
             db.SaveChanges();
        }

        public async Task<List<T>> GetAll()
        {
           var result = await db.Set<T>().ToListAsync();
            return result;
        }

        public async Task<T> GetById(Guid id)
        {
            var result = await db.Set<T>().FindAsync(id);
            return result;

        }

        public async Task Update(T entity)
        {
          db.Entry(entity).State = EntityState.Modified;
            db.Set<T>().Update(entity);
           await db.SaveChangesAsync();

        }
    }
}
