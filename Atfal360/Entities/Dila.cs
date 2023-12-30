using Atfal360.Contract;

namespace Atfal360.Entities
{
    public class Dila : AuditableEntity
    {
        public string Name { get; set; }
        public IList<Muqami> Muqami { get; set;}
        public State State { get; set; }
        public Guid? StateId { get; set; }
    }
}
