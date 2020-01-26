using AutoMapper;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Data.Models.WorkWithResultTest;
using BulbaCourses.PracticalMaterialsTests.Logic.Attributes.DbContext;
using BulbaCourses.PracticalMaterialsTests.Logic.Attributes.Test.Questions;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Base;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.Questions;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.WorkWithResultTest;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Base;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Interface;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Questions.Interfaсe;
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

        IService_Question _service_Question_ChoosingAnswerFromList;

        IService_Question _service_Question_SetOrder;

        public Service_Test([AttributeDbContext_LocalDb] DbContext context, [AttributeQuestion_ChoosingAnswerFromList]IService_Question service_Question_ChoosingAnswerFromList, [AttributeQuestion_SetOrder]IService_Question service_Question_SetOrder, IMapper mapper, IService_WorkWithResultTest service_WorkWithResultTest) : base(context, mapper)
        {
            _service_WorkWithResultTest = service_WorkWithResultTest;

            _service_Question_ChoosingAnswerFromList = service_Question_ChoosingAnswerFromList;

            _service_Question_SetOrder = service_Question_SetOrder;
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
                            .Include(_ => _.User_TestAuthor)
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

        public MResultRequest<string> CheckTestAsync(string User_TestAuthor_Id, MTest_MainInfo User_Test_MainInfo)
        {
            AddUserPassingTest(User_Test_MainInfo);

            MTest_MainInfo Current_Test_MainInfo = GetById(User_Test_MainInfo.Id).Data;

            // Общее количество всех вопросов
            int CountQuestion = 
                Current_Test_MainInfo.Questions_ChoosingAnswerFromList.Count() + Current_Test_MainInfo.Questions_SetOrder.Count();

            // Количество правильных ответов
            int CountRightAnswer = 0;

            // Храним номер правильного ответа
            int Current_Questions_ChoosingAnswerFromList = 0;

            // Получаем номер правильного ответа из базы
            foreach (var Row in Current_Test_MainInfo.Questions_ChoosingAnswerFromList)
            {
                Current_Questions_ChoosingAnswerFromList = Row.AnswerVariants.FirstOrDefault(f => f.IsCorrectAnswer).SortKey;
            }

            // Храним номер ответа пользователя, который от посчитал правильным
            int User_Questions_ChoosingAnswerFromList = 0;

            // Получаем ответ пользователя
            foreach (var Row in User_Test_MainInfo.Questions_ChoosingAnswerFromList)
            {
                User_Questions_ChoosingAnswerFromList = Row.AnswerVariants.FirstOrDefault(f => f.IsCorrectAnswer).SortKey;
            }

            // Наращиваем счетчик, если номера сошлись
            if (Current_Questions_ChoosingAnswerFromList == User_Questions_ChoosingAnswerFromList)
            {
                CountRightAnswer++;
            }

            // Список для хранения корректных последовательностей ответов
            List<int> Current_Questions_SetOrder = new List<int>();

            // Получаем корректную последовательность ответов
            foreach (var Row in Current_Test_MainInfo.Questions_SetOrder)
            {
                Current_Questions_SetOrder.AddRange(Row.AnswerVariants.Select(s => s.CorrectOrderKey));
            }

            // Список для хранения последовательностей ответов пользователя
            List<int> User_Questions_SetOrder = new List<int>();

            // Получаем пользовательскую последовательность ответов
            foreach (var Row in User_Test_MainInfo.Questions_SetOrder)
            {
                User_Questions_SetOrder.AddRange(Row.AnswerVariants.Select(s => s.SortKey));
            }

            // Результат сверки двух последовательностей
            var Rezult_Questions_SetOrder = Current_Questions_SetOrder.SequenceEqual(User_Questions_SetOrder);

            // Наращиваем счетчик, если результат True
            if (Rezult_Questions_SetOrder)
            {
                CountRightAnswer++;
            }

            // Наполняем модель результата прохождения теста, чтобы записать в базу
            MReaderChoice_MainInfoDb ReaderChoice_MainInfoDb = new MReaderChoice_MainInfoDb()
            {
                ResultTest = $"Количество правильных ответов: {CountRightAnswer} из {CountQuestion}.",
                Test_MainInfoDb_Id = 1,
                User_TestReaderDb_Id = "one-two-three-four"
            };


            return
                _service_WorkWithResultTest.Add(ReaderChoice_MainInfoDb);
        }

        // ------------ AddPassingTest

        public void AddUserPassingTest(MTest_MainInfo User_Test_MainInfo)
        {
            //// Наполнение данными
            //List<MReaderChoice_ChoosingAnswerFromList> LReaderChoice_ChoosingAnswerFromList = 
            //    new List<MReaderChoice_ChoosingAnswerFromList>();

            //List<MReaderChoice_SetOrder> LReaderChoice_SetOrderDb = 
            //    new List<MReaderChoice_SetOrder>();

            //int Question_Choise = 1;

            //// Получение данных и запись в экземпляр
            //foreach (var Row in User_Test_MainInfo.Questions_ChoosingAnswerFromList)
            //{
            //    MReaderChoice_ChoosingAnswerFromList ReaderChoice_ChoosingAnswerFromList =
            //        new MReaderChoice_ChoosingAnswerFromList();

            //    ReaderChoice_ChoosingAnswerFromList.ReaderChoice_MainInfoDb_Id = 1;

            //    ReaderChoice_ChoosingAnswerFromList.Test_MainInfoDb_Id = 1;

            //    ReaderChoice_ChoosingAnswerFromList.Question_ChoosingAnswerFromList_Id = Question_Choise++;

            //    foreach (var X in Row.AnswerVariants)
            //    {
            //        ReaderChoice_ChoosingAnswerFromList.AnswerVariant_ChoosingAnswerFromListDb_Id = X.SortKey;

            //        ReaderChoice_ChoosingAnswerFromList.IsChoice = X.IsCorrectAnswer;

            //        LReaderChoice_ChoosingAnswerFromList.Add(ReaderChoice_ChoosingAnswerFromList);
            //    }
            //}

            //int Answer_SetOrder = 1;

            //int Question_SetOrder = 1;

            //foreach (var Row in User_Test_MainInfo.Questions_SetOrder)
            //{
            //    MReaderChoice_SetOrder ReaderChoice_SetOrder =
            //        new MReaderChoice_SetOrder();

            //    ReaderChoice_SetOrder.ReaderChoice_MainInfoDb_Id = 1;

            //    ReaderChoice_SetOrder.Test_MainInfoDb_Id = 1;

            //    ReaderChoice_SetOrder.Question_SetOrderDb_Id = Question_SetOrder++;

            //    foreach (var X in Row.AnswerVariants)
            //    {
            //        ReaderChoice_SetOrder.AnswerVariant_SetOrderDb_Id = Answer_SetOrder++;

            //        ReaderChoice_SetOrder.OrderKey = X.SortKey;

            //        LReaderChoice_SetOrderDb.Add(ReaderChoice_SetOrder);
            //    }                
            //}

            //// Подготовка к записи
            //foreach (var Result in LReaderChoice_ChoosingAnswerFromList)
            //{
            //    var ReaderChoice_ChoosingAnswerFromListDb =
            //        _context.Set<MReaderChoice_ChoosingAnswerFromListDb>();

            //    ReaderChoice_ChoosingAnswerFromListDb.Add(new MReaderChoice_ChoosingAnswerFromListDb
            //    {
            //        ReaderChoice_MainInfoDb_Id = Result.ReaderChoice_MainInfoDb_Id,
            //        Test_MainInfoDb_Id = Result.Test_MainInfoDb_Id,
            //        Question_ChoosingAnswerFromList_Id = Result.Question_ChoosingAnswerFromList_Id,
            //        AnswerVariant_ChoosingAnswerFromListDb_Id = Result.AnswerVariant_ChoosingAnswerFromListDb_Id,
            //        IsChoice = Result.IsChoice
            //    });
            //}

            //foreach (var Result in LReaderChoice_SetOrderDb)
            //{
            //    var ReaderChoice_SetOrderDb =
            //        _context.Set<MReaderChoice_SetOrderDb>();

            //    ReaderChoice_SetOrderDb.Add(new MReaderChoice_SetOrderDb
            //    {
            //        ReaderChoice_MainInfoDb_Id = Result.ReaderChoice_MainInfoDb_Id,
            //        Test_MainInfoDb_Id = Result.Test_MainInfoDb_Id,
            //        Question_SetOrderDb_Id = Result.Question_SetOrderDb_Id,
            //        AnswerVariant_SetOrderDb_Id = Result.AnswerVariant_SetOrderDb_Id,
            //        OrderKey = Result.OrderKey
            //    });
            //}

            //try
            //{
            //    _context.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException e)
            //{
            //    throw new DbUpdateConcurrencyException();
            //}
            //catch (DbUpdateException e)
            //{
            //    throw new DbUpdateException();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    throw new DbEntityValidationException();
            //}
        }
    }
}