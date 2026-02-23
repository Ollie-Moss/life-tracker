namespace DataAccessLayer.Repositories
{
    public interface IRepositoryBase<TEntity>
        where TEntity : class
    {
        public Type ModelType { get; set; }
        TEntity Add(TEntity instance);
        TEntity Delete(TEntity instance);
        IList<TEntity> List();
        IList<TEntity> Get(QueryBuilder<TEntity> query);
        void Update(TEntity instance);
    }

}
