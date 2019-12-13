using Beblue.DataVo.Converters;
using Beblue.Repositories.Interfaces;
using Beblue.Repositories.Repositories;
using Beblue.Services.Interfaces;
using Beblue.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Beblue.Ioc
{
    /// <summary>
    /// Classe de inversão de controle e injeção de dependência
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Adiciona a injeção de dependência entre os repositorios e suas interfaces.
        /// </summary>
        /// <param name="services"></param>
        public static void InjecaoDependenciaServicos(ref IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IPedidoItemService, PedidoItemService>();
            services.AddScoped<IDiscoService, DiscoService>();
            services.AddScoped<IGeneroService, GeneroService>();
            services.AddScoped<ISpotifyService, SpotifyService>();
            services.AddScoped<ICashbackGeneroService, CashbackGeneroService>();
        }

        /// <summary>
        /// Adiciona a injeção de dependência entre os serviços e suas interfaces.
        /// </summary>
        /// <param name="services"></param>
        public static void InjecaoDependenciaRepositorios(ref IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoItemRepository, PedidoItemRepository>();
            services.AddScoped<IDiscoRepository, DiscoRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<ICashbackGeneroRepository, CashbackGeneroRepository>();
        }

        /// <summary>
        /// Adiciona a injeção de dependência entre os converters
        /// </summary>
        /// <param name="services"></param>
        public static void InjecaoDependenciaConverters(ref IServiceCollection services)
        {
            services.AddScoped<ClienteConverter, ClienteConverter>();
            services.AddScoped<PedidoConverter, PedidoConverter>();
            services.AddScoped<PedidoItemConverter, PedidoItemConverter>();
            services.AddScoped<DiscoConverter, DiscoConverter>();
            services.AddScoped<GeneroConverter, GeneroConverter>();
            services.AddScoped<CashbackGeneroConverter, CashbackGeneroConverter>();
        }
    }
}
