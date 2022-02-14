using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.API.Filters
{

    /// <summary>
    /// This is on of the ways to retire or discontinue older version of an API by using ResourceFilter
    /// preenting user to continually hitting the older version of the resources
    /// </summary>
    public class Version1DiscontinueResourceFilter : Attribute, IResourceFilter
    {
        //this is executed after all the enpoint has execute--i dont want this
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            
        }

        //this is execute b4 the action method and after model binding as occured---this is better
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (!context.HttpContext.Request.Path.Value.ToLower().Contains("v2"))
            {
                //if u r retuning a result that means u r shotsocketing
                context.Result = new BadRequestObjectResult(new { code="57",data=new {varsions="this version of API has expired , please use the latest version",response="sorry for all incoviniency"},description="Failed"});

            }
        }
    }
}
