using WebApi.Common.Enums;

namespace WebApi.DAL.Models
{
    public class VehicleOwner : IEntity
    {
        public int Id { get; set; }
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
        public Owner Owner { get; set; }
        public int OwnerId { get; set; }
        public EntityStatus EntityStatus { get; set; }
    }
}
