using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        //here expres is a Func take type & return the bool value
        Expression<Func<T, bool>> Criteria {get;}

        //this function take type & return the object
        //use for EF, Include syntax
        List<Expression<Func<T,object>>> Includes {get;}
    }
}