using Mayuri.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Mayuri.ViewModels;
using Mayuri.Stores;
using Microsoft.Extensions.DependencyInjection;
using Mayuri.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Mayuri
{
    public partial class App : Application
    {
        private const string CONNECTION = "Data Source=mayuri.db";
        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(CONNECTION).Options;
            using (MayuriDbContext dbContext = new MayuriDbContext(options))
            {
                dbContext.Database.Migrate();
            }

            NavigationStore navigationStore = new NavigationStore();
            navigationStore.CurrentViewModel = new MenuViewModel(navigationStore);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        public App()
        {
            Services = ConfigureServices();
        }

        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IImmersionTimeService, ImmersionTimeService>();
            services.AddSingleton<INavigationStore, NavigationStore>();

            return services.BuildServiceProvider();
        }
    }
}
