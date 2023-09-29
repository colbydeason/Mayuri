using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mayuri.Models;

namespace Mayuri.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }
        public MainViewModel(ImmersionTime immersionTime)
        {
            CurrentViewModel = new ImmersionTimeViewModel(immersionTime);
            //CurrentViewModel = new MenuViewModel(); 
        }
    }
}
