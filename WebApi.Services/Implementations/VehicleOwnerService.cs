using AutoMapper;
using System.Threading.Tasks;
using WebApi.DAL.Models;
using WebApi.DAL.Unit_of_Work;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Implementations
{
    public class VehicleOwnerService : IVehicleOwnerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleOwnerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<(int, string)> AddVehicleOwner(VehicleOwnerCommandModel vehicleOwner)
        {
            var owner = _unitOfWork.Owner.GetAsync(vehicleOwner.OwnerId);
            if (owner == null)
            {
                return (-1, "Owner not found");
            }

            var vehicle = _unitOfWork.Vehicle.GetAsync(vehicleOwner.VehicleId);
            if (vehicle == null)
            {
                return (-1, "Vehicle not found");
            }

            var vehicleOwnerId = await _unitOfWork.VehicleOwner.AddAsync(_mapper.Map<VehicleOwner>(vehicleOwner));

            return (vehicleOwnerId, null);
        }
    }
}
