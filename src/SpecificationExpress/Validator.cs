using System.Collections.Generic;
using System.Linq;

namespace SpecificationExpress
{
    public abstract class Validator<T> where T : class
    {
        private List<Rule<T>> Rules { get; }
        private List<SpecError> Errors { get; }

        protected Validator()
        {
            Rules = new List<Rule<T>>();
            Errors = new List<SpecError>();
        }

        protected void Add(Rule<T> rule)
        {
            Rules.Add(rule);
        }
        
        public List<SpecError> Validate(T obj)
        {
            foreach (var rule in Rules.Where(rule => !rule.Specification.IsSatisfiedBy(obj)))
            {
                Errors.Add(new SpecError(obj.GetType().Name, rule.ErrorMessage));
            }
            return Errors;
        }
    }
}