using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Filters;

namespace BulbaCourses.DiscountAggregator.Web
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
                { "oauth2", new List<string>(){/* "openid", "profile", */"api"}}
            });
        }
    }
}