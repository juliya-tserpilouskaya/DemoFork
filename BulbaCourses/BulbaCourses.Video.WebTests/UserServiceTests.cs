using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using BulbaCourses.Video.Data.Models;
using BulbaCourses.Video.Logic.Models;
using Moq;
using AutoMapper;
using BulbaCourses.Video.Data.Interfaces;
using BulbaCourses.Video.Logic.Services;
using FluentAssertions;
using Bogus;
using System.Linq;
using System.Threading.Tasks;

namespace BulbaCourses.Video.WebTests
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
        private Faker<UserDb> _fakerUsers;

        [OneTimeSetUp]
        public void Init()
        {
            Faker<UserDb> fakerUsers = new Faker<UserDb>();
            fakerUsers.RuleFor(u => u.UserId, b => b.Random.String(8))
                .RuleFor(u => u.Name, b => b.Name.FirstName())
                .RuleFor(u => u.LastName, b => b.Name.LastName())
                .RuleFor(u => u.Login, b => b.Internet.UserName())
                .RuleFor(u => u.Password, b => b.Random.String(10))
                .RuleFor(u => u.Email, b => b.Internet.Email())
                .RuleFor(u => u.AvatarPath, b => b.Internet.Avatar())
                .RuleFor(u => u.SubscriptionType, b => b.Random.Int(0, 3));
        }

        [SetUp]
        public void InitMock()
        {
            _userDb = new UserDb() { UserId = "id", Login = "A", Name = "b", Email = "test@gmail.com", Password = "testPassword" };
            _userInfo = new UserInfo() { UserId = "id", Login = "A", Name = "b", Email = "test@gmail.com", Password = "testPassword" };

            _usersDbList = new List<UserDb>() { new UserDb() { UserId = "id", Login = "A", Name = "b" } };
            _usersInfoList = new List<UserInfo>() { new UserInfo() { UserId = "id", Login = "A", Name = "b" } };

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
            _mockUserRepository.Setup(c => c.AddAsync(_userDb)).Returns(async () => 1);

            UserService service = new UserService(_mockMapper.Object, _mockUserRepository.Object);
            var result = await service.AddAsync(_userInfo);
            result.Should().Be(1);
        }

        [Test]
        public async Task Test_Delete_User_Async()
        {
            _mockMapper.Setup(m => m.Map<UserInfo, UserDb>(_userInfo)).Returns(_userDb);
            _mockUserRepository.Setup(c => c.RemoveAsync(_userDb)).Returns(async () => 1);

            UserService service = new UserService(_mockMapper.Object, _mockUserRepository.Object);
            var res = await service.DeleteAsync(_userInfo);

            res.Should().Be(1);
        }

        [Test]
        public async Task Test_Update_User_Async()
        {
            _mockMapper.Setup(m => m.Map<UserInfo, UserDb>(_userInfo)).Returns(_userDb);
            _mockUserRepository.Setup(c => c.UpdateAsync(_userDb)).Returns(async () => 1);

            UserService service = new UserService(_mockMapper.Object, _mockUserRepository.Object);
            var res = await service.UpdateAsync(_userInfo);

            res.Should().Be(1);
        }

        [Test]
        public async Task Test_ExistLoginAsync()
        {
            _mockMapper.Setup(m => m.Map<UserDb, UserInfo>(_userDb)).Returns(_userInfo);
            _mockUserRepository.Setup(c => c.IsLoginExistAsync(_userDb.Login)).Returns(async () => true);
            UserService service = new UserService(_mockMapper.Object, _mockUserRepository.Object);
            var res = await service.ExistLoginAsync(_userInfo.Login);

            res.Should().Be(true);
        }

        [Test]
        public async Task Test_ExistLoginAsync_False()
        {
            _mockMapper.Setup(m => m.Map<UserDb, UserInfo>(_userDb)).Returns(_userInfo);
            _mockUserRepository.Setup(c => c.IsLoginExistAsync(_userDb.Login)).Returns(async () => false);
            UserService service = new UserService(_mockMapper.Object, _mockUserRepository.Object);
            var res = await service.ExistLoginAsync(_userInfo.Login);

            res.Should().Be(false);
        }

        [Test]
        public async Task Test_ExistEmailAsync()
        {
            _mockMapper.Setup(m => m.Map<UserDb, UserInfo>(_userDb)).Returns(_userInfo);
            _mockUserRepository.Setup(c => c.IsLoginExistAsync(_userDb.Email)).Returns(async () => true);
            UserService service = new UserService(_mockMapper.Object, _mockUserRepository.Object);
            var res = await service.ExistLoginAsync(_userInfo.Email);

            res.Should().Be(true);
        }

        [Test]
        public async Task Test_User_CheckEmail()
        {
            _mockMapper.Setup(m => m.Map<UserDb, UserInfo>(_userDb)).Returns(_userInfo);
            _mockUserRepository.Setup(c => c.IsLoginExistAsync(_userDb.Email)).Returns(async () => false);
            UserService service = new UserService(_mockMapper.Object, _mockUserRepository.Object);
            var res = await service.CheckEmailForLossingPass(_userInfo.Email);

            res.Should().Be(true);
        }

        [Test]
        public async Task Test_User_CheckPasswordAsync()
        {
            _mockMapper.Setup(m => m.Map<UserDb, UserInfo>(_userDb)).Returns(_userInfo);
            _mockUserRepository.Setup(c => c.GetByIdAsync(_userDb.UserId)).Returns(async () => _userDb);
            UserService service = new UserService(_mockMapper.Object, _mockUserRepository.Object);
            string newPass = "testPassword";
            var res = await service.CheckPasswordAsync(_userInfo.UserId, newPass);

            res.Should().Be(true);
        }

        [Test]
        public async Task Test_User_CheckPasswordAsync_False()
        {
            _mockMapper.Setup(m => m.Map<UserDb, UserInfo>(_userDb)).Returns(_userInfo);
            _mockUserRepository.Setup(c => c.GetByIdAsync(_userDb.UserId)).Returns(async () => _userDb);
            UserService service = new UserService(_mockMapper.Object, _mockUserRepository.Object);
            string newPass = "falsePassword";
            var res = await service.CheckPasswordAsync(_userInfo.UserId, newPass);

            res.Should().Be(false);
        }

    }
}
