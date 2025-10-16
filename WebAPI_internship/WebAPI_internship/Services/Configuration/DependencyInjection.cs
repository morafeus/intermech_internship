using WebAPI_internship.Services.Interfaces;

namespace WebAPI_internship.Services.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<INodeExecutorService, NodeExecutorService>();
            services.AddTransient<IPluginRegisterService, PluginRegisterService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddSingleton<ITokenService, TokenService>();
            services.AddTransient<INodeGraphService, NodeGraphService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
