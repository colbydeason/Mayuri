using System;
using System.Timers;

namespace Mayuri.Services
{
    public interface IImmersionTimeService
    {
        public void StartWatch();
        public void StopWatch();
        public void Reset();
        public bool IsRunning();
        public TimeSpan ElapsedTime();
        public event Action<TimeSpan> ElapsedTimeChanged;
    }
    public class ImmersionTimeService : IImmersionTimeService
    {
        private readonly Timer _timer;
        private DateTime _startTime;
        private bool _isRunning;
        private TimeSpan _totalTime = TimeSpan.Zero;
        private TimeSpan _currTimerTime => _isRunning ? DateTime.Now - _startTime : TimeSpan.Zero;
        public event Action<TimeSpan>? ElapsedTimeChanged;

        public ImmersionTimeService()
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
            ElapsedTimeChanged?.Invoke(ElapsedTime());
        }
        public TimeSpan ElapsedTime()
        {
            return _currTimerTime + _totalTime;
        }

    }
}
