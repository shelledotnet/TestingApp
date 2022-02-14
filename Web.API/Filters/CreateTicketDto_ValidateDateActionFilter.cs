using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.API.Extensions;
using Test.API.Models;

namespace Test.API.Filters
{
    public class CreateTicketDto_ValidateDateActionFilter : ActionFilterAttribute
    {
        //called before the action method is execute and after model binding as occured
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            CreateTicketDto tickets = context.ActionArguments["ticket"] as CreateTicketDto;
            bool isValid = true;
            if (tickets !=null && !string.IsNullOrWhiteSpace(tickets.Owner))
            {
                if(tickets.ReportDate.HasValue == false)
                {
                    context.ModelState.AddModelError("ReportDate", "Report date is required");
                    //its a good practise to name the key the afftected field ...becos actionfilter only affect action method
                    isValid=false;
                }
                if (tickets.ReportDate.HasValue && tickets.Deudate.HasValue && tickets.ReportDate > tickets.Deudate)
                {
                    context.ModelState.AddModelError("DeuDate", "Deu date has to be later than Entered date");
                    isValid = false;
                }
                if (!isValid)
                    context.Result = new BadRequestObjectResult(context.ModelState.GetApiResponse());
                    //if u r retuning a result that means u r shotsocketing   
            }
        }

    }
}
