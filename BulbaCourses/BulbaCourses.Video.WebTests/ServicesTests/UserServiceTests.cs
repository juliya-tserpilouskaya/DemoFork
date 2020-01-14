using AutoMapper;
using Bogus;
using BulbaCourses.Video.Data.Interfaces;
using BulbaCourses.Video.Data.Models;
using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Logic.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.WebTests.ServicesTests
{
    [TestFixture]
    public class UserServiceTests
    {
        private UserDb _userDb;
        private UserInfo _userInfo;
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<IMapper> _mockMapper;
        private List<UserDb> _usersDbList;
        private List<UserInfo> _usersInfoList;
        //private Faker<UserDb> _fakerUsers;

        [OneTimeSetUp]
        public void Init()
        {
            Faker<UserDb> fakerUsers = new Faker<UserDb>();
            fakerUsers.RuleFor(u => u.UserId, b => b.Random.String(8))
                .RuleFor(u => u.Login, b => b.Internet.UserName())
                .RuleFor(u => u.SubscriptionType, b => b.Random.Int(0, 3));
        }

        [SetUp]
        public void InitMock()
        {
            _userDb = new UserDb() { UserId = "id", Login = "A" };
            _userInfo = new UserInfo() { Login = "A" };

            _usersDbList = new List<UserDb>() { new UserDb() { UserId = "id", Login = "A" } };
            _usersInfoList = new List<UserInfo>() { new UserInfo() { Login = "A" } };

            _mockUserRepository = new Mock<IUserRepository>();
            _mockMapper = new Mock<IMapper>();
        }

        [Test]
        public void Test_GetById_User()
        {
            _mockMapper.Setup(m => m.Map<UserDb, UserInfo>(_userDb)).Returns(_userInfo);
            _mockUserRepository.Setup(c => c.GetById(_userDb.UserId)).Returns(_userDb);

            UserService service = new UserService(_mockMapper.Object, _mockUserRepository.Object);
            var res = service.GetUserById(_userDb.UserId);

            res.Should().BeEquivalentTo(_userInfo);

            //_mockUserRepository.Verify(v => v.GetById(_userDb.UserId), Times.Once);
            //_mockMapper.Verify(v => v.Map<UserDb, UserInfo>(_userDb), Times.Once);
        }

        [Test]
        public async Task Test_GetById_User_Async()
        {
            _mockMapper.Setup(m => m.Map<UserDb, UserInfo>(_userDb)).Returns(_userInfo);
            _mockUserRepository.Setup(c => c.GetByIdAsync(_userDb.UserId)).Returns(async () => _userDb);

            UserService service = new UserService(_mockMapper.Object, _mockUserRepository.Object);
            var res = await service.GetUserByIdAsync(_userDb.UserId);

            res.Should().BeEquivalentTo(_userInfo);

        }

        [Test]
        public void Test_GetAll_Users()
        {
            _mockUserRepository.Setup(m => m.GetAll()).Returns(_usersDbList);
            _mockMapper.Setup(c => c.Map<IEnumerable<UserDb>, IEnumerable<UserInfo>>(_usersDbList)).Returns(_usersInfoList);
            UserService service = new UserService(_mockMapper.Object, _mockUserRepository.Object);
            var result = service.GetAll();
            result.Should().BeEquivalentTo(_usersInfoList);
        }

        [Test]
        public async Task Test_GetAll_Users_Async()
        {
            _mockUserRepository.Setup(m => m.GetAllAsync()).Returns(async () => _usersDbList);
            _mockMapper.Setup(c => c.Map<IEnumerable<UserDb>, IEnumerable<UserInfo>>(_usersDbList)).Returns(_usersInfoList);
            UserService service = new UserService(_mockMapper.Object, _mockUserRepository.Object);
            var result = await service.GetAllAsync();
            result.Should().BeEquivalentTo(_usersInfoList);
        }

        [Test]
        public async Task Test_Add_User_Async()
        {
            _mockMapper.Setup(m => m.Map<UserInfo, UserDb>(_userInfo)).Returns(_userDb);
            _mockMapper.Setup(m => m.Map<UserDb, UserInfo>(_userDb)).Returns(_userInfo);
            _mockUserRepository.Setup(c => c.AddAsync(_userDb)).Returns(async () => _userDb);
            UserService service = new UserService(_mockMapper.Object, _mockUserRepository.Object);
            var result = await service.AddAsync(_userInfo);
            result.IsSuccess.Should().BeTrue();
        }

        [Test]
        public async Task Test_Delete_User_Async()
        {
            _mockMapper.Setup(m => m.Map<UserInfo, UserDb>(_userInfo)).Returns(_userDb);
            _mockUserRepository.Setup(c => c.RemoveAsync(_userDb));

            UserService service = new UserService(_mockMapper.Object, _mockUserRepository.Object);
            var res = await service.DeleteAsync(_userInfo);

            res.IsSuccess.Should().BeTrue();
        }

        [Test]
        public async Task Test_Update_User_Async()
        {
            _mockMapper.Setup(m => m.Map<UserInfo, UserDb>(_userInfo)).Returns(_userDb);
            _mockUserRepository.Setup(c => c.UpdateAsync(_userDb)).Returns(async () => _userDb);

            UserService service = new UserService(_mockMapper.Object, _mockUserRepository.Object);
            var res = await service.UpdateAsync(_userInfo);

            res.IsSuccess.Should().BeTrue();
        }
    }
}
