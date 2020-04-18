using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using UrbanDictionary.BusinessLayer.DTO;
using UrbanDictionary.BusinessLayer.DTO.Mapper;
using UrbanDictionary.BusinessLayer.Services.Contracts;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;


namespace UrbanDictionary.BusinessLayer.Services
{
    public class TagService : ITagService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IMapper<Tag, TagDTO> _mapper;

        public TagService(IRepositoryWrapper repoWrapper, IMapper<Tag, TagDTO> mapper)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
        }

        public bool TryDelete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
