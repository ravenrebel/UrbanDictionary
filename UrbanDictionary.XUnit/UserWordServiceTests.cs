using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using UrbanDictionary.BusinessLayer.DTO;
using UrbanDictionary.BusinessLayer.DTO.Mapper;
using UrbanDictionary.BusinessLayer.Services;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;
using Xunit;

namespace UrbanDictionary.XUnit
{
    public class UserWordServiceTests
    {
        private Mock<IRepositoryWrapper> _repoWrapper;
        private Mock<IMapper<Word, WordDTO>> _mapper;
        private Mock<IHttpContextAccessor> _httpContextAccessor;
        


        public UserWordServiceTests()
        {
            _repoWrapper = new Mock<IRepositoryWrapper>();
            _mapper = new Mock<IMapper<Word, WordDTO>>();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();

        }

        [Fact]
        public void GetSavedWords_test()
        {
            _repoWrapper.Setup(w => w.User.FindByCondition(It.IsAny<Expression<Func<User, bool>>>())).Returns(new List<User> {
                new User
                {
                    Id="0b6f4943-8558-4da8-9783-37ac5d5259bb",
                    UserName="Lolka",
                    Email="lolka@gmail.com"
                },
                new User
                {
                    Id="abddd9eb-ac0e-46e8-b816-c061bf5962c2",
                    UserName="Danila",
                    Email="danila@gmail.com"
                }
            }.AsQueryable());

            _repoWrapper.Setup(w => w.Word.FindByCondition(It.IsAny<Expression<Func<Word, bool>>>())).Returns(new List<Word> {
                new Word
                {
                    Id=1,
                    Name="test",
                    WordStatus=WordStatus.Сonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    AuthorId="0b6f4943-8558-4da8-9783-37ac5d5259bb"
                }
            }.AsQueryable());

            _repoWrapper.Setup(w => w.UserSavedWords.FindByCondition(It.IsAny<Expression<Func<UserSavedWord, bool>>>())).Returns(new List<UserSavedWord> {
                new UserSavedWord
                {
                    SavedWordId=1,
                    UserId="0b6f4943-8558-4da8-9783-37ac5d5259bb"
                },

            }.AsQueryable()); ;

            User _currentUser = _repoWrapper.Object.User.FindByCondition(u => u.Id.Equals("0b6f4943-8558-4da8-9783-37ac5d5259bb")).FirstOrDefault();

            UserWordsService testService = new UserWordsService(_repoWrapper.Object, _httpContextAccessor.Object, _mapper.Object);

            var res = testService.GetSavedWords();

            Assert.NotNull(res);
        }

        [Fact]
        public void GetCreatedWords_test()
        {
            _repoWrapper.Setup(w => w.User.FindByCondition(It.IsAny<Expression<Func<User, bool>>>())).Returns(new List<User> {
                new User
                {
                    Id="0b6f4943-8558-4da8-9783-37ac5d5259bb",
                    UserName="Lolka",
                    Email="lolka@gmail.com"
                },
                new User
                {
                    Id="abddd9eb-ac0e-46e8-b816-c061bf5962c2",
                    UserName="Danila",
                    Email="danila@gmail.com"
                }
            }.AsQueryable());

            _repoWrapper.Setup(w => w.Word.FindByCondition(It.IsAny<Expression<Func<Word, bool>>>())).Returns(new List<Word> {
                new Word
                {
                    Id=1,
                    Name="test",
                    WordStatus=WordStatus.Сonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    AuthorId="0b6f4943-8558-4da8-9783-37ac5d5259bb"
                }
            }.AsQueryable());

            _repoWrapper.Setup(w => w.UserSavedWords.FindByCondition(It.IsAny<Expression<Func<UserSavedWord, bool>>>())).Returns(new List<UserSavedWord> {
                new UserSavedWord
                {
                    SavedWordId=1,
                    UserId="0b6f4943-8558-4da8-9783-37ac5d5259bb"
                },

            }.AsQueryable()); ;

            User _currentUser = _repoWrapper.Object.User.FindByCondition(u => u.Id.Equals("0b6f4943-8558-4da8-9783-37ac5d5259bb")).FirstOrDefault();

            UserWordsService testService = new UserWordsService(_repoWrapper.Object, _httpContextAccessor.Object, _mapper.Object);

            var res = testService.GetCreatedWords();

            Assert.NotNull(res);
        }

        [Fact]
        public void TryAddToSavedWords_test()
        {
            _repoWrapper.Setup(w => w.Word.FindByCondition(It.IsAny<Expression<Func<Word, bool>>>())).Returns(new List<Word> {
                new Word
                {
                    Id=1,
                    Name="test",
                    WordStatus=WordStatus.Сonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    AuthorId="0b6f4943-8558-4da8-9783-37ac5d5259bb"
                },
                new Word
                {
                    Id=2,
                    Name="test",
                    WordStatus=WordStatus.Сonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    AuthorId="abddd9eb-ac0e-46e8-b816-c061bf5962c2"
                }
            }.AsQueryable());

            _repoWrapper.Setup(w => w.User.FindByCondition(It.IsAny<Expression<Func<User, bool>>>())).Returns(new List<User> {
                new User
                {
                    Id="0b6f4943-8558-4da8-9783-37ac5d5259bb",
                    UserName="Lolka",
                    Email="lolka@gmail.com"
                },
                new User
                {
                    Id="abddd9eb-ac0e-46e8-b816-c061bf5962c2",
                    UserName="Danila",
                    Email="danila@gmail.com"
                }
            }.AsQueryable());

            User _currentUser = _repoWrapper.Object.User.FindByCondition(u => u.Id.Equals("0b6f4943-8558-4da8-9783-37ac5d5259bb")).FirstOrDefault();

            UserWordsService testService = new UserWordsService(_repoWrapper.Object, _httpContextAccessor.Object, _mapper.Object);

            //var res = testService.TryAddToSavedWords(_repoWrapper.Object.Word.FindByCondition(a=>a.Id==2).FirstOrDefault().Id, _currentUser);

            //Assert.True(res);
        }
    }
}
