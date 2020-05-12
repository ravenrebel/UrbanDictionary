
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.BusinessLayer.Services.Contracts
{
    /// <summary>
    /// Contains methods for performing actions with <see cref="Tag"/>s.
    /// </summary>
    public interface ITagService
    {
        bool TryDelete(long id);
    }
}
