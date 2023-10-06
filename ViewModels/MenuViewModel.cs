using Mayuri.Commands;
using Mayuri.Services;
using Mayuri.Stores;
using Mayuri.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mayuri.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public ICommand NavigateStopwatchCommand { get; }
        public ICommand OpenAddSourceView { get; }
        public MenuViewModel(NavigationStore navigationStore)
        {
            NavigateStopwatchCommand = new NavigateCommand<ImmersionTimeViewModel>(navigationStore, () => new ImmersionTimeViewModel(navigationStore));
            OpenAddSourceView = new OpenViewCommand<AddSourceViewModel>(navigationStore, () => new AddSourceViewModel());
        }
    }
}
