using AutoMapper;
using BulbaCourses.PracticalMaterialsTests.Data.Models.WorkWithResultTest;
using BulbaCourses.PracticalMaterialsTests.Logic.Attributes.DbContext;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Base;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Base;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.WorkWithResultTest.Interface
{
    public class Service_WorkWithResultTest : Service_Base, IService_WorkWithResultTest
    {
        public Service_WorkWithResultTest([AttributeDbContext_LocalDb] DbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public MResultRequest<string> Add(MReaderChoice_MainInfoDb ResultOfTheTestDb)
        {
            try
            {
                _context.Set<MReaderChoice_MainInfoDb>().Add(ResultOfTheTestDb);

                _context.SaveChanges();

                return
                    MResultRequest<string>
                        .Ok(String.Join("",_context.Set<MReaderChoice_MainInfoDb>().Where(_ => _.Id == ResultOfTheTestDb.Id).Select(_ => _.ResultTest)));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return
                    (MResultRequest<string>)MResultRequest<string>.Fail<string>($"Cannot save model. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return
                    (MResultRequest<string>)MResultRequest<string>.Fail<string>($"Cannot save model. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return
                    (MResultRequest<string>)MResultRequest<string>.Fail<string>($"Invalid model. {e.Message}");
            }
        }

        public async Task<MResultRequest<string>> AddAsync(MReaderChoice_MainInfoDb ResultOfTheTestDb)
        {
            try
            {
                _context.Set<MReaderChoice_MainInfoDb>().Add(ResultOfTheTestDb);

                await
                    _context
                        .SaveChangesAsync();

                return
                    MResultRequest<string>
                        .Ok("Complite !!!");
            }
            catch (DbUpdateConcurrencyException e)
            {
                return
                    (MResultRequest<string>)MResultRequest<string>.Fail<string>($"Cannot save model. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return
                    (MResultRequest<string>)MResultRequest<string>.Fail<string>($"Cannot save model. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return
                    (MResultRequest<string>)MResultRequest<string>.Fail<string>($"Invalid model. {e.Message}");
            }
        }
    }
}
