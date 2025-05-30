using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;
using SmartBank.Shared.API.Reponse;

namespace SmartBank.Shared.API.Filters
{
    public class ValidatorResultFactory : IFluentValidationAutoValidationResultFactory
    {
        public IActionResult CreateActionResult(ActionExecutingContext context, ValidationProblemDetails? validationProblemDetails)
        {

            var errors = validationProblemDetails?.Errors.Values.Select(x => x[0]).ToList();

            return new BadRequestObjectResult(APIResponse<object>.Failed("Invalid request. Please check the validation errors.", errors));
        }
    }
}
