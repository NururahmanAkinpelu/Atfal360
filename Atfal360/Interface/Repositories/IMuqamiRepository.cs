using Atfal360.Entities;
using System.Linq.Expressions;

namespace Atfal360.Interface.Repositories
{
    public interface IMuqamiRepository : IBaseRepository<Muqami>
    {
        Task<Muqami> GetMuqamiDetails(Expression<Func<Muqami, bool>> expression);
        Task<IList<Muqami>> GetMuqamisDetails(Expression<Func<Muqami, bool>> expression);
    }
}
