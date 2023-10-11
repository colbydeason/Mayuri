using Mayuri.Models;
using Mayuri.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayuri.Commands
{
    public class CreateLogCommand : CommandBase
    {
        private readonly CreateLogViewModel vm;
        private readonly ISourceList src;
        private readonly ILogList lg;
        public CreateLogCommand(CreateLogViewModel createLogViewModel, ISourceList sources, ILogList logs)
        {
            vm = createLogViewModel;
            src = sources;
            lg = logs;
        }

        public override void Execute(object? parameter)
        {
            lg.CreateLog(new Log(vm.LogDuration, vm.LogSourceId));
        }
    }
}
