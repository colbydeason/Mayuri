using Mayuri.ViewModels;
using System;

namespace Mayuri.Stores
{
    public interface INavigationStore
    {
        public event Action? CurrentViewModelChanged;
    }
    public class NavigationStore : INavigationStore
    {
        public event Action? CurrentViewModelChanged;
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        private ViewModelBase _popUpViewModel;
        public ViewModelBase PopUpViewModel
        {
            get
            {
                return _popUpViewModel;
            }
            set
            {
                _popUpViewModel = value;
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
