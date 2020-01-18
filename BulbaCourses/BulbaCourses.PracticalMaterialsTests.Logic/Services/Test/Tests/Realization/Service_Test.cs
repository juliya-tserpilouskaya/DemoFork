using AutoMapper;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Logic.Attributes.DbContext;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Common;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Base;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Interface;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Realization
{
    public class Service_Test : Service_Base, IService_Test
    {
        public Service_Test([AttributeDbContext_LocalDb] DbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public Result<MTest_MainInfo> GetById(int Id)
        {
            try
            {
                MTest_MainInfoDb Test_MainInfoDb =
                    _context.Set<MTest_MainInfoDb>()
                        .Include(_ => _.Questions_ChoosingAnswerFromList)
                        .Include(_ => _.Questions_ChoosingAnswerFromList.Select(c => c.AnswerVariants))
                        .AsNoTracking()
                        .FirstOrDefault(_ => _.Id == Id);

                if (Test_MainInfoDb == null)
                {
                    throw
                        new NullReferenceException();
                }

                return
                    Result<MTest_MainInfo>
                        .Ok(_mapper.Map<MTest_MainInfo>(Test_MainInfoDb));
            }
            catch (NullReferenceException)
            {
                return
                    (Result<MTest_MainInfo>)Result<MTest_MainInfo>
                        .Fail<MTest_MainInfo>($@"There is no test with the specified Id: {Id} in the system.");
            }
        }

        public async Task<Result<MTest_MainInfo>> GetByIdAsync(int Id)
        {
            try
            {
                MTest_MainInfoDb Test_MainInfoDb =
                    await
                        _context.Set<MTest_MainInfoDb>()
                            .Include(_ => _.Questions_ChoosingAnswerFromList)
                            .Include(_ => _.Questions_ChoosingAnswerFromList.Select(c => c.AnswerVariants))
                            .AsNoTracking()
                            .FirstOrDefaultAsync(_ => _.Id == Id)
                            .ConfigureAwait(false);

                if (Test_MainInfoDb == null)
                {
                    throw
                        new NullReferenceException();
                }

                return
                    Result<MTest_MainInfo>
                        .Ok(_mapper.Map<MTest_MainInfo>(Test_MainInfoDb));
            }
            catch (NullReferenceException)
            {
                return
                    (Result<MTest_MainInfo>)Result<MTest_MainInfo>
                        .Fail<MTest_MainInfo>($@"There is no test with the specified Id: {Id} in the system.");
            }
        }

        public Result<MTest_MainInfo> Add(MTest_MainInfo Test_MainInfo)
        {
            try
            {
                MTest_MainInfoDb Test_MainInfoDb =
                    _mapper.Map<MTest_MainInfoDb>(Test_MainInfo);

                _context.Set<MTest_MainInfoDb>().Add(Test_MainInfoDb);

                _context.SaveChanges();

                return
                    Result<MTest_MainInfo>
                        .Ok(_mapper.Map<MTest_MainInfo>(Test_MainInfoDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return 
                    (Result<MTest_MainInfo>)Result<MTest_MainInfo>.Fail<MTest_MainInfo>($"Cannot save model. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return 
                    (Result<MTest_MainInfo>)Result<MTest_MainInfo>.Fail<MTest_MainInfo>($"Cannot save model. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return 
                    (Result<MTest_MainInfo>)Result<MTest_MainInfo>.Fail<MTest_MainInfo>($"Invalid model. {e.Message}");
            }
        }

        public async Task<Result<MTest_MainInfo>> AddAsync(MTest_MainInfo Test_MainInfo)
        {
            try
            {
                MTest_MainInfoDb Test_MainInfoDb =
                    _mapper.Map<MTest_MainInfoDb>(Test_MainInfo);

                _context.Set<MTest_MainInfoDb>().Add(Test_MainInfoDb);

                await
                    _context
                        .SaveChangesAsync();                        

                return
                    Result<MTest_MainInfo>
                        .Ok(_mapper.Map<MTest_MainInfo>(Test_MainInfo));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return 
                    (Result<MTest_MainInfo>)Result<MTest_MainInfo>.Fail<MTest_MainInfo>($"Cannot save model. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return 
                    (Result<MTest_MainInfo>)Result<MTest_MainInfo>.Fail<MTest_MainInfo>($"Cannot save model. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return 
                    (Result<MTest_MainInfo>)Result<MTest_MainInfo>.Fail<MTest_MainInfo>($"Invalid model. {e.Message}");
            }
        }

        public Result<MTest_MainInfo> Update(MTest_MainInfo Test_MainInfo)
        {
            MTest_MainInfoDb Test_MainInfoDb =
                 _mapper.Map<MTest_MainInfoDb>(Test_MainInfo);

            _context.Entry(Test_MainInfoDb).State = EntityState.Added;
            
            try
            {
                _context.SaveChanges();

                return
                    Result<MTest_MainInfo>
                        .Ok(_mapper.Map<MTest_MainInfo>(Test_MainInfoDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<MTest_MainInfo>)Result<MTest_MainInfo>.Fail($"Cannot save model. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<MTest_MainInfo>)Result<MTest_MainInfo>.Fail($"Cannot update model. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<MTest_MainInfo>)Result<MTest_MainInfo>.Fail($"Invalid model. {e.Message}");
            }
        }

        public async Task<Result<MTest_MainInfo>> UpdateAsync(MTest_MainInfo Test_MainInfo)
        {
            MTest_MainInfoDb Test_MainInfoDb =
                 _mapper.Map<MTest_MainInfoDb>(Test_MainInfo);

            var entry = _context.Entry(Test_MainInfo);

            entry.State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                return
                    Result<MTest_MainInfo>
                        .Ok(_mapper.Map<MTest_MainInfo>(Test_MainInfoDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<MTest_MainInfo>)Result<MTest_MainInfo>.Fail($"Cannot save model. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<MTest_MainInfo>)Result<MTest_MainInfo>.Fail($"Cannot update model. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<MTest_MainInfo>)Result<MTest_MainInfo>.Fail($"Invalid model. {e.Message}");
            }
        }

        public Result DeleteById(int Id)
        {
            _context.Entry(new MTest_MainInfoDb() { Id = Id }).State = EntityState.Deleted;

            try
            {
                _context.SaveChanges();

                return
                    Result.Ok();
            }
            catch (NullReferenceException e)
            {
                return (Result<MTest_MainInfo>)Result<MTest_MainInfo>.Fail($"Cannot delete model. {e.Message}");
            }
        }

        public async Task<Result> DeleteByIdAsync(int Id)
        {
            _context.Entry(new MTest_MainInfoDb() { Id = Id }).State = EntityState.Deleted;

            try
            {
                await _context.SaveChangesAsync();

                return
                    Result.Ok();
            }
            catch (NullReferenceException e)
            {
                return (Result<MTest_MainInfo>)Result<MTest_MainInfo>.Fail($"Cannot delete model. {e.Message}");
            }
        }
    }
}