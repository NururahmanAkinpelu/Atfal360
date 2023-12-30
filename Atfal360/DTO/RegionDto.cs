using Atfal360.Entities;

namespace Atfal360.DTO
{
    public class RegionDto
    {
        public Guid? Id { get; set; } 
        public string Name { get; set; }
        public IList<State>? States { get; set; }
    }
}
