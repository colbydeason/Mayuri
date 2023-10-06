using Mayuri.Commands;
using Mayuri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mayuri.ViewModels
{
    public class CreateLogViewModel : ViewModelBase
    {
        private Source _logSource;
        public Source LogSource
        {
            get
            {
                return _logSource;
            }
            set
            {
                _logSource = value;
                OnPropertyChanged(nameof(LogSource));
            }
        }
        private int _logDuration;
        public int LogDuration 
        {
            get
            {
                return _logDuration;
            }
            set
            {
                _logDuration = value;
                OnPropertyChanged(nameof(LogDuration));
            }
        }
        public ICommand CreateLogCommand { get; }
        public CreateLogViewModel()
        {
            CreateLogCommand = new CreateLogCommand(); 
        }
    }
}
