using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services.Interfaces
{
    public interface IOwnerService
    {
        Task<int> AddOwner(OwnerCommandModel model);
        OwnerQueryModel GetOwner(int id);
        Task UpdateOwner(OwnerCommandModel model, int id);
        Task<bool> DeleteOwner(int id);
        IEnumerable<OwnerQueryModel> GetAllOwners();
    }
}
