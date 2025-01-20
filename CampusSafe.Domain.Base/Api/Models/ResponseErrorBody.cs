namespace CampusSafe.Domain.Base.Api.Models;

public class ResponseErrorBody
    {
        public int StatusCode { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Detail { get; set; } = string.Empty;
        public IEnumerable<string>? Errors { get; set; }

        public static ResponseErrorBody NoContent(string detail, IEnumerable<Notification>? notifications = null)
        {
            return new ResponseErrorBody
            {
                StatusCode = Constants.StatusCodes.NO_CONTENT,
                Title = Constants.ResponseMessages.NO_CONTENT,
                Type = Constants.StatusCodesTypesReferences.NO_CONTENT,
                Detail = detail,
                Errors = notifications?.Select(n => n.Message)
            };
        }

        public static ResponseErrorBody BadRequest(string detail, IEnumerable<Notification>? notifications = null)
        {
            return new ResponseErrorBody
            {
                StatusCode = Constants.StatusCodes.BAD_REQUEST,
                Title = Constants.ResponseMessages.BAD_REQUEST,
                Type = Constants.StatusCodesTypesReferences.BAD_REQUEST,
                Detail = detail,
                Errors = notifications?.Select(n => n.Message)
            };
        }

        public static ResponseErrorBody Unauthorized(string detail, IEnumerable<Notification>? notifications = null)
        {
            return new ResponseErrorBody
            {
                StatusCode = Constants.StatusCodes.UNAUTHORIZED,
                Title = Constants.ResponseMessages.UNAUTHORIZED,
                Type = Constants.StatusCodesTypesReferences.UNAUTHORIZED,
                Detail = detail,
                Errors = notifications?.Select(n => n.Message)
            };
        }

        public static ResponseErrorBody Forbidden(string detail, IEnumerable<Notification>? notifications = null)
        {
            return new ResponseErrorBody
            {
                StatusCode = Constants.StatusCodes.FORBIDDEN,
                Title = Constants.ResponseMessages.FORBIDDEN,
                Type = Constants.StatusCodesTypesReferences.FORBIDDEN,
                Detail = detail,
                Errors = notifications?.Select(n => n.Message)
            };
        }

        public static ResponseErrorBody NotFound(string detail, IEnumerable<Notification>? notifications = null)
        {
            return new ResponseErrorBody
            {
                StatusCode = Constants.StatusCodes.NOT_FOUND,
                Title = Constants.ResponseMessages.NOT_FOUND,
                Type = Constants.StatusCodesTypesReferences.NOT_FOUND,
                Detail = detail,
                Errors = notifications?.Select(n => n.Message)
            };
        }

        public static ResponseErrorBody ServerError(string detail, IEnumerable<Notification>? notifications = null)
        {
            return new ResponseErrorBody
            {
                StatusCode = Constants.StatusCodes.SERVER_ERROR,
                Title = Constants.ResponseMessages.SERVER_ERROR,
                Type = Constants.StatusCodesTypesReferences.SERVER_ERROR,
                Detail = detail,
                Errors = notifications?.Select(n => n.Message)
            };
        }
    }