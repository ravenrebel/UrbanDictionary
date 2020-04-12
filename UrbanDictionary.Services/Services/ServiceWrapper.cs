
using UrbanDictionary.BussinessLayer.Services.Contracts;
using UrbanDictionary.DataAccess.Repositories.Contracts;

namespace UrbanDictionary.BussinessLayer.Services
{
    public class ServiceWrapper : IServiceWrapper
    {
        private IUserService _user;
        private ITagService _tag;
        private IWordService _word;
        private IRepositoryWrapper _repoWrapper;

        public ServiceWrapper(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public IUserService User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserService(_repoWrapper);
                }

                return _user;
            }
        }

        public IWordService Word
        {
            get
            {
                if (_word == null)
                {
                    _word = new WordService(_repoWrapper);
                }

                return _word;
            }
        }

        public ITagService Tag
        {
            get
            {
                if (_tag == null)
                {
                    _tag = new TagService(_repoWrapper);
                }

                return _tag;
            }
        }
    }
}
