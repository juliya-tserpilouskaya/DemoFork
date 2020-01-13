using BulbaCourses.GlobalSearch.Logic.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Validators
{
    public class BookmarkValidator : AbstractValidator<BookmarkDTO>
    {
        public BookmarkValidator()
        {
            RuleFor(b => b.URL).NotEmpty().WithMessage("Bookmark must have a url");
            RuleFor(b => b.UserId).NotEmpty().WithMessage("Bookmark must have a user id");
        }
    }
}
