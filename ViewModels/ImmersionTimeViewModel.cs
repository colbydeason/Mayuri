using ImmersionTrack.Commands;
using ImmersionTrack.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                ElapsedTimeString = timeSpan.ToString(@"h' hours, 'm' minutes, 's' seconds'");
            }
            else
            {
                ElapsedTimeString = timeSpan.ToString(@"hh\:mm\:ss");
            }
            OnPropertyChanged(nameof(ElapsedTimeString));
        }
    }
}
