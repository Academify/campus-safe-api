namespace CampusSafe.Domain.Base;

public static class Constants
{
    public static class ResponseMessages
    {
        public static readonly string NO_CONTENT = "No content.";
        public static readonly string BAD_REQUEST = "Validation Error";
        public static readonly string NOT_FOUND = "The specified resource was not found";
        public static readonly string UNAUTHORIZED = "Unauthorized access";
        public static readonly string FORBIDDEN = "Forbidden access";
        public static readonly string SERVER_ERROR = "Server Error";
    }

    public static class StatusCodes
    {
        public static readonly int SUCCESS = 200;
        public static readonly int ACCEPTED = 202;
        public static readonly int NO_CONTENT = 204;
        public static readonly int BAD_REQUEST = 400;
        public static readonly int UNAUTHORIZED = 401;
        public static readonly int FORBIDDEN = 403;
        public static readonly int NOT_FOUND = 404;
        public static readonly int SERVER_ERROR = 500;
        public static readonly int NOT_IMPLEMENTED = 501;
    }

    public static class StatusCodesTypesReferences
    {
        public static readonly string NO_CONTENT = "https://httpstatuses.com/204";
        public static readonly string BAD_REQUEST = "https://httpstatuses.com/400";
        public static readonly string UNAUTHORIZED = "https://httpstatuses.com/401";
        public static readonly string FORBIDDEN = "https://httpstatuses.com/403";
        public static readonly string NOT_FOUND = "https://httpstatuses.com/404";
        public static readonly string SERVER_ERROR = "https://httpstatuses.com/500";
    }
}