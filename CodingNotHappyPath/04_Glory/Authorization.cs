using System;

namespace _04_Glory
{
    public class Authority
    {
        public Result<TEntity> IsAuthorized<TRequirement, TEntity>(TRequirement requirement, TEntity entity)
        {
            if (entity is Order && requirement is Read)
            {
                return Result.Success(entity);
            }

            return Result.Failure<TEntity>(new Unauthorized());
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