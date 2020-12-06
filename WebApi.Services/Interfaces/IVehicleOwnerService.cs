using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services.Interfaces
{
    public interface IVehicleOwnerService
    {
        Task<(int, string)> AddVehicleOwner(VehicleOwnerCommandModel vehicleOwner);
    }
}
