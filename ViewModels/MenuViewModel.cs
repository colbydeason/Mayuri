using Mayuri.Commands;
using Mayuri.Models;
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
        public ICommand NavigateCommand { get; }
        public MenuViewModel(NavigationStore navigationStore, ImmersionTime immersionTime)
        {
            NavigateCommand = new NavigateCommand<ImmersionTimeViewModel>(navigationStore, () => new ImmersionTimeViewModel(navigationStore, immersionTime));
        }
    }
}
