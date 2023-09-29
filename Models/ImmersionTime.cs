using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Timers;

namespace Mayuri.Models
{
    public class ImmersionTime
    {
        private readonly Timer _timer;
        private DateTime _startTime;
        private bool _isRunning;

        public TimeSpan ElapsedTime => _isRunning ? DateTime.Now - _startTime : TimeSpan.Zero;
        public event Action<TimeSpan>? ElapsedTimeChanged;

        public ImmersionTime()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += TimerElapsed;
            _isRunning = false;
        }

        public void StartWatch()
        {
            OnElapsedTimeChanged();
            _timer.Start();
            _startTime = DateTime.Now;
            _isRunning = true;
        }

        public void StopWatch()
        {
            _timer.Stop();
            _isRunning = false;
        }
        public bool IsRunning()
        {
            return _isRunning;
        }

        private void TimerElapsed(object? sender, ElapsedEventArgs e)
        {
            OnElapsedTimeChanged();
        }

        private void OnElapsedTimeChanged()
        {
            ElapsedTimeChanged?.Invoke(ElapsedTime);
        }

    }
}
