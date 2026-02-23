
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public class QueryBuilder<TEntity> where TEntity : class
    {
        private List<Expression<Func<TEntity, bool>>> _filters = new();

        public List<Expression<Func<TEntity, bool>>> Filters { get => _filters; set => _filters = value; }

        public QueryBuilder<TEntity> Add(Expression<Func<TEntity, bool>> filter)
        {
            _filters.Add(filter);
            return this;
        }

        public IQueryable<TEntity> Run(IQueryable<TEntity> entities)
        {
            foreach (var filter in _filters)
            {
                entities = entities.Where(filter);
            }

            return entities;
        }

    }
}
