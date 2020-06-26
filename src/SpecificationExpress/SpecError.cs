namespace SpecificationExpress
{
    public class SpecError
    {
        public SpecError(string entityName, string errorMessage)
        {
            EntityName = entityName;
            ErrorMessage = errorMessage;
        }

        public string EntityName { get; }
        public string ErrorMessage { get; }
    }
}