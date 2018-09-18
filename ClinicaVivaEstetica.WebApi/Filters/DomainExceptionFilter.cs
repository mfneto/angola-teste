using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ClinicaVivaEstetica.Domain;
using ClinicaVivaEstetica.WebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClinicaVivaEstetica.WebApi.Filters
{
    public class DomainExceptionFilter : IExceptionFilter
    {
        
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is AggregateException aggregateException && aggregateException.InnerException is ClinicaVivaEsteticaException apiGlobalInnerException)
            {
                HandlingapiGlobalExceptionApi(context, apiGlobalInnerException);

            }
            else if (context.Exception is ClinicaVivaEsteticaException apiGlobalException)
            {
                HandlingapiGlobalExceptionApi(context, apiGlobalException);
            }
            else
            {
                var objJsonRetorno = new ApiReturnItem<object>
                {
                    Item = null,
                    Success = false,
                    ApiReturnMessage = new ApiReturnMessage
                    {
                        Title = "Erro ao executar a Requisição!",
                        Details = new List<string> { context.Exception.Message }
                    }
                };

                HandlingInnerExceptions(context, objJsonRetorno);

                context.Result = new BadRequestObjectResult(objJsonRetorno);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }

        private static void HandlingapiGlobalExceptionApi(ExceptionContext context,
            ClinicaVivaEsteticaException apiGlobalException)
        {

            var objJsonRetorno = new ApiReturnItem<object>
            {
                Item = null,
                Success = false,
                ApiReturnMessage = new ApiReturnMessage
                {
                    Title = String.IsNullOrWhiteSpace(apiGlobalException.Message) ? "Erro ao executar a Requisição!" : apiGlobalException.Message,
                    Details = apiGlobalException.Messages?.Any() == true ? apiGlobalException.Messages : new List<String> { apiGlobalException.Message }
                }
            };

            HandlingInnerExceptions(context, objJsonRetorno);

            var titleOfExistingException = objJsonRetorno.ApiReturnMessage?.Title;

            if (!String.IsNullOrWhiteSpace(titleOfExistingException))
            {
                if (objJsonRetorno.ApiReturnMessage.Details.Contains(titleOfExistingException))
                    objJsonRetorno.ApiReturnMessage.Details.Remove(titleOfExistingException);
            }

            context.Result = new BadRequestObjectResult(objJsonRetorno);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
        }

        private static void HandlingInnerExceptions(ExceptionContext context, ApiReturnItem<object> objJsonRetorno)
        {
            if (context.Exception.InnerException != null)
            {
                var excpt = context.Exception.InnerException;
                var countExcpt = 0;

                while (excpt != null && countExcpt < 5)
                {
                    if (!objJsonRetorno.ApiReturnMessage.Details.Contains(excpt.Message))
                        objJsonRetorno.ApiReturnMessage.Details.Add(excpt.Message);

                    excpt = excpt.InnerException;
                }
            }
        }
    }
}
