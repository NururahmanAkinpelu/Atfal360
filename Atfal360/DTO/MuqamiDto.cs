using Atfal360.Entities;

namespace Atfal360.DTO
{
    public class MuqamiDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public IList<Tifl>? Atfal {  get; set; }
        public Guid? DilaId { get; set; }
        public string? DilaName { get; set; }
    }
}
