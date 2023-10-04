using Mayuri.Services;
using Mayuri.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayuri.Commands
{
    public class ResetTimeCommand : CommandBase
    {
        private readonly IImmersionTimeService _immersionTime;
        public ResetTimeCommand(IImmersionTimeService immersionTime)
        {
            _immersionTime = immersionTime;
        }
        public override void Execute(object? parameter)
        {
            _immersionTime.Reset();
        }
    }
}
