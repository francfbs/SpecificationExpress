namespace SpecificationExpress
{
    public class Rule<T>
    {
        public Rule(ISpecification<T> specification, string errorMessage)
        {
            Specification = specification;
            ErrorMessage = errorMessage;
        }

        public ISpecification<T> Specification { get; }
        public string ErrorMessage { get; }
    }
}