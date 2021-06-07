using Common.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IDeveloperService : IGenericServices<DeveloperDTO>
    {
        IEnumerable<DeveloperDTO> GerPopularDevelopers(int count);
    }
}
