using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using WebApi.Common.Enums;
using WebApi.DAL.Models;
using WebApi.DAL.Unit_of_Work;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Implementations
{
    public class VehicleService : IVehicleService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VehicleService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> AddVehicle(VehicleCommandModel model)
        {
            var vehicle = _mapper.Map<Vehicle>(model);

            return await _unitOfWork.Vehicle.AddAsync(vehicle);
        }

        public async Task<bool> DeleteVehicle(int id)
        {
            var vehicle = _unitOfWork.Vehicle.GetAsync(id);
            if (vehicle == null)
            {
                return false;
            }
            await _unitOfWork.Vehicle.Delete(vehicle);

            return true;
        }

        public IEnumerable<VehicleQueryModel> GetAllVehicles(PaginationModel paginationmodel, VehicleFilterModel vehicleFilterModel)
        {
            var query = _unitOfWork.Vehicle.GetAllAsync(true, "FuelType", v => v.Include(x => x.VehicleOwner)
                    .ThenInclude(x => x.Owner));

            query = FilterVehicles(vehicleFilterModel, query);

            if (paginationmodel.IsAscending)
            {
                query = query.OrderBy(paginationmodel.SortBy);
            }
            else
            {
                query = query.OrderBy(paginationmodel.SortBy + " descending");
            }

            var vehicles = query.Skip((paginationmodel.CurrentPage - 1) * paginationmodel.PageSize)
                .Take(paginationmodel.PageSize).ToList();

            if (vehicles == null)
                return null;

            var result = new List<VehicleQueryModel>();

            foreach (var item in vehicles)
            {
                var vehicle = MapVehicle(item);
                if (vehicle != null)
                    result.Add(vehicle);
            }

            return result;
        }

        public VehicleQueryModel GetVehicle(int id)
        {
            var vehicle = _unitOfWork.Vehicle.GetAsync(id, "FuelType", v => v.Include(x => x.VehicleOwner)
                    .ThenInclude(x => x.Owner));

            return MapVehicle(vehicle);
        }

        public async Task UpdateVehicle(VehicleCommandModel model, int id)
        {
            var vehicle = _mapper.Map<Vehicle>(model);
            vehicle.Id = id;

            await _unitOfWork.Vehicle.Update(vehicle);
        }

        private VehicleQueryModel MapVehicle(Vehicle vehicle)
        {
            var result = _mapper.Map<VehicleQueryModel>(vehicle);

            if (vehicle?.VehicleOwner == null || vehicle.VehicleOwner.All(x => x.Owner == null))
                return result;

            var owners = new List<OwnerQueryModel>();

            foreach (var vehicleOwner in vehicle.VehicleOwner)
            {
                var owner = _mapper.Map<OwnerQueryModel>(vehicleOwner.Owner);
                if (owner != null)
                {
                    owners.Add(owner);
                }
            }
            if (owners != null)
                result.Owners = owners;

            return result;
        }

        public async Task ConfigureImage(string imageName, int vehicleId)
        {
            var vehicle = _unitOfWork.Vehicle.GetAsync(vehicleId);

            if (vehicle == null)
            {
                return;
            }
            vehicle.ImageName = imageName;
            await _unitOfWork.Vehicle.Update(vehicle);
        }

        private IQueryable<Vehicle> FilterVehicles(VehicleFilterModel filter, IQueryable<Vehicle> query)
        {
            if (!string.IsNullOrWhiteSpace(filter.MakeGe))
            {
                query = query.Where(x => x.MakeGe.ToUpper().StartsWith(filter.MakeGe.ToUpper()));
            }
            if (!string.IsNullOrWhiteSpace(filter.MakeEn))
            {
                query = query.Where(x => x.MakeEn.ToUpper().StartsWith(filter.MakeEn.ToUpper()));
            }
            if (!string.IsNullOrWhiteSpace(filter.ModelGe))
            {
                query = query.Where(x => x.ModelGe.ToUpper().StartsWith(filter.ModelGe.ToUpper()));
            }
            if (!string.IsNullOrWhiteSpace(filter.ModelEn))
            {
                query = query.Where(x => x.ModelEn.ToUpper().StartsWith(filter.ModelEn.ToUpper()));
            }
            if (!string.IsNullOrWhiteSpace(filter.Vin))
            {
                query = query.Where(x => x.Vin.ToUpper().StartsWith(filter.Vin.ToUpper()));
            }
            if (!string.IsNullOrWhiteSpace(filter.RegistrationPlate))
            {
                query = query.Where(x => x.RegistrationPlate.ToUpper().StartsWith(filter.RegistrationPlate.ToUpper()));
            }
            if (filter.Color != null && Enum.IsDefined(typeof(Color), filter.Color))
            {
                query = query.Where(x => x.Color == filter.Color);
            }
            if (filter.FuelTypeId != null)
            {
                query = query.Where(x => x.FuelTypeId == filter.FuelTypeId);
            }

            return query;
        }
    }
}
