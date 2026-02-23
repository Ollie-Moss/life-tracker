using System.Linq.Expressions;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper;
using DataAccessLayer;

namespace BusinessLayer
{
    public class QueryBuilderConverter<TSource, TDestination> :
        ITypeConverter<QueryBuilder<TSource>, QueryBuilder<TDestination>>
        where TSource : class
        where TDestination : class
    {
        public QueryBuilder<TDestination> Convert(
            QueryBuilder<TSource> source,
            QueryBuilder<TDestination> destination,
            ResolutionContext context)
        {
            destination.Filters = context.Mapper.Map<List<Expression<Func<TDestination, bool>>>>(source.Filters);
            return destination;
        }
    }
}
