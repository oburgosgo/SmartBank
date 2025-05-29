using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Filters;
using SmartBank.Shared.API.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank.Shared.API.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Where(x=>x.Value?.Errors.Count>0)
                    .SelectMany(x=>x.Value!.Errors.Select(x=>x.ErrorMessage)).ToList();

                var response = APIResponse<string>.Failed("Validations failed", errors);

                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}
