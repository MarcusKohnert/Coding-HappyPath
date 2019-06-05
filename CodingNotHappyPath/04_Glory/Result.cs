using System;

namespace _04_Glory
{
    public class Result
    {
        private static readonly Exception emptyException = new Exception();
        private static readonly Result success           = new Result(true, emptyException);

        public Result(bool succeeded, Exception message)
        {
            this.Succeeded = succeeded;
            this.Message   = message;
        }

        public bool Succeeded { get; }

        public bool Failed => !this.Succeeded;

        public Exception Message { get; set; }

        public static Result Success() => success;

        public static Result Failure(Exception message) => new Result(false, message);

        public static Result<TResult> Success<TResult>(TResult result) => new Result<TResult>(true, result, emptyException);

        public static Result<TResult> Failure<TResult>(Exception message) => new Result<TResult>(false, default(TResult), message);
    }

    public class Result<T> : Result
    {
        public Result(bool succeeded, T result, Exception message)
            : base(succeeded, message)
        {
            this.Value = result;
        }

        public T Value { get; }
    }
}