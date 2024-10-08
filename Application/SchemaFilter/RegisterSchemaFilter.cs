﻿using Application.ViewModel.RegisterModel;
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
    public class RegisterSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(RegisterForm))
            {
                schema.Example = new OpenApiObject
                {
                    ["Username"] = new OpenApiString("string"),
                    ["Email"] = new OpenApiString("string"),
                    ["Password"] = new OpenApiString("string"),
                    ["FullName"]=new OpenApiString("string"),
                    ["PhoneNumber"]=new OpenApiString("string"),    
                    ["Birthday"] = new OpenApiString(DateTime.UtcNow.ToString("yyyy-MM-dd"))
                };
            }
        }
    }
}
