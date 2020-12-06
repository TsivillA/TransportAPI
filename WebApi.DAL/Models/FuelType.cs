using WebApi.Common.Enums;

namespace WebApi.DAL.Models
{
    public class FuelType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EntityStatus EntityStatus { get; set; }
    }
}
