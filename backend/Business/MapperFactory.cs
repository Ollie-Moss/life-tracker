using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /// <summary>
    /// Factory for creating <see cref="Mapper"/>.
    /// </summary>
    public class MapperFactory
    {
        /// <summary>
        /// Creates a new mapper.
        /// </summary>
        /// <typeparam name="T">Mapping Profile to be used.</typeparam>
        /// <returns>The mapper.</returns>
        public static Mapper CreateMapper<T>() where T : Profile, new()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<T>();
            }, null);
            return new Mapper(config);
        }
    }
}
