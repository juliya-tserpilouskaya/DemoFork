using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using FluentAssertions;
using Bogus;
using BulbaCourses.Youtube.Web.DataAccess;
using BulbaCourses.Youtube.Web.DataAccess.Repositories;
using BulbaCourses.Youtube.Web.DataAccess.Models;

namespace BulbaCourses.Youtube.Web.Tests
{
    [TestFixture]
    class YoutubeContextTest
    {
        [Test]
        public void Test_RequestAdd()
        {
            using (var context = new YoutubeContext())
            {

                SearchRequestDb searchRequestDb = new SearchRequestDb()
                {
                    Title = "Фигурное катание",
                };
                context.SearchRequests.Add(searchRequestDb);
                context.SaveChanges();


                var searchR = context.SearchRequests;
            }
        }
    }
}
