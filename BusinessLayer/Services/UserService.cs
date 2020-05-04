
using System.Linq;
using UrbanDictionary.BusinessLayer.Services.Contracts;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;

namespace UrbanDictionary.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public UserService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public void Save()
        {
            _repoWrapper.Save();
        }
    }
}
