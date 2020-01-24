using BulbaCourses.DiscountAggregator.Logic.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Parsers
{
    class ParserITAcademy
    {
        public IEnumerable<CoursesITAcademy> GetAllCourses(CourseCategory courseCategory)
        {
            var html = CommonValues.hostItAcademy + courseCategory.Name;
            if (courseCategory.Name.Contains("http"))
                html = courseCategory.Name;
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            List<CoursesITAcademy> listCourses = new List<CoursesITAcademy>();
            var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='programm-card-wrap ']/a");
            if (htmlNodes is null) return listCourses;    // TODO
            foreach (var node in htmlNodes)
            {
                CoursesITAcademy currentCourse = new CoursesITAcademy()
                {
                    Category = new CourseCategory()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = courseCategory.Name,
                        Title = courseCategory.Title
                    },
                    Domain = new Domain()
                    {
                        DomainURL = CommonValues.hostItAcademy,
                        DomainName = "It-Academy",
                        Id = Guid.NewGuid().ToString()
                    },   
                    URL = CommonValues.hostItAcademy + node.Attributes["href"].Value,
                    Title = node.ChildNodes["div"].ChildNodes["h3"].InnerHtml
                };
                if (!listCourses.Any(x => x.URL.Equals(currentCourse.URL)))
                {
                    SetFieldsCourse(currentCourse);
                    listCourses.Add(currentCourse);
                }
            }
            return listCourses;
        }

        private void SetFieldsCourse(CoursesITAcademy course)
        {
            var web = new HtmlWeb();
            var doc = web.Load(course.URL);
            var htmlNodes = doc.DocumentNode.SelectNodes("//div[@class='course-item__price']");
            var htmlNodesDiscount = doc.DocumentNode.SelectNodes("//span[@class='discount']");
            var htmlNodesNewPrice = doc.DocumentNode.SelectNodes("//span[@class='price price_new']");
            var htmlNodesDescription = doc.DocumentNode.SelectNodes("//div[@class='main-section-top__txt']");
            var htmlNodesDateStart = doc.DocumentNode.SelectNodes("//div[@class='course-item__date']");

            if (htmlNodesDiscount is null)
            {
                var _ = htmlNodes.FirstOrDefault().InnerText.Trim().Replace('.', ',');
                course.Price = Convert.ToDouble(Regex.Match(_, @"[\d.,]+").ToString());
            }
            else
            {
                var _ = htmlNodesNewPrice.FirstOrDefault().InnerHtml.Trim().Replace('.', ',');
                course.Price = Convert.ToDouble(Regex.Match(_, @"[\d.,]+").ToString());
                course.Discount = Convert.ToInt32(Regex
                    .Match(htmlNodesDiscount.FirstOrDefault().InnerHtml, @"[\d]+").ToString());
            }
            course.Description = htmlNodesDescription.FirstOrDefault().ChildNodes[4].InnerText;
            var dateStartCourse = htmlNodesDateStart.FirstOrDefault().InnerText.Trim();
            Match match = Regex.Match(dateStartCourse, @"\d\d[.]\d\d[.]\d\d\d\d");
            if (match.Success)
            {
                course.DateStartCourse = Convert.ToDateTime(match.Captures[0].Value);
            }
        }

        public List<CourseCategory> GetCategories()
        {
            var html = CommonValues.urlITAcademyCategories;
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            List<CourseCategory> listCategories = new List<CourseCategory>();
            var htmlNodes = htmlDoc.DocumentNode
                .SelectNodes("//ul[@class='panel-section-list panel-section-list_columns']/li");
            if (htmlNodes is null) return listCategories;
            foreach (var node in htmlNodes)
            {
                listCategories.Add(new CourseCategory()
                {
                    Id = null,
                    Title = node.ChildNodes["a"].ChildNodes["span"].InnerHtml,
                    Name = node.ChildNodes["a"].Attributes["href"].Value
                });
            }
            return listCategories;
        }
    }
}