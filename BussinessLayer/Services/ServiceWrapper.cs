
using UrbanDictionary.BussinessLayer.DTO;
using UrbanDictionary.BussinessLayer.DTO.Mapper;
using UrbanDictionary.BussinessLayer.Services.Contracts;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;


namespace UrbanDictionary.BussinessLayer.Services
{
    public class ServiceWrapper : IServiceWrapper
    {
        private IUserService _user;
        private ITagService _tag;
        private IWordService _word;
        private IRepositoryWrapper _repoWrapper;
        private IMapper<Word, WordDTO> _wordMapper;
        private IMapper<Tag, TagDTO> _tagMapper;

        public ServiceWrapper(IRepositoryWrapper repoWrapper, IMapper<Word, WordDTO> wordMapper, IMapper<Tag, TagDTO> tagMapper)
        {
            _repoWrapper = repoWrapper;
            _wordMapper = wordMapper;
            _tagMapper = tagMapper;
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
                    _word = new WordService(_repoWrapper, _wordMapper);
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
                    _tag = new TagService(_repoWrapper, _tagMapper);
                }

                return _tag;
            }
        }
    }
}
