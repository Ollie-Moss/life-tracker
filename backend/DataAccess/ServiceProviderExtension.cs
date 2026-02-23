using DataAccessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceProviderExtension
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection container)
    {
        container.AddScoped<IUnitOfWork<ApplicationContext>, ApplicationUnitOfWork>();

        container.AddScoped<IRepository<Note>, NoteRepository>();
        container.AddScoped<IRepository<Group>, GroupRepository>();

        container.AddScoped<IRepository<Transaction>, TransactionRepository>();
        container.AddScoped<IRepository<RecurringTransaction>, RecurringTransactionRepository>();

        container.AddScoped<IRepository<CalendarTask>, CalendarTaskRepository>();
        container.AddScoped<IRepository<User>, UserRepository>();
        return container;
    }

    public static IServiceCollection RegisterApplicationContext(this IServiceCollection container, string connectionString)
    {
        container.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));

        return container;
    }
}
