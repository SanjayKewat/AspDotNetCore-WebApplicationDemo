using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
        ISpecification<TEntity> specification 
        )
        {
            var query = inputQuery;    
             if(specification.criteria != null{
                query = query.where(axa)
             })

             query  = specification.Includes.Aggregate(query,(current,include) => current.Include(include))
        }
    }
}   