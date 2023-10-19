using Mayuri.DbContexts;
using Mayuri.DBContexts;
using Mayuri.Models;
using Mayuri.Services;
using Mayuri.Services.SourceCreators;
using Mayuri.Services.SourceProvider;
using Mayuri.Stores;
using Mayuri.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace Mayuri
{
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Data Source=mayuri.db";
        private readonly MayuriDbContextFactory _mayuriDbContextFactory;
        public App()
        {
            Services = ConfigureServices();
            _mayuriDbContextFactory = new MayuriDbContextFactory(CONNECTION_STRING);
            ISourceProvider sourceProvider = new DatabaseSourceProvider(_mayuriDbContextFactory);
            ISourceCreator sourceCreator = new DatabaseSourceCreator(_mayuriDbContextFactory);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            using (MayuriDbContext dbContext = _mayuriDbContextFactory.CreateDbContext())
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


        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IImmersionTimeService, ImmersionTimeService>();
            services.AddSingleton<INavigationStore, NavigationStore>();
            services.AddSingleton<ISourceList, SourceList>();
            services.AddSingleton<ILogList, LogList>();

            return services.BuildServiceProvider();
        }
    }
}
