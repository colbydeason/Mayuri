using Mayuri.Commands;
using Mayuri.Services;
using Mayuri.Stores;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Mayuri.ViewModels
{
    public class ImmersionTimeViewModel : ViewModelBase
    {
        private IImmersionTimeService _immersionTime;

        public string ElapsedTimeString { get; set; }
        public ICommand StartAndStopCommand { get; }
        public ICommand NavigateCommand { get; }
        public ICommand ResetTimeCommand { get; }
        private bool _toggleStyle = false;
        public bool ToggleStyle
        {
            get
            {
                return _toggleStyle;
            }
            set
            {
                _toggleStyle = value;
                OnElapsedTimeChanged(_immersionTime.ElapsedTime());
            }
        }
        
        public ImmersionTimeViewModel(NavigationStore navigationStore)
        {
            _immersionTime = App.Current.Services.GetService<IImmersionTimeService>();
            StartAndStopCommand = new StartAndStopCommand(this, _immersionTime);
            ResetTimeCommand = new ResetTimeCommand(_immersionTime);
            NavigateCommand = new NavigateCommand<MenuViewModel>(navigationStore, () => new MenuViewModel(navigationStore));
            _immersionTime.ElapsedTimeChanged += OnElapsedTimeChanged;
            OnElapsedTimeChanged(_immersionTime.ElapsedTime());
        }

        private void OnElapsedTimeChanged(TimeSpan timeSpan)
        {
            if (ToggleStyle == false)
            {
                ElapsedTimeString = timeSpan.ToString(@"hh\:mm\:ss");
            }
            else
            {
                ElapsedTimeString = timeSpan.ToString(@"h'h 'm'm 's's'");
            }
            OnPropertyChanged(nameof(ElapsedTimeString));
        }
    }
}
