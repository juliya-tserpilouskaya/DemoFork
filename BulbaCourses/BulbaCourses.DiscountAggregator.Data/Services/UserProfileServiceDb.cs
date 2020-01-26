using BulbaCourses.DiscountAggregator.Data.Context;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public class UserProfileServiceDb : IUserProfileServiceDb
    {
        private readonly DAContext context;

        public UserProfileServiceDb(DAContext context)
        {
            this.context = context;
        }

        public void Add(UserProfileDb profile)
        {
            context.Profiles.Add(profile);
            context.SearchCriterias.Add(profile.SearchCriteria);
            context.SaveChanges();
        }

        public async Task<Result<UserProfileDb>> AddAsync(UserProfileDb profileDb)
        {
            try
            {
                List<CourseCategoryDb> courseCategories = new List<CourseCategoryDb>();
                List<DomainDb> domains = new List<DomainDb>();
                CourseCategoryDb categoryDb;
                DomainDb domainDb; 

                foreach (var el in profileDb.SearchCriteria.CourseCategories)
                {
                    categoryDb = context.CourseCategories
                        .FirstOrDefault(x => x.Name == el.Name && x.Title == el.Title);
                    courseCategories.Add(categoryDb ??
                        new CourseCategoryDb()
                        {
                            Name = el.Name,
                            Title = el.Title
                        });
                }
                
                foreach (var el in profileDb.SearchCriteria.Domains)
                {
                    domainDb = context.Domains
                        .FirstOrDefault(x => x.DomainURL == el.DomainURL);
                    domains.Add(domainDb ?? 
                        new DomainDb()
                        {
                            DomainURL = el.DomainURL,
                            DomainName = el.DomainName
                        });
                }
                profileDb.SearchCriteria.CourseCategories = courseCategories;
                profileDb.SearchCriteria.Domains = domains;

                context.Profiles.Add(profileDb);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return Result<UserProfileDb>.Ok(profileDb);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<UserProfileDb>.Fail<UserProfileDb>($"Cannot save profile. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return Result<UserProfileDb>.Fail<UserProfileDb>($"Cannot save profile. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return Result<UserProfileDb>.Fail<UserProfileDb>($"Invalid profile. {e.Message}");
            }
        }

        public IEnumerable<UserProfileDb> GetAll() => context.Profiles.ToList().AsReadOnly();
        
        public async Task<IEnumerable<UserProfileDb>> GetAllAsync()
        {
            var userList = await context.Profiles
                .Include(x => x.SearchCriteria)
                .Include(c => c.SearchCriteria.Domains)
                .Include(v => v.SearchCriteria.CourseCategories).ToListAsync().ConfigureAwait(false);
            return userList.AsReadOnly();
        }

        public UserProfileDb GetById(string id) => context.Profiles.FirstOrDefault(c => c.Id.Equals(id));

        public async Task<UserProfileDb> GetByIdAsync(string id)
        {
            var profileDb = await context.Profiles
                .Include(x => x.SearchCriteria)
                .Include(c => c.SearchCriteria.Domains)
                .Include(v => v.SearchCriteria.CourseCategories)
                .SingleOrDefaultAsync(c => c.Id.Equals(id)).ConfigureAwait(false);
            return profileDb;
        }

        public void Delete(UserProfileDb profileDb)
        {

            context.SearchCriterias.Remove(context.SearchCriterias.Find(profileDb.SearchCriteria.Id));
            context.Profiles.Remove(profileDb);
            context.SaveChanges();
        }

        public async Task<Result<UserProfileDb>> DeleteAsync(UserProfileDb profileDb)
        {
            try
            {
                context.Profiles.Remove(profileDb);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return Result<UserProfileDb>.Ok(profileDb);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<UserProfileDb>.Fail<UserProfileDb>($"Profile not deleted. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return Result<UserProfileDb>.Fail<UserProfileDb>($"Invalid profile. {e.Message}");
            }
        }

        public void Update(UserProfileDb profile)
        {
            if (profile != null)
            {
                context.Entry(profile).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public async Task<Result<UserProfileDb>> UpdateAsync(UserProfileDb profileDb)
        {
            try
            {
                context.Entry(profileDb).State = EntityState.Modified;
                await context.SaveChangesAsync().ConfigureAwait(false);
                return Result<UserProfileDb>.Ok(profileDb);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<UserProfileDb>.Fail<UserProfileDb>($"Profile not deleted. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return Result<UserProfileDb>.Fail<UserProfileDb>($"Cannot save profile. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return Result<UserProfileDb>.Fail<UserProfileDb>($"Invalid profile. {e.Message}");
            }
        }

        public async Task<bool> ExistsAsync(string email) 
            => await context.Profiles.AnyAsync(b => b.Email == email).ConfigureAwait(false);
    }
}
