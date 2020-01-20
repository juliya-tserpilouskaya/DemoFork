using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class CourseInfo
    {
        [JsonProperty("Id")]
        public string ItemId { get; set; }

        [JsonProperty("Name")]
        public string ItemTitle { get; set; }
    }
}
