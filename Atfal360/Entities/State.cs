using Atfal360.Contract;

namespace Atfal360.Entities
{
    public class State : AuditableEntity
    {
        public string Name { get; set; }
        public IList<Dila>? Dilas { get; set; }
        public Region Region { get; set; }
        public Guid? RegionId { get; set; }
    }
}
