﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ValidateModelStateFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        
        if (!context.ModelState.IsValid)
        {
     
            context.Result = new BadRequestObjectResult(context.ModelState);
        }

   
        base.OnActionExecuting(context);
    }

  
    public override void OnActionExecuted(ActionExecutedContext context)
    {
       
        base.OnActionExecuted(context);
    }
}