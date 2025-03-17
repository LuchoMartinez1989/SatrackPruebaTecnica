using Application.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Persistense.Contexts;

namespace Persistense.Repository
{
    public class MyRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        /// <summary>
        /// metodo para crear contexto de BD
        /// </summary>
        /// <param name="dbContext"></param>
        public MyRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
