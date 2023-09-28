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
        public double ElapsedTime => _stopWatch.ElapsedTime;
        public string ElapsedTimeString => ElapsedTimeFormat(ElapsedTime);
        public ICommand StartAndStopCommand { get; }
        public ImmersionTimeViewModel(ImmersionTime stopWatch)
        {
            _stopWatch = stopWatch;
            StartAndStopCommand = new StartAndStopCommand(this, stopWatch);
            _stopWatch.ElapsedTimeChanged += StopWatchElapsedTimeChanged;
        }

        private void StopWatchElapsedTimeChanged()
        {
            OnPropertyChanged(nameof(ElapsedTime));
            OnPropertyChanged(nameof(ElapsedTimeString));
        }

        private string ElapsedTimeFormat(double elapsedTime)
        {
            int intElapse = (int)elapsedTime;
            int seconds;
            int minutes;
            int hours;
            hours = Math.DivRem(intElapse, 3600, out intElapse);
            minutes = Math.DivRem(intElapse, 60, out intElapse);
            seconds = intElapse;
            return $"{hours} hours, {minutes} minutes, {seconds} seconds";
        }
    }
}
