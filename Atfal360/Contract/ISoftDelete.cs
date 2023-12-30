namespace Atfal360.Contract
{
    public interface ISoftDelete
    {
        DateTime? IsDeleteOn { get; set; }
        DateTime? IsDeleteBy { get; set; }
        bool IsDeleted { get; set; }
    }
}
