using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Youtube.SelfHosted
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var server = WebApp.Start<Startup>(new StartOptions() { Port = 9000}))
            {
                Console.WriteLine("Application deployed and hosted in localhost:9000");
                Console.ReadKey();
            }
        }
    }
}
