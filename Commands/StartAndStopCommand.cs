using ImmersionTrack.Models;
using ImmersionTrack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;

namespace ImmersionTrack.Commands
{
    public class StartAndStopCommand : CommandBase
    {
        private readonly ImmersionTime _stopWatch;
        private readonly ImmersionTimeViewModel _viewModel;
        public StartAndStopCommand(ImmersionTimeViewModel vm, ImmersionTime immersionTime)
        {
            _stopWatch = immersionTime;
            _viewModel = vm;
        }
        public override void Execute(object? parameter)
        {
            if (_stopWatch.IsRunning()) {
                _stopWatch.StopWatch();
            }
            else
            {
                _stopWatch.StartWatch();
            }
        }
    }
}
