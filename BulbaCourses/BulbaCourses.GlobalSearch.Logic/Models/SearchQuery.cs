using BulbaCourses.GlobalSearch.Logic.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.GlobalSearch.Logic.Models
{
    public class SearchQuery
    {
        public string Id { get; set; }
        public string Query { get; set; }
        public DateTime Date { get; set; }
    }
}