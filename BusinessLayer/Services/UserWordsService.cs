
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
    /// <inheritdoc cref="IUserWordsService"/>
    public class UserWordsService : IUserWordsService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IMapper<Word, WordDTO> _wordMapper;
        private readonly User _currentUser;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repoWrapper">Repository</param>
        /// <param name="httpContextAccessor">HttpContext</param>
        /// <param name="wordMapper">Mapper</param>
        public UserWordsService(IRepositoryWrapper repoWrapper, IHttpContextAccessor httpContextAccessor, IMapper<Word, WordDTO> wordMapper)
        {
            _repoWrapper = repoWrapper;
            _wordMapper = wordMapper;
            _currentUser = _repoWrapper?.User.FindByCondition(u => u.UserName == httpContextAccessor.HttpContext.User.Identity.Name)
                   .FirstOrDefault();
        }

        public IEnumerable<WordDTO> GetSavedWords()
        {
            if (_currentUser != null)
            {
                return _wordMapper.MapToDTO(_repoWrapper.Word.FindByCondition(w => w.UserSavedWords.Any(uw => uw.UserId == _currentUser.Id)));
            }
            return null;
        }

        public bool TryAddToSavedWords(long id)
        {
            return TryAddToSavedWords(id, _currentUser);
        }

        public bool TryAddToSavedWords(long wordId, User user)
        {
            Word word = _repoWrapper.Word.FindByCondition(w => w.Id.Equals(wordId)).FirstOrDefault();
            if (user != null && word != null)
            {
                UserSavedWord newSavedWord = new UserSavedWord { SavedWord = word, SavedWordId = word.Id, User = user, UserId = user.Id };
                if (_repoWrapper.UserSavedWords.FindByCondition(sw => sw.Equals(newSavedWord)).FirstOrDefault() == null)
                {
                    _repoWrapper.User.Attach(user);
                    _repoWrapper.Word.Attach(word);
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
                DeleteSavedWord(id);
                return true;
            }
            return false;
        }

        public void DeleteSavedWord(long id)
        {
            UserSavedWord savedWord = _repoWrapper
                    .UserSavedWords.FindByCondition(sw => sw.UserId == _currentUser.Id && sw.SavedWordId.Equals(id))
                    .FirstOrDefault();
            _repoWrapper.UserSavedWords.Delete(savedWord);
            _repoWrapper.Save();
        }

        public IEnumerable<WordDTO> GetCreatedWords()
        {
            if (_currentUser != null)
            {
                var createdWords = _repoWrapper.Word.FindByCondition(w => w.AuthorId == _currentUser.Id);
                return _wordMapper.MapToDTO(createdWords);
            }
            return null;
        }

        public bool TryCreateWord(CreateWordFormDTO wordDto)
        {
            if (_currentUser != null)
            { 
                if (wordDto?.Name == null || wordDto.Definition == null) return false;
                CreateWord(wordDto);
                return true;
            }
            return false;
        }

        public void CreateWord(CreateWordFormDTO wordDto)
        {
            Word word = new Word { Definition = wordDto?.Definition, Image = wordDto.Image, Example = wordDto.Example, Name = wordDto.Name, AuthorId = _currentUser.Id };
            _repoWrapper.Word.Create(word);

            foreach (string tagName in wordDto.Tags.Distinct())
            {
                CreateTag(tagName, word);
            }

            _repoWrapper.Save();
        }

        public bool TryEditCreatedWord(CreateWordFormDTO wordDto)
        {
            if (_currentUser != null)
            { 
                if (wordDto?.Name == null || wordDto.Definition == null) return false;

                Word word = _repoWrapper.Word.FindByCondition(w => w.Id.Equals(wordDto.Id) && w.AuthorId == _currentUser.Id).FirstOrDefault();
                if (word != null)
                {
                    word.Image = wordDto.Image;
                    word.Name = wordDto.Name;
                    word.Definition = wordDto.Definition;
                    word.Example = wordDto.Example;
                    word.CreationDate = DateTime.Now;
                    word.WordStatus = WordStatus.OnModeration;

                    _repoWrapper.Word.Update(word);

                    Dictionary<string, Tag> oldTags = _repoWrapper.Tag.FindByCondition(t => t.WordTags.Any(w => w.WordId.Equals(word.Id)))
                        .ToDictionary(t => t.Name, t => t);

                    foreach (string tagName in wordDto.Tags.Distinct())
                    {
                        if (!oldTags.Keys.Contains(tagName))
                        {
                            CreateTag(tagName, word);
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

        private void CreateTag(string tagName, Word word)
        {
            Tag tag = _repoWrapper.Tag.FindByCondition(t => t.Name == tagName).FirstOrDefault();
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

        public bool TryDeleteCreatedWord(long id)
        {
            if (_currentUser != null)
            {
                DeleteCreatedWord(id);
                return true;
            } 
            return false;
        }

        public void DeleteCreatedWord(long id)
        {
             Word word = _repoWrapper.Word.FindByCondition(w => w.Id.Equals(id) && w.AuthorId == _currentUser.Id).FirstOrDefault();
              _repoWrapper.Word.Delete(word);
              _repoWrapper.Save();
        }
    }
}
