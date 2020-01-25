using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.TextMaterials_Presentations.Data
{
    public class StudentConfiguration : EntityTypeConfiguration<StudentDB>
    {
        public StudentConfiguration()
        {
            ToTable("Students");

            HasKey(x => x.Id);

            Property(x => x.PhoneNumber).IsRequired();

            Property(_ => _.Created).IsRequired();

            Property(_ => _.Modified).IsOptional();

            HasMany<PresentationDB>(x => x.ViewedPresentations).WithMany(_=>_.ViewedByStudents);

            HasMany<PresentationDB>(x => x.FavoritePresentations).WithMany(_=>_.Students);

            HasMany<FeedbackDB>(_ => _.Feedbacks).WithOptional(_=>_.StudentDB).HasForeignKey(_=>_.StudentDBId);

            Property(x => x.IsPaid).IsRequired();
        }
    }
}
