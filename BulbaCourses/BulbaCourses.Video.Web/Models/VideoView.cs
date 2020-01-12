using BulbaCourses.Video.Web.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Models
{
    [Validator(typeof(VideoViewValidator))]
    public class VideoView
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int Duration { get; set; }
        public int Order { get; set; }
    }
}