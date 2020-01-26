using AutoMapper;
using System;
using System.Data.Entity;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.Base
{
    public class Service_Base : IDisposable
    {
        protected readonly DbContext _context;

        protected readonly IMapper _mapper;

        private bool _isDisposed = false;

        protected Service_Base(DbContext context, IMapper mapper)
        {
            _context = context;

            _mapper = mapper;
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
