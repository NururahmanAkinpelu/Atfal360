using Atfal360.Entities;

namespace Atfal360.DTO
{
    public class DilaDto
    {
        public Guid? Id {  get; set; }
        public string Name { get; set; }
        public Guid? StateId { get; set; }
        public string? StateName { get; set; }
        public IList<Muqami>? Muqamis { get; set; }
    }
}
