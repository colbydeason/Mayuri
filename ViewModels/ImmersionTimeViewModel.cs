using Mayuri.Commands;
using Mayuri.Models;
using Mayuri.Stores;
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
        private ImmersionTime _immersionTime;

        public string ElapsedTimeString { get; set; }
        public ICommand StartAndStopCommand { get; }
        public ICommand NavigateCommand { get; }
        public ICommand ResetTimeCommand { get; }
        //Impliment StyleChanged event here, then subscribe somewhere
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
                OnElapsedTimeChanged(_immersionTime.ElapsedTime);
            }
        }
        
        public ImmersionTimeViewModel(NavigationStore navigationStore,ImmersionTime immersionTime)
        {
            _immersionTime = immersionTime;
            StartAndStopCommand = new StartAndStopCommand(this, immersionTime);
            ResetTimeCommand = new ResetTimeCommand(immersionTime);
            NavigateCommand = new NavigateCommand<MenuViewModel>(navigationStore, () => new MenuViewModel(navigationStore, immersionTime));
            _immersionTime.ElapsedTimeChanged += OnElapsedTimeChanged;
            OnElapsedTimeChanged(immersionTime.ElapsedTime);
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
