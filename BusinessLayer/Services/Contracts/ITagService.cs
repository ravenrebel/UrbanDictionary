
namespace UrbanDictionary.BusinessLayer.Services.Contracts
{
    public interface ITagService
    {
        bool TryCreate(string name);
        bool TryDelete(long id);
    }
}
