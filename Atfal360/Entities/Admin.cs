using Atfal360.Contract;

namespace Atfal360.Entities
{
    public class Admin :AuditableEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
