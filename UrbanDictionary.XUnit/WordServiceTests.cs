using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UrbanDictionary.BusinessLayer.DTO;
using UrbanDictionary.BusinessLayer.DTO.Mapper;
using UrbanDictionary.BusinessLayer.Services;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;
using Xunit;

namespace UrbanDictionary.XUnit
{
    public class WordServiceTests
    {
        private Mock<IRepositoryWrapper> _repoWrapper;
        private Mock<IMapper<Word, WordDTO>> _mapper;


        public WordServiceTests()
        {
            _repoWrapper = new Mock<IRepositoryWrapper>();
            _mapper = new Mock<IMapper<Word, WordDTO>>();
        }

        [Fact]
        public void GetAll_test()
        {
            _repoWrapper.Setup(w => w.Word.FindByCondition(It.IsAny<Expression<Func<Word, bool>>>())).Returns(new List<Word> {
                new Word
                {
                    Id=1,
                    Name="test",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                }
            }.AsQueryable());

            WordService testService = new WordService(_repoWrapper.Object, _mapper.Object);

            var res = testService.GetAll();

            Assert.NotNull(res);
        }
        [Fact]
        public void GetRandom_test()
        {
            _repoWrapper.Setup(w => w.Word.FindByCondition(It.IsAny<Expression<Func<Word, bool>>>())).Returns(new List<Word> {
                new Word
                {
                    Id=1,
                    Name="test",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                }
            }.AsQueryable());

            WordService testService = new WordService(_repoWrapper.Object, _mapper.Object);

            var res = testService.GetRandom();

            Assert.NotNull(res);
        }

        [Fact]
        public void GetByName_test()
        {
            _repoWrapper.Setup(w => w.Word.FindByCondition(It.IsAny<Expression<Func<Word, bool>>>())).Returns(new List<Word> {
                new Word
                {
                    Id=1,
                    Name="test",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                }
            }.AsQueryable());

            WordService testService = new WordService(_repoWrapper.Object, _mapper.Object);

            var res = testService.GetByName("test",0);

            Assert.NotNull(res);
        }

        [Fact]
        public void TrueExpectedTryDelete_test()
        {
            _repoWrapper.Setup(w => w.Word.FindByCondition(It.IsAny<Expression<Func<Word, bool>>>())).Returns(new List<Word> {
                new Word
                {
                    Id=1,
                    Name="test",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                }
            }.AsQueryable());

            WordService testService = new WordService(_repoWrapper.Object, _mapper.Object);

            var res = testService.TryDelete(1);

            Assert.True(res);

        }

        [Fact]
        public void FalseExpectedTryDelete_test()
        {
            _repoWrapper.Setup(w => w.Word.FindByCondition(It.IsAny<Expression<Func<Word, bool>>>())).Returns(new List<Word> {
                new Word
                {
                    Id=1,
                    Name="test",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                }
            }.AsQueryable());

            WordService testService = new WordService(_repoWrapper.Object, _mapper.Object);

            var res = testService.TryDelete(0);

            Assert.False(res);

        }

        [Fact]
        public void GetTopTen_test()
        {
            _repoWrapper.Setup(w => w.Word.FindByCondition(It.IsAny<Expression<Func<Word, bool>>>())).Returns(new List<Word> {
                new Word
                {
                    Id=1,
                    Name="test",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=2,
                    Name="test1",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=3,
                    Name="test",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=4,
                    Name="test",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=5,
                    Name="test",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=6,
                    Name="lol",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=7,
                    Name="test123",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=8,
                    Name="test",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=9,
                    Name="test142",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=10,
                    Name="test123",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=11,
                    Name="karma",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=2,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=1,
                    Name="lol",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=0,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                }
            }.AsQueryable());

            WordService testService = new WordService(_repoWrapper.Object, _mapper.Object);

            var res = testService.GetTopTen();

            Assert.NotNull(res);
        }

        [Fact]
        public void GetTLastTenAdded_test()
        {
            _repoWrapper.Setup(w => w.Word.FindByCondition(It.IsAny<Expression<Func<Word, bool>>>())).Returns(new List<Word> {
                new Word
                {
                    Id=1,
                    Name="test",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=2,
                    Name="test1",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=3,
                    Name="test",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=4,
                    Name="test",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=5,
                    Name="test",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=6,
                    Name="lol",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=7,
                    Name="test123",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=8,
                    Name="test",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,15),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=9,
                    Name="test142",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=10,
                    Name="test123",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=11,
                    Name="karma",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=2,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=1,
                    Name="lol",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=0,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                }
            }.AsQueryable());

            WordService testService = new WordService(_repoWrapper.Object, _mapper.Object);

            var res = testService.GetLastTenAdded();

            Assert.NotNull(res);
        }

        [Fact]
        public void GetByTagName_test()
        {
            _repoWrapper.Setup(w => w.Word.FindByCondition(It.IsAny<Expression<Func<Word, bool>>>())).Returns(new List<Word> {
                new Word
                {
                    Id=1,
                    Name="test",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=2,
                    Name="test1",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    WordTags = new List<WordTag>
                    {
                        new WordTag
                        {
                            Tag = new Tag
                            {
                                Name="testing"
                            }
                        }
                    },
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=3,
                    Name="test",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=4,
                    Name="test",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=5,
                    Name="test",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    WordTags = new List<WordTag>
                    {
                        new WordTag
                        {
                            Tag = new Tag
                            {
                                Name="testing"
                            }
                        }
                    },
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=6,
                    Name="lol",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=7,
                    Name="test123",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    WordTags = new List<WordTag>
                    {
                        new WordTag
                        {
                            Tag = new Tag
                            {
                                Name="testing"
                            }
                        }
                    },
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=8,
                    Name="test",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=9,
                    Name="test142",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=10,
                    Name="test123",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=1,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    WordTags = new List<WordTag>
                    {
                        new WordTag
                        {
                            Tag = new Tag
                            {
                                Name="testing"
                            }
                        }
                    },
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=11,
                    Name="karma",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=2,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                },
                new Word
                {
                    Id=1,
                    Name="lol",
                    WordStatus=WordStatus.Ñonfirmed,
                    Definition="",
                    Example = "",
                    LikesCount=0,
                    DislikesCount = 0,
                    CreationDate = new DateTime(2020,01,02),
                    Author=new User
                    {
                        UserName="Lolka"
                    }
                }
            }.AsQueryable());
            WordService testService = new WordService(_repoWrapper.Object, _mapper.Object);

            var res = testService.GetByTagName("testing");

            Assert.NotNull(res);

        }

    }
}
