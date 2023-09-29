using ImmersionTrack.Commands;
using ImmersionTrack.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ImmersionTrack.ViewModels
{
    public class ImmersionTimeViewModel : ViewModelBase
    {
        private ImmersionTime _stopWatch;

        //Previous Implimentation of ElapsedTimeString
        //
        //public string ElapsedTimeString => _stopWatch.ElapsedTime.ToString();

        public string ElapsedTimeString { get; set; } = "Time to immerse!";
        public ICommand StartAndStopCommand { get; }
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
        
        public ImmersionTimeViewModel(ImmersionTime stopWatch)
        {
            _stopWatch = stopWatch;
            StartAndStopCommand = new StartAndStopCommand(this, stopWatch);
            _stopWatch.ElapsedTimeChanged += StopWatchElapsedTimeChanged;
        }

        private void StopWatchElapsedTimeChanged(TimeSpan timeSpan)
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
