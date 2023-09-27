using ImmersionTrack.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ImmersionTrack.ViewModels;

namespace ImmersionTrack
{
    public partial class App : Application
    {
        private readonly ImmersionTime _stopWatch;
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_stopWatch)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        public App()
        {
            _stopWatch = new ImmersionTime();
        }
    }
}
