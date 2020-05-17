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
    public class TagServiceTests
    {
        private Mock<IRepositoryWrapper> _repoWrapper;
        private Mock<IMapper<Tag, TagDTO>> _mapper;

        public TagServiceTests()
        {
            _repoWrapper = new Mock<IRepositoryWrapper>();
            _mapper = new Mock<IMapper<Tag, TagDTO>>();
        }

        [Fact]
        public void TrueExpectedTryDelete_test()
        {
            _repoWrapper.Setup(w => w.Tag.FindByCondition(It.IsAny<Expression<Func<Tag, bool>>>())).Returns(new List<Tag> {
                new Tag
                {
                    Id=1,
                    Name="testing"
                }
            }.AsQueryable());

            TagService testService = new TagService(_repoWrapper.Object, _mapper.Object);


        }

    }
}
