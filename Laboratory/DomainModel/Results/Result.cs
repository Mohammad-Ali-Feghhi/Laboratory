using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Results
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public ErrorCode ErrorCode { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }

        private Result(bool isSuccess,
                       ErrorCode errorCode, 
                       string message, 
                       T data)
        {
            IsSuccess = isSuccess;
            ErrorCode = errorCode;
            Message = message;
            Data = data;
        }

        public static Result<T> Success(T data)
            => new Result<T>(true, ErrorCode.None, string.Empty, data);

        public static Result<T> Fail(ErrorCode errorCode, string message)
            => new Result<T>(false, errorCode, message, default);
    }
}
