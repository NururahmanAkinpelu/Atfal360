using Atfal360.Entities;

namespace Atfal360.DTO
{
    public class StateDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public Guid? RegionId { get; set; }
        public string? RegionName { get; set; }
        public IList<Dila>? Dilas { get; set;}
    }
}
