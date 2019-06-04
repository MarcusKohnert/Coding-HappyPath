namespace _01_HappyPath
{
    public class Authority
    {
        public bool IsAuthorized<TRequirement, TEntity>(TRequirement requirement, TEntity entity)
        {
            return entity is Order && requirement is Read;
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
}