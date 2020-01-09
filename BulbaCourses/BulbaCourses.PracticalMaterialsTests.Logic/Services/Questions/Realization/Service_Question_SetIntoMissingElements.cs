using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Questions.Interfaсe;
using System;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.Questions.Realization
{
    public class Service_Question_SetIntoMissingElements : IService_Question
    {
        protected readonly DbContext_Test _context;

        private bool _isDisposed = false;

        protected Service_Question_SetIntoMissingElements(DbContext_Test context)
        {
            _context = context;
        }

        public void AddQuestion()
        {
            throw new NotImplementedException();
        }

        public void DropQuestionById(int Id)
        {
            throw new NotImplementedException();
        }

        public void GetQuestonById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected void Dispose(bool flag)
        {
            if (_isDisposed) return;

            _context?.Dispose();

            _isDisposed = true;

            if (flag)
                GC.SuppressFinalize(this);
        }

        ~Service_Question_SetIntoMissingElements()
        {
            this.Dispose(false);
        }
    }
}
