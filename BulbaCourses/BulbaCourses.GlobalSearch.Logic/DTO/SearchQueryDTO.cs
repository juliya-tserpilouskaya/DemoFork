using BulbaCourses.GlobalSearch.Logic.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.DTO
{
    public class SearchQueryDTO
    {
        public string Id { get; set; }
        public string Query { get; set; }
        public DateTime? Date { get; set; }
        public string UserId { get; set; }
    }
}
