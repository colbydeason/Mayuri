using Mayuri.Models;
using Mayuri.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayuri.Commands
{
    public class CreateLogCommand : CommandBase
    {
        private readonly CreateLogViewModel vm;
        private readonly ILogList lg;
        // Add event so everything on menu can subscribe to it
        public CreateLogCommand(CreateLogViewModel createLogViewModel, ILogList logs)
        {
            vm = createLogViewModel;
            lg = logs;
            vm.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object? parameter)
        {
            Log newLog;
            newLog = new Log(vm.LogDurationInt, vm.LogSourceId);
            lg.CreateLog(newLog);
            vm.LogDurationInt = 0;
            vm.LogDuration = "0";
        }
        public override bool CanExecute(object? parameter)
        {
            return (vm.LogDurationInt != 0) && 
                (vm.LogSourceId != Guid.Empty) &&
                base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
