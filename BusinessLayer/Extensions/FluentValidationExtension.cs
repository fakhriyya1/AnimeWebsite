using Microsoft.AspNetCore.Mvc.ModelBinding;
using FluentValidation.Results;


namespace AnimeBusiness.Extensions
{
    public static class FluentValidationExtension
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
