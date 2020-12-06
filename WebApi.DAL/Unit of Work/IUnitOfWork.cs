using System;
using WebApi.DAL.Models;
using WebApi.DAL.Repository;

namespace WebApi.DAL.Unit_of_Work
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Owner> Owner { get; }
        IRepository<Vehicle> Vehicle { get; }
        IRepository<VehicleOwner> VehicleOwner { get; }
        int Complete();
    }
}
