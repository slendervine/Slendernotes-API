using Slendernotes.API.Common;

namespace Slendernotes.API.Results
{
    public class ResultApplication
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static ResultApplication Fail(string message) => new ResultApplication { IsSuccess = false, Message = message };
        public static ResultApplication<T> Fail<T>(string message) => new ResultApplication<T> { IsSuccess = false, Message = message };

        public static ResultApplication Ok(string message) => new ResultApplication { IsSuccess = true, Message = message };
        public static ResultApplication<T> Ok<T>(T data) => new ResultApplication<T> { IsSuccess = true, Data = data };
    }

    public class ResultApplication<T> : ResultApplication
    {
        public T Data { get; set; }
    }

}
