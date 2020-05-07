
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using UrbanDictionary.BusinessLayer.DTO;
using UrbanDictionary.BusinessLayer.DTO.Mapper;
using UrbanDictionary.BusinessLayer.Services.Contracts;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;


namespace UrbanDictionary.BusinessLayer.Services
{
    public class UserWordsService : IUserWordsService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IMapper<Word, WordDTO> _wordMapper;
        private readonly User _currentUser;

        public UserWordsService(IRepositoryWrapper repoWrapper, IHttpContextAccessor httpContextAccessor, IMapper<Word, WordDTO> wordMapper)
        {
            _repoWrapper = repoWrapper;
            _wordMapper = wordMapper;
            _currentUser = _repoWrapper.User.FindByCondition(u => u.UserName.Equals(httpContextAccessor.HttpContext.User.Identity.Name))
                   .FirstOrDefault();
        }

        public IEnumerable<WordDTO> GetSavedWords()
        {
            if (_currentUser != null)
            {
                var savedWords = from sw in _repoWrapper.UserSavedWords.FindAll()
                       where sw.UserId.Equals(_currentUser.Id)
                       join w in _repoWrapper.Word.FindAll() on sw.SavedWordId equals w.Id
                       select w;
                return _wordMapper.MapToDTO(savedWords);
            }
            return null;
        }

        public bool TryAddToSavedWords(long id)
        {
            Word word = _repoWrapper.Word.FindByCondition(w => w.Id.Equals(id)).FirstOrDefault();
            if (_currentUser != null && word != null)
            {
                UserSavedWord savedWord = _repoWrapper
                        .UserSavedWords.FindByCondition(sw => sw.UserId.Equals(_currentUser.Id) && sw.SavedWordId.Equals(word.Id))
                        .FirstOrDefault();
                if (savedWord == null)
                {
                    _repoWrapper.User.Attach(_currentUser);
                    _repoWrapper.Word.Attach(word);
                    UserSavedWord newSavedWord = new UserSavedWord { SavedWord = word, SavedWordId = word.Id, User = _currentUser, UserId = _currentUser.Id };
                    _repoWrapper.UserSavedWords.Create(newSavedWord);
                    _repoWrapper.Save();
                    return true;
                }
            }
            return false;
        }

        public bool TryDeleteSavedWord(long id)
        {
            if (_currentUser != null)
            {
                UserSavedWord savedWord = _repoWrapper
                        .UserSavedWords.FindByCondition(sw => sw.UserId.Equals(_currentUser.Id) && sw.SavedWordId.Equals(id))
                        .FirstOrDefault();
                if (savedWord != null)
                {
                    _repoWrapper.UserSavedWords.Delete(savedWord);
                    _repoWrapper.Save();
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<WordDTO> GetCreatedWords()
        {
            if (_currentUser != null)
            {
                var createdWords = _repoWrapper.Word.FindByCondition(w => w.AuthorId.Equals(_currentUser.Id));
                return _wordMapper.MapToDTO(createdWords);
            }
            return null;
        }

        public bool TryCreateWord(CreateEditFormWordDTO wordDto)
        {
            if (_currentUser != null)
            { 
                if (wordDto.Name == null || wordDto.Definition == null) return false;
                Word word = new Word { Definition = wordDto.Definition, Image = wordDto.Image, Example = wordDto.Example, Name = wordDto.Name,  AuthorId = _currentUser.Id };
                _repoWrapper.Word.Create(word);

                foreach (string tagName in wordDto.Tags.Distinct())
                {
                    Tag tag = _repoWrapper.Tag.FindByCondition(t => t.Name.Equals(tagName)).FirstOrDefault();
                    if (tag == null)
                    {
                        tag = new Tag();
                        tag.Name = tagName;
                        _repoWrapper.Tag.Create(tag);
                    }
                    else
                    {
                        _repoWrapper.Tag.Attach(tag);
                    }
                    WordTag wordTag = new WordTag { Tag = tag, Word = word, TagId = tag.Id, WordId = word.Id };
                    _repoWrapper.WordTag.Create(wordTag);
                }

                _repoWrapper.Save();
                return true;
            }
            return false;
        }

        public bool TryEditWord(CreateEditFormWordDTO wordDto)
        {
            if (_currentUser != null)
            { 
                if (wordDto.Name == null || wordDto.Definition == null) return false;

                Word word = _repoWrapper.Word.FindByCondition(w => w.Id.Equals(wordDto.Id) && w.AuthorId.Equals(_currentUser.Id)).FirstOrDefault();
                if (word != null)
                {
                    word.Image = wordDto.Image;
                    word.Name = wordDto.Name;
                    word.Definition = wordDto.Definition;
                    word.Example = wordDto.Example;
                    word.CreationDate = DateTime.Now;
                    word.WordStatus = WordStatus.OnModeration;

                    _repoWrapper.Word.Update(word);

                    Dictionary<string, Tag> oldTags = _repoWrapper.Tag.GetByWordId(word.Id).ToDictionary(t => t.Name, t => t);

                    foreach (string tagName in wordDto.Tags.Distinct())
                    {
                        if (!oldTags.Keys.Contains(tagName))
                        {
                            Tag tag = _repoWrapper.Tag.FindByCondition(t => t.Name.Equals(tagName)).FirstOrDefault();
                            if (tag == null)
                            {
                                tag = new Tag();
                                tag.Name = tagName;
                                _repoWrapper.Tag.Create(tag);
                            }
                            else
                            {
                                _repoWrapper.Tag.Attach(tag);
                            }
                            WordTag wordTag = new WordTag { Tag = tag, Word = word, TagId = tag.Id, WordId = word.Id };
                            _repoWrapper.WordTag.Create(wordTag);
                        }
                        else
                        {
                            oldTags.Remove(tagName);
                        }
                    }
                    foreach (Tag tag in oldTags.Values)
                    {
                        WordTag wordTag = _repoWrapper.WordTag.FindByCondition(wt => wt.TagId.Equals(tag.Id) && wt.WordId.Equals(word.Id)).FirstOrDefault();
                        _repoWrapper.WordTag.Delete(wordTag);
                    }

                    _repoWrapper.Save();
                    return true;
                }
            }
            return false;
        }
    }
}
