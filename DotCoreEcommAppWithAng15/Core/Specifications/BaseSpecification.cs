using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Core.Specifications
{
    
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        //here Expression is a (Expression) Func take type & return the bool value
        public Expression<Func<T, bool>> Criteria { get; }

        //this function take type & return the object
        //use for EF, Include syntax
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression){
            Includes.Add(includeExpression);
        }
    }
}