using DOMAIN.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APPLICATION.Persistence.Specifications
{
    public class SpecificationEvaluator<T> where T : ModelBase
    {
        public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> specification)
        {
            if(specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query; 
        }
    }
}
