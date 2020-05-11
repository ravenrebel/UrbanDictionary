
using UrbanDictionary.DataAccess.Data;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;

namespace UrbanDictionary.DataAccess.Repositories
{
    /// <inheritdoc cref="IWordTagRepository"/>
    class WordTagRepository : RepositoryBase<WordTag>, IWordTagRepository
    {
        private readonly UrbanDictionaryDBContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public WordTagRepository(UrbanDictionaryDBContext dbContext)
            : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
