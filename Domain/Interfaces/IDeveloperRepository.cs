using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IDeveloperRepository : IGenericRepository<Developer>
    {
        IEnumerable<Developer> GerPopularDevelopers(int count);
    }
}