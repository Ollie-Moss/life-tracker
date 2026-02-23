using Microsoft.Extensions.DependencyInjection;
using BusinessLayer;
using BusinessLayer.Services;
using Models;
using AutoMapper.Extensions.ExpressionMapping;

public static class ServiceProviderExtension
{
    public static IServiceCollection RegisterServices(this IServiceCollection container)
    {
        container.AddScoped<IService<Note>, NoteService>();
        container.AddScoped<IService<Group>, GroupService>();

        container.AddScoped<IService<Transaction>, TransactionService>();
        container.AddScoped<IService<RecurringTransaction>, RecurringTransactionService>();

        container.AddScoped<IService<CalendarTask>, CalendarTaskService>();
        container.AddScoped<IService<User>, UserService>();

        return container;
    }

    public static IServiceCollection AddAutoMapperProfile(this IServiceCollection container)
    {

        container.AddAutoMapper(cfg =>
        {
            cfg.AddExpressionMapping();
        }, typeof(ApplicationMappingProfile));

        return container;
    }

}
