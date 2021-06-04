using Common.Entities;
using System.Collections.Generic;


namespace DAL.Repositories
{
    public interface IDeveloperRepository : IGenericRepository<Developer>
    {
        IEnumerable<Developer> GerPopularDevelopers(int count);
    }
}