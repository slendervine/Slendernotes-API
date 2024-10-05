namespace Slendernotes.API.Results
{
    public class ResultRepository
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static ResultRepository Fail(string message) => new ResultRepository { IsSuccess = false, Message = message };
        public static ResultRepository<T> Fail<T>(string message) => new ResultRepository<T> { IsSuccess = false, Message = message };

        public static ResultRepository InsertFailure(string message = ResultErrors.InsertFailure) => new ResultRepository { IsSuccess = false, Message = message };
        public static ResultRepository<T> InsertFailure<T>(string message = ResultErrors.InsertFailure) => new ResultRepository<T> { IsSuccess = false, Message = message };

        public static ResultRepository UpdateFailure(string message = ResultErrors.UpdateFailure) => new ResultRepository { IsSuccess = false, Message = message };
        public static ResultRepository<T> UpdateFailure<T>(string message = ResultErrors.UpdateFailure) => new ResultRepository<T> { IsSuccess = false, Message = message };

        public static ResultRepository DeleteFailure(string message = ResultErrors.DeleteFailure) => new ResultRepository { IsSuccess = false, Message = message };
        public static ResultRepository<T> DeleteFailure<T>(string message = ResultErrors.DeleteFailure) => new ResultRepository<T> { IsSuccess = false, Message = message };

        public static ResultRepository NotFound(string message = ResultErrors.NotFound) => new ResultRepository { IsSuccess = false, Message = message };
        public static ResultRepository<T> NotFound<T>(string message = ResultErrors.NotFound) => new ResultRepository<T> { IsSuccess = false, Message = message };

        public static ResultRepository Ok(string message) => new ResultRepository { IsSuccess = true, Message = message };
        public static ResultRepository<T> Ok<T>(T data) => new ResultRepository<T> { IsSuccess = true, Data = data };
    }

    public class ResultRepository<T> : ResultRepository
    {
        public T Data { get; set; }
    }

}
