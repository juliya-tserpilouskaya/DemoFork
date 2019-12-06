using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using BulbaCourses.DiscountAggregator.Logic.Models;

namespace DiscountAggregator.Logic.Services
{
    public class CourseServices : ICourseServices
    {
        //getById, GetAll... methods
        public Course GetById(string id)
        {
            //тут должно быть какое-либо преобразование, иначе не имеет смысла
            return Courseware.GetById(id);
        }
        public IEnumerable<Course> GetAll()
        {
            return Courseware.GetAll();
        }

        public IEnumerable<string> GetVV()
        {
            var html = @"https://www.it-academy.by/specialization/programmirovanie/";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);

            var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='programm-card-wrap ']/a");

            List<string> res = null;
            foreach (var node in htmlNodes)
            {
                //Console.WriteLine(node.InnerHtml + "  -  " + node.Attributes["href"].Value);
                //Console.WriteLine(node.Attributes["href"].Value);
                res.Add(node.Attributes["href"].Value);
            }
            return res;
        }
    }
}
