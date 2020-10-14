using System.Threading.Tasks;

namespace SpecificationExpress
{
    public interface ISpecificationAsync<in T>
    { 
        Task<bool> IsSatisfiedBy(T obj);
    }
}