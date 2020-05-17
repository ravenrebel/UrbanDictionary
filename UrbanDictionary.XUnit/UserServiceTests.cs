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
    public class UserServiceTests
    {
        private Mock<IRepositoryWrapper> _repoWrapper;
        private Mock<IMapper<User, UserDTO>> _mapper;

        public UserServiceTests()
        {
            _repoWrapper = new Mock<IRepositoryWrapper>();
            _mapper = new Mock<IMapper<User, UserDTO>>();
        }

        [Fact]
        public void GetAll_test()
        {
            _repoWrapper.Setup(w => w.User.FindByCondition(It.IsAny<Expression<Func<User, bool>>>())).Returns(new List<User> {
                new User
                {
                    UserName="Lolka",
                    Email="lolka@gmail.com"
                },
                new User
                {
                    UserName="Danila",
                    Email="danila@gmail.com"
                }
            }.AsQueryable());

            UserService testService = new UserService(_repoWrapper.Object, _mapper.Object);

            var res = testService.GetAll();

            Assert.NotNull(res);
        }

        [Fact]
        public void GetByUserName_test()
        {
            _repoWrapper.Setup(w => w.User.FindByCondition(It.IsAny<Expression<Func<User, bool>>>())).Returns(new List<User> {
                new User
                {
                    UserName="Lolka",
                    Email="lolka@gmail.com"
                },
                new User
                {
                    UserName="Danila",
                    Email="danila@gmail.com"
                }
            }.AsQueryable());

            UserService testService = new UserService(_repoWrapper.Object, _mapper.Object);

            var res = testService.GetByUserName("Lolka");

            Assert.NotNull(res);
        }

        [Fact]
        public void TrueExpectedTryDelete_test()
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

            UserService testService = new UserService(_repoWrapper.Object, _mapper.Object);

            var res = testService.TryDelete("abddd9eb-ac0e-46e8-b816-c061bf5962c2");

            Assert.True(res);

        }

        [Fact]
        public void FalseExpectedTryDelete_test()
        {
            _repoWrapper.Setup(w => w.User.FindByCondition(It.IsAny<Expression<Func<User, bool>>>())).Returns(new List<User> {
                new User
                {
                    UserName="Lolka",
                    Email="lolka@gmail.com"
                },
                new User
                {
                    UserName="Danila",
                    Email="danila@gmail.com"
                }
            }.AsQueryable());

            UserService testService = new UserService(_repoWrapper.Object, _mapper.Object);

            bool res = testService.TryDelete("");

            Assert.False(res);

        }
    }
}
