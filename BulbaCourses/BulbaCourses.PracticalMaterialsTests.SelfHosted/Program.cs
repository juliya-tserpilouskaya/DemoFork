using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.SelfHosted
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var server = WebApp.Start<OwinStartup>(new StartOptions() { Port = 5050 }))
            {
                Console.ReadLine();
            }
        }
    }
}
