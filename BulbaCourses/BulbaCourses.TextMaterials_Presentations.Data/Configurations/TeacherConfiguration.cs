using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.TextMaterials_Presentations.Data
{
    public class TeacherConfiguration : EntityTypeConfiguration<TeacherDB>
    {
        public TeacherConfiguration()
        {
            ToTable("Teachers");

            HasKey(x => x.Id);

            Property(x => x.PhoneNumber).IsRequired().HasMaxLength(25);

            Property(_ => _.Created).IsRequired();

            Property(_ => _.Modified).IsOptional();

            HasMany<PresentationDB>(_ => _.ChangedPresentatons);

            HasMany<FeedbackDB>(_ => _.Feedbacks);
        }
    }
}
