using BulbaCourses.DiscountAggregator.Logic.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Parsers
{
    class ParserITAcademy
    {
        public IEnumerable<CoursesITAcademy> GetAllCourseITAcademy()
        {
            var html = @"https://www.it-academy.by/specialization/programmirovanie/";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);

            List<CoursesITAcademy> listCourses = new List<CoursesITAcademy>();

            var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='programm-card-wrap ']/a");

            foreach (var node in htmlNodes)
            {
                CoursesITAcademy currentCourse = new CoursesITAcademy() {
                    URL = @"https://www.it-academy.by" + node.Attributes["href"].Value,
                    Title = node.ChildNodes["div"].ChildNodes["h3"].InnerHtml,
                    Price = GetPriceCourseITAcademy(node.Attributes["href"].Value.ToString())
                };
                listCourses.Add(currentCourse);
            }

            return listCourses;

        }

        public double GetPriceCourseITAcademy(string url)
        {
            //HtmlWeb web = new HtmlWeb();
            //var htmlDoc = web.Load(url);

            //List<CoursesITAcademy> listCourses = new List<CoursesITAcademy>();

            //var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='programm-card-wrap ']/a");

            //foreach (var node in htmlNodes)
            //{
            //    CoursesITAcademy currentCourse = new CoursesITAcademy()
            //    {
            //        URL = @"https://www.it-academy.by" + node.Attributes["href"].Value,
            //        Title = node.ChildNodes["div"].ChildNodes["h3"].InnerHtml
            //    };
            //    listCourses.Add(currentCourse);
            //}

            return 0;
        }


    }
}
