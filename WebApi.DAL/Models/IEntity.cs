using WebApi.Common.Enums;

namespace WebApi.DAL.Models
{
    public interface IEntity
    {
        int Id { get; }
        public EntityStatus EntityStatus { get; set; }
    }
}
