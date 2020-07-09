namespace SpecificationExpress
{
    public readonly struct SpecificationError
    {
        public SpecificationError(string entityName, string errorMessage)
        {
            EntityName = entityName;
            ErrorMessage = errorMessage;
        }

        public string EntityName { get; }
        public string ErrorMessage { get; }
    }
}