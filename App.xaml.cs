using Mayuri.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Mayuri.ViewModels;

namespace Mayuri
{
    public partial class App : Application
    {
        private readonly ImmersionTime _immersionTime;
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_immersionTime)
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
