using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.TextMaterials_Presentations.Data
{
    public class FeedbackDBConfiguration : EntityTypeConfiguration<FeedbackDB>
    {
        public FeedbackDBConfiguration()
        {
            ToTable("Feedbacks");

            HasKey(_ => _.Id);

            Property(_ => _.Title).IsOptional();

            Property(_ => _.Text).IsRequired().HasMaxLength(255).IsUnicode();

            Property(_ => _.Date).IsRequired();

            Property(_ => _.StudentDBId).IsOptional();

            HasOptional<StudentDB>(_ => _.StudentDB).WithMany(_=>_.Feedbacks);

            Property(_ => _.TeacherDBId).IsOptional();

            HasOptional<TeacherDB>(_ => _.TeacherDB).WithMany(_ => _.Feedbacks);

            Property(_ => _.PresentationDBId).IsOptional();

            HasOptional<PresentationDB>(_ => _.PresentationDB).WithMany(_=>_.Feedbacks);
        }
    }
}
