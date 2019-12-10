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
        public IEnumerable<CoursesITAcademy> GetAllCourses()
        {
            var html = @"https://www.it-academy.by/specialization/programmirovanie/";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);

            List<CoursesITAcademy> listCourses = new List<CoursesITAcademy>();

            var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='programm-card-wrap ']/a");

            if (htmlNodes is null) return listCourses;    // TODO

            foreach (var node in htmlNodes)
            {
                CoursesITAcademy currentCourse = new CoursesITAcademy()
                {
                    URL = @"https://www.it-academy.by" + node.Attributes["href"].Value,
                    Title = node.ChildNodes["div"].ChildNodes["h3"].InnerHtml,
                    Description = "Обучающие курсы",
                    Price = GetPriceCourseITAcademy(@"https://www.it-academy.by" + node.Attributes["href"].Value.ToString())
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


            //worked   TODO--
            //var url = "https://www.it-academy.by/course/asp-net-developer/osnovy-computer-science/";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var htmlNodes = doc.DocumentNode.SelectNodes("//div[@class='course-item__price']");

            //Console.WriteLine(htmlNodes[0].InnerText.Trim());
            //Console.WriteLine(htmlNodes[0].InnerHtml);
            try
            {
                return Convert.ToDouble(htmlNodes[0].InnerText.Trim().Substring(0, htmlNodes[0].InnerText.Trim().Length - 3));
            }
            catch
            {
                return 0;
            }
        }


    }
}