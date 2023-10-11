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
    public class CreateSourceCommand : CommandBase
    {
        private AddSourceViewModel _vm;
        private ISourceList _sources;
        public CreateSourceCommand(AddSourceViewModel viewModel, ISourceList sources)
        {
            _vm = viewModel;
            _sources = sources;
            _vm.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override void Execute(object? parameter)
        {
            Source newSource;
            if (_vm.SourceOneTime == true)
            {
                newSource = new Source(_vm.SourceName, _vm.SourceDescription, _vm.SourceType, true, true, 0);
            }
            else
            {
                newSource = new Source(_vm.SourceName, _vm.SourceDescription, _vm.SourceType, false, false, 0);
            }
            _sources.CreateSource(newSource);
            _vm.SourceName = String.Empty;
            _vm.SourceDescription = String.Empty;
            _vm.SourceOneTime = false;
        }
        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_vm.SourceName) &&
                !string.IsNullOrEmpty(_vm.SourceType) &&

                base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
