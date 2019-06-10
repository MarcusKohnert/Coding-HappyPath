using System;

namespace _03_RoP
{
    public class Authority
    {
        public Result<TEntity> IsAuthorized<TRequirement, TEntity>(TRequirement requirement, TEntity entity)
        {
            return Result.Failure<TEntity>(new NotImplementedException());
        }
    }

    public abstract class Requirement
    {

    }

    public class Read : Requirement
    {
        public static Read Instance = new Read();
    }

    public class Write : Requirement
    {

    }

    public class Delete : Requirement
    {

    }

    public class Unauthorized : Exception
    {

    }
}