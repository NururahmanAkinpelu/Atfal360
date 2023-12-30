using Atfal360.Contract;

namespace Atfal360.Entities
{
    public class Region : AuditableEntity
    {
        public string Name { get; set; }
        public IList<State>? States { get; set; }
        
    }
}
