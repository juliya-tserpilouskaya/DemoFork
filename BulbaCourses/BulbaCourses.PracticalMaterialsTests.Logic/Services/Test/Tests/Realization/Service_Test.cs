using AutoMapper;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Logic.Attributes.DbContext;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Base;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.Questions;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.WorkWithResultTest;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Base;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Interface;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.WorkWithResultTest.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Realization
{
    public class Service_Test : Service_Base, IService_Test
    {
        IService_WorkWithResultTest _service_WorkWithResultTest;

        public Service_Test([AttributeDbContext_LocalDb] DbContext context, IMapper mapper, IService_WorkWithResultTest service_WorkWithResultTest) : base(context, mapper)
        {
            _service_WorkWithResultTest = service_WorkWithResultTest;
        }

        // ------------ CRUD

        public MResultRequest<MTest_MainInfo> GetById(int Id)
        {
            try
            {
                MTest_MainInfoDb Test_MainInfoDb =
                    _context.Set<MTest_MainInfoDb>()
                        .Include(_ => _.Questions_ChoosingAnswerFromList)
                        .Include(_ => _.Questions_ChoosingAnswerFromList.Select(c => c.AnswerVariants))                                                
                        .Include(_ => _.Questions_SetOrder)
                        .Include(_ => _.Questions_SetOrder.Select(c => c.AnswerVariants))
                        .AsNoTracking()
                        .FirstOrDefault(_ => _.Id == Id);

                if (Test_MainInfoDb == null)
                {
                    throw
                        new NullReferenceException();
                }

                return
                    MResultRequest<MTest_MainInfo>
                        .Ok(_mapper.Map<MTest_MainInfo>(Test_MainInfoDb));
            }
            catch (NullReferenceException)
            {
                return
                    (MResultRequest<MTest_MainInfo>)MResultRequest<MTest_MainInfo>
                        .Fail<MTest_MainInfo>($@"There is no test with the specified Id: {Id} in the system.");
            }
        }

        public async Task<MResultRequest<MTest_MainInfo>> GetByIdAsync(int Id)
        {
            try
            {
                MTest_MainInfoDb Test_MainInfoDb =
                    await
                        _context.Set<MTest_MainInfoDb>()
                            .Include(_ => _.Questions_ChoosingAnswerFromList)
                            .Include(_ => _.Questions_ChoosingAnswerFromList.Select(c => c.AnswerVariants))   
                            .Include(_ => _.Questions_SetOrder)
                            .Include(_ => _.Questions_SetOrder.Select(c => c.AnswerVariants))
                            .AsNoTracking()
                            .FirstOrDefaultAsync(_ => _.Id == Id)
                            .ConfigureAwait(false);

                if (Test_MainInfoDb == null)
                {
                    throw
                        new NullReferenceException();
                }

                return
                    MResultRequest<MTest_MainInfo>
                        .Ok(_mapper.Map<MTest_MainInfo>(Test_MainInfoDb));
            }
            catch (NullReferenceException)
            {
                return
                    (MResultRequest<MTest_MainInfo>)MResultRequest<MTest_MainInfo>
                        .Fail<MTest_MainInfo>($@"There is no test with the specified Id: {Id} in the system.");
            }
        }

        public MResultRequest<MTest_MainInfo> Add(string User_TestAuthor_Id, MTest_MainInfo Test_MainInfo)
        {
            try
            {
                MTest_MainInfoDb Test_MainInfoDb =
                    _mapper.Map<MTest_MainInfoDb>(Test_MainInfo);

                Test_MainInfoDb.User_TestAuthorDb_Id = User_TestAuthor_Id;

                _context.Set<MTest_MainInfoDb>().Add(Test_MainInfoDb);

                _context.SaveChanges();

                return
                    MResultRequest<MTest_MainInfo>
                        .Ok(_mapper.Map<MTest_MainInfo>(Test_MainInfoDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return 
                    (MResultRequest<MTest_MainInfo>)MResultRequest<MTest_MainInfo>.Fail<MTest_MainInfo>($"Cannot save model. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return 
                    (MResultRequest<MTest_MainInfo>)MResultRequest<MTest_MainInfo>.Fail<MTest_MainInfo>($"Cannot save model. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return 
                    (MResultRequest<MTest_MainInfo>)MResultRequest<MTest_MainInfo>.Fail<MTest_MainInfo>($"Invalid model. {e.Message}");
            }
        }

        public async Task<MResultRequest<MTest_MainInfo>> AddAsync(string User_TestAuthor_Id, MTest_MainInfo Test_MainInfo)
        {
            try
            {
                MTest_MainInfoDb Test_MainInfoDb =
                    _mapper.Map<MTest_MainInfoDb>(Test_MainInfo);

                Test_MainInfoDb.User_TestAuthorDb_Id = User_TestAuthor_Id;

                _context.Set<MTest_MainInfoDb>().Add(Test_MainInfoDb);

                await
                    _context
                        .SaveChangesAsync();                        

                return
                    MResultRequest<MTest_MainInfo>
                        .Ok(_mapper.Map<MTest_MainInfo>(Test_MainInfo));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return 
                    (MResultRequest<MTest_MainInfo>)MResultRequest<MTest_MainInfo>.Fail<MTest_MainInfo>($"Cannot save model. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return 
                    (MResultRequest<MTest_MainInfo>)MResultRequest<MTest_MainInfo>.Fail<MTest_MainInfo>($"Cannot save model. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return 
                    (MResultRequest<MTest_MainInfo>)MResultRequest<MTest_MainInfo>.Fail<MTest_MainInfo>($"Invalid model. {e.Message}");
            }
        }

        public MResultRequest<MTest_MainInfo> Update(string User_TestAuthor_Id, MTest_MainInfo Test_MainInfo)
        {
            try
            {
                MTest_MainInfoDb Test_MainInfoDb =
                _mapper.Map<MTest_MainInfoDb>(Test_MainInfo);

                Test_MainInfoDb.User_TestAuthorDb_Id = User_TestAuthor_Id;

                _context.Set<MTest_MainInfoDb>().Remove(
                    _context.Set<MTest_MainInfoDb>().Find(Test_MainInfo.Id));

                _context.Set<MTest_MainInfoDb>().Add(Test_MainInfoDb);

                _context.SaveChanges();

                return
                    MResultRequest<MTest_MainInfo>
                        .Ok(_mapper.Map<MTest_MainInfo>(Test_MainInfoDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return
                    (MResultRequest<MTest_MainInfo>)MResultRequest<MTest_MainInfo>.Fail<MTest_MainInfo>($"Cannot update model. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return
                    (MResultRequest<MTest_MainInfo>)MResultRequest<MTest_MainInfo>.Fail<MTest_MainInfo>($"Cannot update model. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return
                    (MResultRequest<MTest_MainInfo>)MResultRequest<MTest_MainInfo>.Fail<MTest_MainInfo>($"Cannot update model. {e.Message}");
            }
        }

        public async Task<MResultRequest<MTest_MainInfo>> UpdateAsync(string User_TestAuthor_Id, MTest_MainInfo Test_MainInfo)
        {
            try
            {
                MTest_MainInfoDb Test_MainInfoDb =
                _mapper.Map<MTest_MainInfoDb>(Test_MainInfo);

                Test_MainInfoDb.User_TestAuthorDb_Id = User_TestAuthor_Id;

                _context.Set<MTest_MainInfoDb>().Remove(
                    _context.Set<MTest_MainInfoDb>().Find(Test_MainInfo.Id));

                _context.Set<MTest_MainInfoDb>().Add(Test_MainInfoDb);

                await _context.SaveChangesAsync();

                return
                    MResultRequest<MTest_MainInfo>
                        .Ok(_mapper.Map<MTest_MainInfo>(Test_MainInfoDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return
                    (MResultRequest<MTest_MainInfo>)MResultRequest<MTest_MainInfo>.Fail<MTest_MainInfo>($"Cannot update model. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return
                    (MResultRequest<MTest_MainInfo>)MResultRequest<MTest_MainInfo>.Fail<MTest_MainInfo>($"Cannot update model. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return
                    (MResultRequest<MTest_MainInfo>)MResultRequest<MTest_MainInfo>.Fail<MTest_MainInfo>($"Cannot update model. {e.Message}");
            }
        }

        public MResultRequest DeleteById(int Id)
        {
            try
            {
                _context.Entry(new MTest_MainInfoDb() { Id = Id }).State = EntityState.Deleted;

                _context.SaveChanges();

                return
                    MResultRequest.Ok();
            }
            catch (NullReferenceException e)
            {
                return
                    (MResultRequest<MTest_MainInfo>)MResultRequest<MTest_MainInfo>.Fail<MTest_MainInfo>($"Cannot delete model. {e.Message}");
            }
        }

        public async Task<MResultRequest> DeleteByIdAsync(int Id)
        {
            try
            {
                _context.Entry(new MTest_MainInfoDb() { Id = Id }).State = EntityState.Deleted;

                await _context.SaveChangesAsync();

                return
                    MResultRequest.Ok();
            }
            catch (NullReferenceException e)
            {
                return
                    (MResultRequest<MTest_MainInfo>)MResultRequest<MTest_MainInfo>.Fail<MTest_MainInfo>($"Cannot delete model. {e.Message}");
            }
        }

        // ------------ CheckCorrectAnswer

        public MResultRequest<string> CheckTest(string User_TestAuthor_Id, MTest_MainInfo User_Test_MainInfo)
        {
            MTest_MainInfo Current_Test_MainInfo = GetById(User_Test_MainInfo.Id).Data;

            //// ------------ Check_Question_ChoosingAnswerFromList
            //foreach (MQuestion_ChoosingAnswerFromList x in Current_Test_MainInfo.Questions_ChoosingAnswerFromList)
            //{

            //}

            //// ------------ Question_SetOrder
            //foreach (MQuestion_SetOrder x in Current_Test_MainInfo.Questions_SetOrder)
            //{

            //}          

            //for (int i = 0; i < Current_Test_MainInfo.Questions_ChoosingAnswerFromList.Count; i++)
            //{
            //    for (int j = 0; j < Current_Test_MainInfo.Questions_ChoosingAnswerFromList[i].AnswerVariants.Count; j++)
            //    {
            //       if (Current_Test_MainInfo.Questions_ChoosingAnswerFromList[i].AnswerVariants[j].IsCorrectAnswer ==
            //                User_Test_MainInfo.Questions_ChoosingAnswerFromList[i].AnswerVariants[j].IsCorrectAnswer)
            //       {

            //       }
            //    }
            //}

            //for (int i = 0; i < Current_Test_MainInfo.Questions_SetOrder.Count; i++)
            //{
            //    for (int j = 0; j < Current_Test_MainInfo.Questions_SetOrder[i].AnswerVariants.Count; j++)
            //    {
            //        if (Current_Test_MainInfo.Questions_SetOrder[i].AnswerVariants[j].CorrectOrderKey ==
            //                User_Test_MainInfo.Questions_SetOrder[i].AnswerVariants[j].CorrectOrderKey)
            //        {

            //        }
            //    }
            //}

            return
                _service_WorkWithResultTest.Add(null);
        }
    }
}