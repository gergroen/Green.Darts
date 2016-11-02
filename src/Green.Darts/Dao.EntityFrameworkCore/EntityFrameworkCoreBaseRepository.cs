namespace Green.Darts.Dao.EntityFrameworkCore
{
    public abstract class EntityFrameworkCoreBaseRepository
    {
        protected DartsDbContext Context;

        public EntityFrameworkCoreBaseRepository(DartsDbContext context)
        {
            Context = context;
        }
    }
}