using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.API.Extensions;

namespace Test.API.Filters
{
    #region This further experess a valid general responses to all DataAnotation attribute and custom validation attribute for Dtos

    #endregion
    public class DtoStateValidatorActionFilter : ActionFilterAttribute
    {
        //called before the action method is execute and after model binding as occured
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //if u r retuning a result that means u r shotsocketing
            if (!context.ModelState.IsValid)
                context.Result = new BadRequestObjectResult(context.ModelState.GetApiResponse());

        }
    }
}
