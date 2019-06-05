using System;

namespace _04_Glory
{
    public static class ResultExtensions
    {
        public static Result<TResult> Select<T, TResult>
        (
            this Result<T> source,
            Func<T, TResult> func
        )
        {
            if (source.Failed) return Result.Failure<TResult>(source.Message);

            var result = func(source.Value);

            return Result.Success(result);
        }

        public static Result<TResult> Bind<T, TResult>
        (
            this Result<T> a, 
            Func<T, Result<TResult>> func
        )
        {
            if (a.Failed) return Result.Failure<TResult>(a.Message);

            return func(a.Value);
        }

        public static Result<TResult> SelectMany<T, T2, TResult>
        (
            this Result<T> a, 
            Func<T, Result<T2>> func, 
            Func<T, T2, TResult> select
        )
        {
            if (a.Failed) return Result.Failure<TResult>(a.Message);

            var result = func(a.Value);

            if (result.Failed) return Result.Failure<TResult>(result.Message);

            return select(a.Value, result.Value).ToSuccess();
        }

        public static Result<T> ToSuccess<T>(this T value)
        {
            return Result.Success(value);
        }
    }
}
