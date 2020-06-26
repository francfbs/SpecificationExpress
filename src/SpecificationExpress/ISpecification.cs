namespace SpecificationExpress
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T obj);
    }
}