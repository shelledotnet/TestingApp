using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.API.Models;

namespace Test.API.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(m => m.Value.Errors)
                             .Select(m => m.ErrorMessage)
                             .ToList();
        }

        public static ResponseModel GetApiResponse(this ModelStateDictionary dictionary)
        {
            return new ResponseModel() { Code = "57", Data = GetErrorMessages(dictionary).FirstOrDefault() , Description="Failed" };
        }
    }
}
