using Mayuri.Stores;
using Mayuri.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mayuri.Commands
{
    public class OpenViewCommand<TViewModel> : CommandBase
        where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createNewViewModel;
        private bool _isOpen = false;
        public OpenViewCommand(NavigationStore navigationStore, Func<TViewModel> newViewModel)
        {
            _navigationStore = navigationStore;
            _createNewViewModel = newViewModel; 
            
        }
        public override void Execute(object? parameter)
        {
            _navigationStore.PopUpViewModel = _createNewViewModel(); 
            PopupWindow pop = new PopupWindow()
            {
                DataContext = _navigationStore
            };
            pop.Show();
            //pop.ShowDialog();
            _isOpen = true;
        }

        public override bool CanExecute(object? parameter)
        {
            return !_isOpen;
        }
    }
}
