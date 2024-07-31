using Autofac;
using FriendOrganizer.DataAcess.Data;
using FriendOrganizer.UI.Service;
using FriendOrganizer.UI.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FriendOrganizer.UI.Startup
{
    /// <summary>
    /// Classe especializada em instanciar tipos conhecidos pelo container Autofac
    /// </summary>
    public class BootStrapper
    {
        public IContainer Bootstrap()
        {
            var container = new ContainerBuilder();
            
            container.RegisterType<MainWindow>().AsSelf();
            container.RegisterType<MainViewModel>().AsSelf();
            container.RegisterType<FriendDataService>().As<IFriendDataService>();
            
            container.Register(ctx =>
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();
                return config;
            }).As<IConfiguration>().SingleInstance();

            // Registrar ApplicationMainDbContext com a string de conexão
            //Foi necessário copiar o arquivo appsettings.json do projeto DataAccess para Ui (Ver arquivo de configuração do projeto)
            container.Register(ctx =>
            {
                var config = ctx.Resolve<IConfiguration>();
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationMainDbContext>();
                optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));
                return new ApplicationMainDbContext(optionsBuilder.Options);
            }).AsSelf(); //.InstancePerLifetimeScope()

            return container.Build();
        }
    }
}
