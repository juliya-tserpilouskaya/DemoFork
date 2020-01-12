using AutoMapper;
using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Questions;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Tests;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Tests;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.BaseService;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Tests.Interface;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.Tests.Realization
{    
    public class Service_Test : Service_Base, IService_Test
    {
        protected readonly IMapper _mapper;

        public Service_Test(DbContext context, IMapper mapper) : base (context)
        {
            _mapper = mapper;
        }
        
        public MTest_MainInfo GetById(int Id)
        {
            MTest_MainInfoDb Test_MainInfoDb =
                _context.Set<MTest_MainInfoDb>()
                    .Include(_ => _.Questions_ChoosingAnswerFromList)
                    .Include(_ => _.Questions_ChoosingAnswerFromList.Select(c => c.AnswerVariants))
                    .FirstOrDefault(_ => _.Id == Id);                   

            return
                _mapper.Map<MTest_MainInfo>(Test_MainInfoDb);
        }
        
        public async Task<MTest_MainInfo> GetByIdAsync(int Id)
        {
            MTest_MainInfoDb Test_MainInfoDb =
                await _context.Set<MTest_MainInfoDb>()
                    .Include(_ => _.Questions_ChoosingAnswerFromList)
                    .Include(_ => _.Questions_ChoosingAnswerFromList.Select(c => c.AnswerVariants))
                    .FirstOrDefaultAsync(_ => _.Id == Id)
                    .ConfigureAwait(false);

            return
                _mapper.Map<MTest_MainInfo>(Test_MainInfoDb);
        }

        public int Add(MTest_MainInfo Test_MainInfo)
        {            
            MTest_MainInfoDb Test_MainInfoDb =
                 _mapper.Map<MTest_MainInfoDb>(Test_MainInfo);

            _context.Set<MTest_MainInfoDb>()
               .Add(Test_MainInfoDb);

            _context.SaveChanges();

            return
                Test_MainInfoDb.Id;
        }

        public Task<int> AddAsync(MTest_MainInfo Test_MainInfo)
        {
            throw new NotImplementedException();
        }

        public void DropById(int Id)
        {
            throw new NotImplementedException();
        }

        public void DropByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
