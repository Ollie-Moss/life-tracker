using System.Linq.Expressions;
using AutoMapper;
using DataAccessLayer;
using Models;

namespace BusinessLayer
{
    /// <summary>
    /// AutoMapper profile for all mapping cases.
    /// </summary>
	public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            // Data to Model
            CreateMap<DataAccessLayer.Models.Group, Group>();
            CreateMap<DataAccessLayer.Models.Note, Note>();

            CreateMap<DataAccessLayer.Models.Transaction, Transaction>();
            CreateMap<DataAccessLayer.Models.RecurringTransaction, RecurringTransaction>();

            CreateMap<DataAccessLayer.Models.CalendarTask, CalendarTask>();
            CreateMap<DataAccessLayer.Models.User, User>();

            // Model to Data
            CreateMap<Group, DataAccessLayer.Models.Group>();
            CreateMap<Note, DataAccessLayer.Models.Note>();

            CreateMap<Transaction, DataAccessLayer.Models.Transaction>();
            CreateMap<RecurringTransaction, DataAccessLayer.Models.RecurringTransaction>();

            CreateMap<CalendarTask, DataAccessLayer.Models.CalendarTask>();
            CreateMap<User, DataAccessLayer.Models.User>();

            // Data to Model
            CreateMap(typeof(QueryBuilder<>), typeof(QueryBuilder<>)).ConvertUsing(typeof(QueryBuilderConverter<,>));
        }
    }
}
