﻿using System;
using System.Collections.Generic;
using System.Text;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;
using UrbanDictionary.Services;

namespace UrbanDictionary.BussinessLayer.DTO.Mapper
{
    public class TagServiceMapper : IMapper<Tag, TagDTO>
    {
        private IRepositoryWrapper _repoWrapper;

        public TagServiceMapper(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public TagDTO MapToDTO(Tag entity)
        {
            throw new NotImplementedException();
        }

        public Tag MapToEntity(TagDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
