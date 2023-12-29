using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        //Generic code for include & exclude statements (loading table data)
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
        ISpecification<TEntity> specification
        )
        {
            var query = inputQuery;
            if (specification.Criteria != null)
            {
                 //here "specification.Criteria" use lambda expression & it work like this, p => p.ProductTypeId == id
                query = query.Where(specification.Criteria);
            }

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}