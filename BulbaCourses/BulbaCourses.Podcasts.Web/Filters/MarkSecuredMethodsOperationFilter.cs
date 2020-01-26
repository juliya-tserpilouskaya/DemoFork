using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Filters;

namespace BulbaCourses.Podcasts.Web
{
    public class MarkSecuredMethodsOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var filters = apiDescription.ActionDescriptor.GetFilterPipeline();

            if (!filters.Select(f => f.Instance).OfType<AuthorizeAttribute>().Any())
            {
                return;
            }

            operation.security = operation.security ?? new List<IDictionary<string, IEnumerable<string>>>();
            operation.security.Add(new Dictionary<string, IEnumerable<string>>()
            {
                { "oauth2", new List<string>(){"api"}}
            });
        }

        //public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        //{
        //    var filterPipeline = apiDescription.ActionDescriptor.GetFilterPipeline();
        //    // check if authorization is required
        //    var isAuthorized = filterPipeline
        //        .Select(filterInfo => filterInfo.Instance)
        //        .Any(filter => filter is IAuthorizationFilter);
        //    // check if anonymous access is allowed
        //    var allowAnonymous = apiDescription.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        //    if (isAuthorized && !allowAnonymous)
        //    {
        //        if (operation.security == null)
        //            operation.security = new List<IDictionary<string, IEnumerable<string>>>();
        //        var auth = new Dictionary<string, IEnumerable<string>>
        //{
        //    {"basic", Enumerable.Empty<string>()}
        //};
        //        operation.security.Add(auth);
        //    }
        //}
    }
}