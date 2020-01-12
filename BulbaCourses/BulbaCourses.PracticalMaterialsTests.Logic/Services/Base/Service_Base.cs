using AutoMapper;
using BulbaCourses.PracticalMaterialsTests.Data.Context;
using System;
using System.Data.Entity;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.BaseService
{
    public class Service_Base : IDisposable
    {
        protected readonly DbContext _context;        

        private bool _isDisposed = false;

        protected Service_Base(DbContext context)
        {
            _context = context;            
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

        ~Service_Base()
        {
            this.Dispose(false);
        }
    }
}
