using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImmersionTrack.Models;

namespace ImmersionTrack.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }
        public MainViewModel(ImmersionTime stopWatch)
        {
            CurrentViewModel = new ImmersionTimeViewModel(stopWatch);
        }
    }
}
