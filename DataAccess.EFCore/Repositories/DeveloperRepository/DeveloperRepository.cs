using Common.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class DeveloperRepository : GenericRepository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<Developer> GerPopularDevelopers(int count) =>
            Context.Developers.OrderByDescending(x => x.Followers).Take(count).ToList();
    }
}