using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyNetQ;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host = localhost"))
            {
                //bus.Advanced.Consume(bus.Advanced.QueueDeclare("CourseService"), OnMessageCourse);
            }

            Console.Read();
        }

        private static void OnMessageCourse(byte[] data, MessageProperties props, MessageReceivedInfo info)
        {
            var item = Encoding.UTF8.GetString(data);
            var result = JsonConvert.DeserializeObject<CourseInfo>(item);
            Console.WriteLine(result);
        }


    }
}
