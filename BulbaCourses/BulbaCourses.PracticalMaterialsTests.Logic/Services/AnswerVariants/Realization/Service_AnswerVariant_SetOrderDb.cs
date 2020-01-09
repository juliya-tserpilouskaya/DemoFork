using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.AnswerVariants.Interfaсe;
using System;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.AnswerVariants.Realization
{
    public class Service_AnswerVariant_SetOrderDb : IService_AnswerVariant
    {
        protected readonly DbContext_Test _context;

        private bool _isDisposed = false;

        protected Service_AnswerVariant_SetOrderDb(DbContext_Test context)
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

        ~Service_AnswerVariant_SetOrderDb()
        {
            this.Dispose(false);
        }
    }
}
