using iCBM.Application.Exceptions;
using Misio.Common.WebApi.Exceptions;
using System;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace iCBM.WebApi
{
    public class ExceptionToResponseMapper : IExceptionToResponseMapper
    {
        public ExceptionResponse Map(Exception ex)
        {
            return ex switch
            {
                EmailAlreadyInUseException emailAlreadyInUseException => new ExceptionResponse("email_in_use", ex.Message, HttpStatusCode.BadRequest),
                InvalidCredentialsException invalidCredentialsException => new ExceptionResponse("invalid_credentials", ex.Message, HttpStatusCode.BadRequest),
                InvalidEmailException invalidEmailException => new ExceptionResponse("invalid_email", ex.Message, HttpStatusCode.BadRequest),
                ResourceNotFoundException resourceNotFoundException => new ExceptionResponse("not_found", ex.Message, HttpStatusCode.NotFound),
                NameAlreadyExistException nameAlreadyExistException => new ExceptionResponse("name_in_use", ex.Message, HttpStatusCode.NotFound),
                _ => null
            };
        }
    }
}
