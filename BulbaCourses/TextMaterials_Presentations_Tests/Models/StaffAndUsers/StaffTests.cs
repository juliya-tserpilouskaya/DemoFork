﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Bogus;

namespace BulbaCourses.TextMaterials_Presentations.Tests
{
    [TestFixture]
    public class StaffTests
    {
        Faker<Employee> _faker = new Faker<Employee>().RuleFor(x => x.Id, y => y.Random.Byte(0, 250).ToString())
                                                        .RuleFor(x => x.FullName, y => y.Name.FullName())
                                                        .RuleFor(x => x.UserName, y => y.Name.FirstName())
                                                        .RuleFor(x => x.Email, y => y.Internet.Email());
        List<Employee> _fakeEmployees;

        [OneTimeSetUp]
        public void ListGenerator()
        {
            _fakeEmployees = _faker.Generate(5);

            foreach (var item in _fakeEmployees)
            {
                Staff.Add(item);
            }
        }

        [Test]
        public void Add_Test()
        {
            List<Employee> employees = _faker.Generate(5);

            foreach (var item in employees)
            {
                Staff.Add(item).Should().BeEquivalentTo(item);
            }
        }

        [Test]
        public void GetAll_Test()
        {
            Staff.GetAll().Should().BeEquivalentTo(_fakeEmployees);
        }

        [Test]
        public void GetById_Test()
        {
            Staff.GetById(_fakeEmployees.First<Employee>().Id).Should().BeEquivalentTo(_fakeEmployees.First<Employee>());
        }

        [Test]
        public void Update_Test()
        {
            Employee employeeForUpdate = new Employee()
            {
                Id = _fakeEmployees.First<Employee>().Id,
                FullName = "1",
                UserName = "1",
                Email = "1"
            };

            Employee employeeBeforeUpdate = Staff.GetById(_fakeEmployees.First<Employee>().Id);
            Employee employeeAfterUpdate = Staff.Update(employeeForUpdate);

            employeeAfterUpdate.UserName.Should().BeEquivalentTo(employeeForUpdate.UserName);
        }

        [Test]
        public void DeleteById_Test()
        {
            Staff.DeleteById(_fakeEmployees.First<Employee>().Id).Should().BeTrue();
            Staff.GetById(_fakeEmployees.First<Employee>().Id).Should().BeNull();
        }
    }
}