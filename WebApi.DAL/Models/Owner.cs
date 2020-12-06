using System.Collections.Generic;
using WebApi.Common.Enums;

namespace WebApi.DAL.Models
{
    public class Owner : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
        public ICollection<VehicleOwner> VehicleOwner { get; set; }
        public EntityStatus EntityStatus { get; set; }
    }
}
