using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;


namespace UrbanDictionary.BusinessLayer.DTO.Mapper
{
    /// <inheritdoc cref="IMapper{TEntity, TDTO}"/>
    public class WordServiceMapper : IMapper<Word, WordDTO>
    {
        private IRepositoryWrapper _repoWrapper;

        public WordServiceMapper(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public WordDTO MapToDTO(Word entity)
        {
            WordDTO dto = new WordDTO();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Definition = entity.Definition;
            dto.Example = entity.Example;
            dto.Image = entity.Image;
            dto.LikesCount = entity.LikesCount;
            dto.DislikesCount = entity.DislikesCount;
            dto.CreationDate = entity.CreationDate;
            dto.WordStatus = entity.WordStatus;
            dto.AuthorName = _repoWrapper.User.FindByCondition(u => u.Id.Equals(entity.AuthorId)).FirstOrDefault()?.UserName;
            IEnumerable<string> tags = _repoWrapper.Tag.FindByCondition(t => t.WordTags.Any(w => w.WordId.Equals(entity.Id))).Select(t => t.Name);
            dto.Tags = tags;

            return dto;
        }

        public Word MapToEntity(WordDTO dto)
        {
            Word entity = new Word();
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            entity.Definition = dto.Definition;
            entity.Example = dto.Example;
            entity.Image = dto.Image;
            entity.LikesCount = dto.LikesCount;
            entity.DislikesCount = dto.DislikesCount;
            entity.CreationDate = dto.CreationDate;
            entity.WordStatus = dto.WordStatus;
            entity.AuthorId = _repoWrapper.User.FindByCondition(u => u.UserName.Equals(dto.AuthorName)).FirstOrDefault()?.Id;

            return entity;
        }
    }
}
