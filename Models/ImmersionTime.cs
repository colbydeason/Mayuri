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
        private bool _isReset = true;
        private TimeSpan _totalTime = TimeSpan.Zero;
        private TimeSpan _currTimerTime => _isRunning ? DateTime.Now - _startTime : TimeSpan.Zero;
        public TimeSpan ElapsedTime => _currTimerTime + _totalTime;
        public event Action<TimeSpan>? ElapsedTimeChanged;

        public ImmersionTime()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += TimerElapsed;
            _isRunning = false;
        }

        public void StartWatch()
        {
            _timer.Start();
            _startTime = DateTime.Now;
            OnElapsedTimeChanged();
            _isRunning = true;
        }

        public void StopWatch()
        {
            _totalTime += _currTimerTime;
            _timer.Stop();
            _isRunning = false;
        }

        public void Reset()
        {
            _totalTime = TimeSpan.Zero;
            _startTime = DateTime.Now;
            OnElapsedTimeChanged();
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
