using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
            option => option.UseSqlServer(
                configuration.GetConnectionString("LocalToDoListConnection")
            ));

            #region Repositories
            services.AddTransient<ILista, ListaRepository>();
            services.AddTransient<IItem, ItemRepository>();
            #endregion
        }
    }
}
