using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Tests.Interfaсe;
using System;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.Tests.Realization
{
    public class Service_Test : IService_Test
    {
        protected readonly DbContext_Test _context;

        private bool _isDisposed = false;

        protected Service_Test(DbContext_Test context)
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

        ~Service_Test()
        {
            this.Dispose(false);
        }
    }
}
