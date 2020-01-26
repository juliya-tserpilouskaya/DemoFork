using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BulbaCourses.TextMaterials_Presentations.Data
{
    class PresentationsContextInitializer : CreateDatabaseIfNotExists<PresentationsContext>
    {
        protected override void Seed(PresentationsContext context)
        {
            Faker<CourseDB> _fakeCourse = new Faker<CourseDB>().RuleFor(x => x.Name, y => y.Name.JobTitle())
                                                               .RuleFor(x => x.Update, DateTime.Now);

            Faker<FeedbackDB> _fakeFeedback = new Faker<FeedbackDB>().RuleFor(x => x.Text, y => y.Name.JobTitle())
                                                                     .RuleFor(x => x.Date, DateTime.Now);

            Faker<PresentationDB> _fakePresentation = new Faker<PresentationDB>().RuleFor(x => x.Title, y => y.Name.JobTitle())
                                                                                 .RuleFor(x => x.DateUpdate, DateTime.Now)
                                                                                 .RuleFor(x => x.IsAccessible, y => y.Random.Bool());

            Faker<StudentDB> _fakeStudent = new Faker<StudentDB>().RuleFor(x => x.PhoneNumber, y => y.Phone.PhoneNumber())
                                                                  .RuleFor(x => x.IsPaid, y => y.Random.Bool())
                                                                  .RuleFor(x => x.Created, DateTime.Now);

            Faker<TeacherDB> _fakeTeacher = new Faker<TeacherDB>().RuleFor(x => x.PhoneNumber, y => y.Phone.PhoneNumber())
                                                                  .RuleFor(x => x.Created, DateTime.Now)
                                                                  .RuleFor(x=>x.Position,y=>y.Company.CompanyName());

            List<CourseDB> _fakeCourseDB = _fakeCourse.Generate(3);
            context.Courses.AddRange(_fakeCourseDB);

            List<FeedbackDB> _fakeFeedbacks = _fakeFeedback.Generate(3);
            context.Feedbacks.AddRange(_fakeFeedbacks);

            List<PresentationDB> _fakePresentations = _fakePresentation.Generate(3);
            context.Presentations.AddRange(_fakePresentations);

            List<StudentDB> _fakeStudents = _fakeStudent.Generate(3);
            context.Students.AddRange(_fakeStudents);

            List<TeacherDB> _fakeTeachers = _fakeTeacher.Generate(3);
            context.Teachers.AddRange(_fakeTeachers);

            context.Database.ExecuteSqlCommand(
                "ALTER TABLE dbo.Feedbacks " +
                "ADD CONSTRAINT Feedbacks_Teachers " +
                "FOREIGN KEY (TeacherDBId) " +
                "REFERENCES dbo.Teachers (Id) " +
                "ON DELETE SET NULL");
            context.Database.ExecuteSqlCommand(
                "ALTER TABLE dbo.Presentations " +
                "ADD CONSTRAINT Presentations_Teachers " +
                "FOREIGN KEY (TeacherDBId) " +
                "REFERENCES dbo.Teachers (Id) " +
                "ON DELETE SET NULL");
            context.Database.ExecuteSqlCommand(
                "ALTER TABLE dbo.Presentations " +
                "ADD CONSTRAINT Presentations_Courses " +
                "FOREIGN KEY (CourseDBId) " +
                "REFERENCES dbo.Courses (Id) " +
                "ON DELETE SET NULL");
            context.Database.ExecuteSqlCommand(
                "ALTER TABLE dbo.Feedbacks " +
                "ADD CONSTRAINT Feedbacks_Students " +
                "FOREIGN KEY (StudentDBId) " +
                "REFERENCES dbo.Students (Id) " +
                "ON DELETE SET NULL");
            context.Database.ExecuteSqlCommand(
                "ALTER TABLE dbo.Feedbacks " +
                "ADD CONSTRAINT Feedbacks_Presentations " +
                "FOREIGN KEY (PresentationDBId) " +
                "REFERENCES dbo.Presentations (Id) " +
                "ON DELETE SET NULL");

            context.SaveChanges();
        }
    }

    class FakeContextInitializer : DropCreateDatabaseAlways<PresentationsContext>
    {
        protected override void Seed(PresentationsContext context)
        {
            base.Seed(context);
        }
    }
}
