using BulbaCourses.TextMaterials_Presentations.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.TextMaterials_Presentations.Data
{
    public class StudentDbRepository : IRepository<StudentDB>, IStudentLoadingRepository
    {
        public StudentDbRepository(PresentationsContext context)
        {
            this._db = context;
        }

        private PresentationsContext _db;

        /// <summary>
        /// Add a StudentDB to the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Add(StudentDB item)
        {
            item.Created = DateTime.Now;
            _db.Students.Add(item);
        }

        /// <summary>
        /// Get FirstOrDefault StudentDB from the database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StudentDB> GetByIdAsync(string id)
        {
            var query = from student in _db.Students select student;
            return await query.AsNoTracking().FirstOrDefaultAsync(_ => _.Id.Equals(id));
        }

        /// <summary>
        /// Get all StudentDB fron the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<StudentDB>> GetAllAsync()
        {
            var query = from student in _db.Students select student;
            return await query.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Update student in the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Update(StudentDB item)
        {
            item.Modified = DateTime.Now;
            _db.Students.Attach(item);

            _db.Entry(item).Property(c => c.PhoneNumber).IsModified = true;

            _db.Entry(item).Property(c => c.Modified).IsModified = true;
        }

        /// <summary>
        /// Delete student from the database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeleteById(string id)
        {
            _db.Entry(new StudentDB() { Id = id }).State = EntityState.Deleted;
        }

        public async Task AddLovedPresentationAsync(string idStudent, string idPresentation)
        {
            var queryStudent = from student in _db.Students select student;
            var changedStudent = await queryStudent.AsNoTracking().FirstOrDefaultAsync(_ => _.Id.Equals(idStudent));

            var queryPresentation = from presentation in _db.Presentations select presentation;
            var addPresentation = await queryPresentation.AsNoTracking().FirstOrDefaultAsync(_ => _.Id.Equals(idPresentation));

            changedStudent.FavoritePresentations.Add(addPresentation);
        }

        public async Task DeleteLovedPresentationAsync(string idStudent, string idPresentation)
        {
            var queryStudent = from student in _db.Students select student;
            var changedStudent = await queryStudent.AsNoTracking().FirstOrDefaultAsync(_ => _.Id.Equals(idStudent));

            var queryPresentation = from presentation in _db.Presentations select presentation;
            var deletePresentation = await queryPresentation.AsNoTracking().FirstOrDefaultAsync(_ => _.Id.Equals(idPresentation));

            changedStudent.FavoritePresentations.Remove(deletePresentation);
        }

        public async Task<StudentDB> GetAllLovedPresentationAsync(string id)
        {
            var query = from student in _db.Students select student;
            return await query.AsNoTracking().Include(_=>_.FavoritePresentations).FirstOrDefaultAsync(_ => _.Id.Equals(id));
        }

        public async Task AddViewedPresentationAsync(string idStudent, string idPresentation)
        {
            var queryStudent = from student in _db.Students select student;
            var changedStudent = await queryStudent.AsNoTracking().FirstOrDefaultAsync(_ => _.Id.Equals(idStudent));

            var queryPresentation = from presentation in _db.Presentations select presentation;
            var addPresentation = await queryPresentation.AsNoTracking().FirstOrDefaultAsync(_ => _.Id.Equals(idPresentation));

            changedStudent.ViewedPresentations.Add(addPresentation);
        }

        public async Task DeleteViewedPresentationAsync(string idStudent, string idPresentation)
        {
            var queryStudent = from student in _db.Students select student;
            var changedStudent = await queryStudent.AsNoTracking().FirstOrDefaultAsync(_ => _.Id.Equals(idStudent));

            var queryPresentation = from presentation in _db.Presentations select presentation;
            var deletePresentation = await queryPresentation.AsNoTracking().FirstOrDefaultAsync(_ => _.Id.Equals(idPresentation));

            changedStudent.ViewedPresentations.Remove(deletePresentation);
        }

        public async Task<StudentDB> GetAllViewedPresentationAsync(string id)
        {
            var query = from student in _db.Students select student;
            return await query.AsNoTracking().Include(_ => _.ViewedPresentations).FirstOrDefaultAsync(_ => _.Id.Equals(id));
        }

        public async Task<StudentDB> GetAllFeedbacksFromStudentAsync(string id)
        {
            var query = from student in _db.Students select student;
            return await query.AsNoTracking().Include(_ => _.Feedbacks).FirstOrDefaultAsync(_ => _.Id.Equals(id));
        }

        public async Task UpdateIsPaidAsync(string id, bool hasPayment)
        {
            var query = from student in _db.Students select student;
            var changedStudent = await query.AsNoTracking().FirstOrDefaultAsync(_ => _.Id.Equals(id));

            changedStudent.IsPaid = hasPayment;

            _db.Students.Attach(changedStudent);

            _db.Entry(changedStudent).Property(c => c.IsPaid).IsModified = true;
        }
    }
}
