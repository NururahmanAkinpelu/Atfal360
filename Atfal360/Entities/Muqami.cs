using Atfal360.Contract;

namespace Atfal360.Entities
{
    public class Muqami : AuditableEntity
    {
        public string Name { get; set; }
        public IList<Tifl> Tifl { get; set; }
        public Dila Dila { get; set; }
        public Guid? DilaId { get; set; }
    }
}
