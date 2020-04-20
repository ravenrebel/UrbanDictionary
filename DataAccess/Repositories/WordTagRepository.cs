
using UrbanDictionary.DataAccess.Data;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;

namespace UrbanDictionary.DataAccess.Repositories
{
    class WordTagRepository : RepositoryBase<WordTag>, IWordTagRepository
    {
        private readonly UrbanDictionaryDBContext _context;

        public WordTagRepository(UrbanDictionaryDBContext dbContext)
            : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
