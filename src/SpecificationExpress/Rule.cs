namespace SpecificationExpress
{
    public class Rule<T>
    {
        public Rule(ISpecification<T> specification, string errorMessage)
        {
            Specification = specification;
            ErrorMessage = errorMessage;
        }
        
        public Rule(ISpecificationAsync<T> specification, string errorMessage)
        {
            SpecificationAsync = specification;
            ErrorMessage = errorMessage;
        }

        public ISpecification<T> Specification { get; }
        public ISpecificationAsync<T> SpecificationAsync { get; }
        public string ErrorMessage { get; }
    }
}