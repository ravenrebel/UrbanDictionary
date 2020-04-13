using System;
using System.Collections.Generic;
using System.Text;
using UrbanDictionary.BussinessLayer.DTO;
using UrbanDictionary.BussinessLayer.DTO.Mapper;
using UrbanDictionary.BussinessLayer.Services.Contracts;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;


namespace UrbanDictionary.BussinessLayer.Services
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
    }
}
