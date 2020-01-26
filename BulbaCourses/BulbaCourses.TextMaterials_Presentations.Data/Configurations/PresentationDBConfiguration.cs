using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;


namespace BulbaCourses.TextMaterials_Presentations.Data
{
    public class PresentationDBConfiguration : EntityTypeConfiguration<PresentationDB>
    {
        public PresentationDBConfiguration()
        {
            ToTable("Presentations");

            HasKey(_ => _.Id);

            Property(_ => _.Title).IsRequired().HasMaxLength(255).IsUnicode();
            HasIndex(_ => _.Title).IsUnique(true);

            Property(_ => _.DateUpdate).IsRequired();

            Property(_ => _.IsAccessible).IsRequired();

            Property(_ => _.TeacherDBId).IsOptional();

            HasOptional<TeacherDB>(_ => _.TeacherDB).WithMany(_ => _.ChangedPresentatons);

            Property(_ => _.CourseDBId).IsOptional();

            HasOptional<CourseDB>(_ => _.CourseDB).WithMany(_ => _.CoursePresentations);

            HasMany<FeedbackDB>(_ => _.Feedbacks).WithOptional(_ => _.PresentationDB).HasForeignKey(_ => _.PresentationDBId);

            HasMany<StudentDB>(_ => _.Students).WithMany(_ => _.FavoritePresentations)
                                               .Map(_=>_.ToTable("Favorite"));

            HasMany<StudentDB>(_ => _.ViewedByStudents).WithMany(_ => _.ViewedPresentations)
                                                       .Map(_=>_.ToTable("Viewed"));
        }
    }
}
