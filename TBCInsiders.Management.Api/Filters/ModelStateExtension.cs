using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Models;
using TBCInsiders.Management.ApplicationCore.Responses;

namespace TBCInsiders.Management.Api.Filters
{
    public static class ModelStateExtension
    {

        public static BaseResponse ToErrorResponse(this ModelStateDictionary modelState)
        {
            var response = new BaseResponse
            {
                ValidationErrors = new List<string>()
            };


            foreach (var state in modelState)
            {
                var message = state.Value.Errors
                    .Where(error => !string.IsNullOrWhiteSpace(error.ErrorMessage))
                    .Select(error => error.ErrorMessage)
                    .Concat(state.Value.Errors
                       .Where(error => string.IsNullOrWhiteSpace(error.ErrorMessage))
                       .Select(error => error.Exception.Message))
                    .ToList();

                if (message.Any())
                {
                    response.ValidationErrors.AddRange(message);
                }

            }
            return response;
        }
    }
}
