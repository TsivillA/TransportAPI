using WebApi.DAL.Models;
using WebApi.DAL.Repository;

namespace WebApi.DAL.Unit_of_Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TransportDbContext _context;
        public IRepository<Owner> Owner { get; private set; }
        public IRepository<Vehicle> Vehicle { get; private set; }
        public IRepository<VehicleOwner> VehicleOwner { get; private set; }

        public UnitOfWork(TransportDbContext context)
        {
            _context = context;
            Owner = new Repository<Owner>(_context);
            Vehicle = new Repository<Vehicle>(_context);
            VehicleOwner = new Repository<VehicleOwner>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
