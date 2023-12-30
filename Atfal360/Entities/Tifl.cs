using Atfal360.Contract;
using Atfal360.Enum;

namespace Atfal360.Entities
{
    public class Tifl : AuditableEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string? Category { get; set; }
        public Muqami Muqami { get; set; }
        public Guid? MuqamiId { get; set; }
        
    }
}
