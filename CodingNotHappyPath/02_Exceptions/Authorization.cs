using System;

namespace _02_Exceptions
{
    public class Authority
    {
        public void IsAuthorized<TRequirement, TEntity>(TRequirement requirement, TEntity entity)
        {
            if (entity is Order && requirement is Read) return;

            throw new UnauthorizedException();
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

    public class UnauthorizedException : Exception
    {

    }
}