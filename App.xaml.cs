using Mayuri.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Mayuri.ViewModels;
using Mayuri.Stores;

namespace Mayuri
{
    public partial class App : Application
    {
        private readonly ImmersionTime _immersionTime;
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new NavigationStore();
            navigationStore.CurrentViewModel = new MenuViewModel(navigationStore, _immersionTime);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        public App()
        {
            _immersionTime = new ImmersionTime();
        }
    }
}
