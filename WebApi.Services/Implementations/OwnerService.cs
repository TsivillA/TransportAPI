using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DAL.Models;
using WebApi.DAL.Unit_of_Work;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Implementations
{
    public class OwnerService : IOwnerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OwnerService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> AddOwner(OwnerCommandModel model)
        {
            try
            {
                return await _unitOfWork.Owner.AddAsync(_mapper.Map<Owner>(model));
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlException &&
                sqlException.Number == 2601)

            {
                if (ex.InnerException.Message.Contains("IX_Owners_PersonalId"))
                    return -1;

                return 0;
            }
        }

        public async Task<bool> DeleteOwner(int id)
        {
            var owner = _unitOfWork.Owner.GetAsync(id);
            if (owner == null)
            {
                return false;
            }
            await _unitOfWork.Owner.Delete(owner);

            return true;
        }

        public IEnumerable<OwnerQueryModel> GetAllOwners()
        {
            var owners = _unitOfWork.Owner.GetAllAsync().ToList();
            return _mapper.Map<IEnumerable<OwnerQueryModel>>(owners);
        }

        public OwnerQueryModel GetOwner(int id)
        {
            var owner = _unitOfWork.Owner.GetAsync(id);
            return _mapper.Map<OwnerQueryModel>(owner);
        }

        public async Task UpdateOwner(OwnerCommandModel model, int id)
        {
            var owner = _mapper.Map<Owner>(model);
            owner.Id = id;

            await _unitOfWork.Owner.Update(owner);
        }
    }
}
