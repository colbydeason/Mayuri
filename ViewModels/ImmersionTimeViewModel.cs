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

        public string ElapsedTimeString { get; set; } = "Time to immerse!";
        public ICommand StartAndStopCommand { get; }
        public ICommand NavigateCommand { get; }
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
            }
        }
        
        public ImmersionTimeViewModel(NavigationStore navigationStore,ImmersionTime immersionTime)
        {
            _immersionTime = immersionTime;
            StartAndStopCommand = new StartAndStopCommand(this, immersionTime);
            NavigateCommand = new NavigateCommand<MenuViewModel>(navigationStore, () => new MenuViewModel(navigationStore, immersionTime));
            _immersionTime.ElapsedTimeChanged += OnElapsedTimeChanged;
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
