using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationExpress
{
    public abstract class Validator<T> where T : class
    {
        private List<Rule<T>> Rules { get; }
        private List<SpecificationError> Errors { get; }

        protected Validator()
        {
            Rules = new List<Rule<T>>();
            Errors = new List<SpecificationError>();
        }

        protected void Add(Rule<T> rule)
        {
            Rules.Add(rule);
        }
        
        public List<SpecificationError> Validate(T obj)
        {
            foreach (var rule in Rules.Where(rule => !rule.Specification.IsSatisfiedBy(obj)))
            {
                Errors.Add(new SpecificationError(obj.GetType().Name, rule.ErrorMessage));
            }
            return Errors;
        }
        
        public async Task<List<SpecificationError>> ValidateAsync(T obj)
        {
            foreach (var rule in Rules)
            {
                if(!await rule.SpecificationAsync.IsSatisfiedBy(obj))
                    Errors.Add(new SpecificationError(obj.GetType().Name, rule.ErrorMessage));
            }
            return await Task.FromResult(Errors);
        }
    }
}