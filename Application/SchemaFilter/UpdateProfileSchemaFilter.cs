using Application.ViewModel.AccountModel;
using Application.ViewModel.RegisterModel;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchemaFilter
{
    public class UpdateProfileSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(AccountViewModel))
            {
                schema.Example = new OpenApiObject
                {
                    ["Username"] = new OpenApiString("string"),
                    ["ImageUrl"] = new OpenApiString("string"),
                    ["FullName"] = new OpenApiString("string"),
                    ["PhoneNumber"] = new OpenApiString("string"),
                    ["Birthday"] = new OpenApiString(DateTime.UtcNow.ToString("yyyy-MM-dd"))
                };
            }
        }
    }
}
