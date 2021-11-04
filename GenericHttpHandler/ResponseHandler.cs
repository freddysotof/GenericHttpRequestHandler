using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace GenericHttpHandler
{
    public class ResponseHandler<T> where T: class
    {
        public ResponseHandler()
        {
            Data = new List<T>();
            Messages = new List<MessageHandler>();
            Errors = new List<ErrorHandler>();
            Count = DataCount;
        }
        public ResponseHandler(T obj = null, IEnumerable<T> data = null, MessageHandler messageHandler = null, 
            ErrorHandler errorHandler = null)
        {
            if (obj != null)
                Data = new List<T> { obj };
            else
                Data = data?.ToList();

            if (Data == null)
                Data = new List<T>();

            if (messageHandler != null)
                Messages = new List<MessageHandler> { messageHandler };
            else
                Messages = new List<MessageHandler>();
            if (errorHandler != null)
                Errors = new List<ErrorHandler> { errorHandler };
            else
                Errors = new List<ErrorHandler>();

            Count =  DataCount;
        }
        public List<T> Data { get; set; }
        public List<ErrorHandler> Errors  { get; set; }
        public List<MessageHandler> Messages  { get; set; }
        public string EmissionDate { get; set; } = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccessStatusCode { get; set; }
        public int? DataCount { get=> Data?.Count; }
        public int? Count { get; set; }

        #region Bad Request
        public static BadRequestObjectResult BadRequest(T obj, string statusError, string message, string stackTrace = null, string description = null)
        {
            ResponseHandler<T> response = new(obj, null, null,
                new ErrorHandler(statusError, message, stackTrace, description));
            return new BadRequestObjectResult(response);
        }
        public static BadRequestObjectResult BadRequest(IEnumerable<T> data, string statusError, string message, string stackTrace = null, string description = null)
        {
            ResponseHandler<T> response = new(null, data, null,
                new ErrorHandler(statusError, message, stackTrace, description));
            return new BadRequestObjectResult(response);
        }
        public static BadRequestObjectResult BadRequest(string statusError, string message, string stackTrace = null, string description = null)
        {
            ResponseHandler<T> response = new(null, null, null,
                new ErrorHandler(statusError, message, stackTrace, description));
            return new BadRequestObjectResult(response);
        }
        #endregion

        #region Unauthorized
        public static UnauthorizedObjectResult Unauthorized(string statusError, string message, string stackTrace = null, string description = null)
        {
            ResponseHandler<T> response = new(null, null, null,
                new ErrorHandler(statusError, message, stackTrace, description));
            response.StatusCode = HttpStatusCode.Unauthorized;
            response.IsSuccessStatusCode = false;
            return new UnauthorizedObjectResult(response);
        }

        public static UnauthorizedObjectResult Unauthorized()
        {
            ResponseHandler<T> response = new(null, null, null,
                new ErrorHandler());
            response.StatusCode = HttpStatusCode.Unauthorized;
            response.IsSuccessStatusCode = false;
            return new UnauthorizedObjectResult(response);
        }
        #endregion

        #region Ok
        public static OkObjectResult Ok()
        {
            ResponseHandler<T> response = new(null, null,
                new MessageHandler("OK", null, null));
            response.StatusCode = HttpStatusCode.OK;
            response.IsSuccessStatusCode = true;
            return new OkObjectResult(response);
        }
        public static OkObjectResult Ok(T obj, string statusMessage = "OK", string message = null, string description = null)
        {
            ResponseHandler<T> response = new(obj, null,
                new MessageHandler(statusMessage, message, description));
            response.StatusCode = HttpStatusCode.OK;
            response.IsSuccessStatusCode = true;
            return new OkObjectResult(response);
        }
        public static OkObjectResult Ok(IEnumerable<T> data = null, string statusMessage = "OK", string message = null, string description = null)
        {
            ResponseHandler<T> response = new(null, data,
                new MessageHandler(statusMessage, message, description));
            response.StatusCode = HttpStatusCode.OK;
            response.IsSuccessStatusCode = true;
            return new OkObjectResult(response);
        }
        public static OkObjectResult Ok(string statusMessage = "OK", string message = null, string description = null)
        {
            ResponseHandler<T> response = new(null, null,
                new MessageHandler(statusMessage, message, description));
            response.StatusCode = HttpStatusCode.OK;
            response.IsSuccessStatusCode = true;
            return new OkObjectResult(response);
        }
        #endregion

        #region Not Found
        public static NotFoundObjectResult NotFound(T obj = null, string statusError = "No Encontrado", string message = null, string stackTrace = null, string description = null)
        {
            ResponseHandler<T> response = new(obj, null, null,
                new ErrorHandler(statusError, message, stackTrace, description));
            response.StatusCode = HttpStatusCode.NotFound;
            response.IsSuccessStatusCode = false;
            return new NotFoundObjectResult(response);
        }
        public static NotFoundObjectResult NotFound(IEnumerable<T> data = null, string statusError = "No Encontrado", string message = null, string stackTrace = null, string description = null)
        {
            ResponseHandler<T> response = new(null, data, null,
                new ErrorHandler(statusError, message, stackTrace, description));
            response.StatusCode = HttpStatusCode.NotFound;
            response.IsSuccessStatusCode = false;
            return new NotFoundObjectResult(response);
        }
        public static NotFoundObjectResult NotFound(string statusError = "No Encontrado", string message = null, string stackTrace = null, string description = null)
        {
            ResponseHandler<T> response = new(null, null, null,
                new ErrorHandler(statusError, message, stackTrace, description));
            response.StatusCode = HttpStatusCode.NotFound;
            response.IsSuccessStatusCode = false;
            return new NotFoundObjectResult(response);
        }
        #endregion

        #region Unprocessable Entity
        public static UnprocessableEntityObjectResult UnprocessableEntity(T obj = null, string statusError = "No Encontrado", string message = null, string stackTrace = null, string description = null)
        {
            ResponseHandler<T> response = new(obj, null, null,
                new ErrorHandler(statusError, message, stackTrace, description));
            response.StatusCode = HttpStatusCode.UnprocessableEntity;
            response.IsSuccessStatusCode = false;
            return new UnprocessableEntityObjectResult(response);
        }
        public static UnprocessableEntityObjectResult UnprocessableEntity(IEnumerable<T> data = null, string statusError = "No Encontrado", string message = null, string stackTrace = null, string description = null)
        {
            ResponseHandler<T> response = new(null, data, null,
                new ErrorHandler(statusError, message, stackTrace, description));
            response.StatusCode = HttpStatusCode.UnprocessableEntity;
            response.IsSuccessStatusCode = false;
            return new UnprocessableEntityObjectResult(response);
        }
        public static UnprocessableEntityObjectResult UnprocessableEntity(string statusError = "No Encontrado", string message = null, string stackTrace = null, string description = null)
        {
            ResponseHandler<T> response = new(null, null, null,
                new ErrorHandler(statusError, message, stackTrace, description));
            response.StatusCode = HttpStatusCode.UnprocessableEntity;
            response.IsSuccessStatusCode = false;
            return new UnprocessableEntityObjectResult(response);
        }
        #endregion

        #region No Content
        public static NoContentResult NoContent()
        {
            return new NoContentResult();
        }

        #endregion

        #region Internal Server Error

        public static InternalServerErrorObjectResult InternalServerError(string statusError = "Internal Server Error", string message = null, string stackTrace = null, string description = null)
        {
            ResponseHandler<T> response = new(null, null, null,
                new ErrorHandler(statusError, message, stackTrace, description));
            return new InternalServerErrorObjectResult(response);
        }

        #endregion
    }
    public class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object obj) : base(obj)
        {
            this.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
