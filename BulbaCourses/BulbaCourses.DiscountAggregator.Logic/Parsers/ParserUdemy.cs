using BulbaCourses.DiscountAggregator.Logic.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Parsers
{
    class ParserUdemy
    {
        public IEnumerable<CoursesUdemy> GetAllCourses()
        {
            var html = CommonValues.urlUdemy;
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            List<CoursesUdemy> listCourses = new List<CoursesUdemy>();
            var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='main-content']/script");
            if (htmlNodes is null) return listCourses;    // TODO
            foreach (var node in htmlNodes)
            {
                CoursesUdemy currentCourse = new CoursesUdemy()
                {
                    Title = node.InnerHtml
                };
                listCourses.Add(currentCourse);
            }
            return listCourses;
        }

        //private void SetFieldsCourse(CoursesITAcademy course)
        //{
        //    var web = new HtmlWeb();
        //    var doc = web.Load(course.URL);
        //    var htmlNodes = doc.DocumentNode.SelectNodes("//div[@class='course-item__price']");
        //    var htmlNodesDiscount = doc.DocumentNode.SelectNodes("//span[@class='discount']");
        //    var htmlNodesNewPrice = doc.DocumentNode.SelectNodes("//span[@class='price price_new']");
        //    var htmlNodesDescription = doc.DocumentNode.SelectNodes("//div[@class='main-section-top__txt']");

        //    if (htmlNodesDiscount is null)
        //    {
        //        course.CurrentPrice = Convert.ToDouble(htmlNodes.FirstOrDefault().InnerText.Trim().Substring(0, htmlNodes.FirstOrDefault().InnerText.Trim().Length - 3));
        //    }
        //    else
        //    {
        //        course.CurrentPrice = Convert.ToDouble(htmlNodesNewPrice.FirstOrDefault().InnerHtml.Trim().Substring(0, htmlNodesNewPrice.FirstOrDefault().InnerText.Trim().Length - 3).Replace('.', ','));// Convert.ToDouble(htmlNodesNewPrice.FirstOrDefault().InnerText.Trim().Substring(0, htmlNodesNewPrice.FirstOrDefault().InnerText.Trim().Length - 3));
        //        course.Discount = Convert.ToInt32(htmlNodesDiscount.FirstOrDefault().InnerHtml.Trim().Remove(htmlNodesDiscount.FirstOrDefault().InnerHtml.Length - 1, 1).Remove(0, 1));
        //    }
        //    course.Description = htmlNodesDescription.FirstOrDefault().ChildNodes[4].InnerText;
        //}
    }
}
