using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.RepoConfig
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            //ordering comes after criteria filter
            if (spec.OrderBy != null)
            {
              
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }
            //paging needs to come after all other filters
            if (spec.isPagingEnabled) {
                query = query.Skip(spec.Skip).Take(spec.Take); 
            }
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }

        
    }
}