using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<int> AddVehicle(VehicleCommandModel model);
        VehicleQueryModel GetVehicle(int id);
        Task UpdateVehicle(VehicleCommandModel model, int id);
        Task<bool> DeleteVehicle(int id);
        IEnumerable<VehicleQueryModel> GetAllVehicles(PaginationModel paginationmodel, VehicleFilterModel vehicleFilterModel);
        Task ConfigureImage(string imageName, int vehicleId);
    }
}
