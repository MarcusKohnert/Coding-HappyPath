using System;

namespace _04_Glory
{
    public static class ResultExtensions
    {
        //public static Result<TResult> SelectMany<T, T2, TResult>
        //(
        //    this Result<T> a,
        //    Func<T, Result<T2>> func,
        //    Func<T, T2, TResult> select
        //)
        //{
            
        //}

        //public static Result<TResult> SelectMany<T, T2, TResult>
        //(
        //    this Result<T> a, 
        //    Func<T, Result<T2>> func, 
        //    Func<T, T2, TResult> select
        //)
        //{
        //    if (a.Failed) return Result.Failure<TResult>(a.Message);

        //    var r1 = func(a.Value);
        //    if (r1.Failed) return Result.Failure<TResult>(r1.Message);

        //    var r2 = select(a.Value, r1.Value);

        //    return Result.Success(r2);
        //}
    }
}