using GerenciamentoLivro.Data.Repository;
using GerenciamentoLivro.Domain.Interfaces;
using GerenciamentoLivro.Domain.Notifications;
using GerenciamentoLivro.Domain.Services;

namespace GerenciamentoLivro.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder ResolveDependencies(this WebApplicationBuilder builder)
        {
            #region Injeção Data

            builder.Services.AddScoped<ILivroRepository, LivroRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            #endregion

            #region Injeção Domain

            builder.Services.AddScoped<ILivroService, LivroService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<INotificador, Notificador>();

            #endregion

            return builder;
        }
    }
}
