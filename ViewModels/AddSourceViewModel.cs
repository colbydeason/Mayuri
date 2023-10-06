using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Mayuri.Commands;
using Mayuri.Models;

namespace Mayuri.ViewModels
{
    public class AddSourceViewModel : ViewModelBase
    {
        private string _sourceName;
        public string SourceName
        {
            get
            {
                return _sourceName;
            }
            set
            {
                _sourceName = value;
                OnPropertyChanged(nameof(SourceName));
            }
        }
        private string _sourceDescription;
        public string SourceDescription 
        {
            get
            {
                return _sourceDescription;
            }
            set
            {
                _sourceDescription = value;
                OnPropertyChanged(nameof(SourceDescription));
            }
        }
        private SourceType _sourceType;
        public SourceType SourceType 
        {
            get
            {
                return _sourceType;
            }
            set
            {
                _sourceType = value;
                OnPropertyChanged(nameof(SourceType));
            }
        }
        private bool _sourceOneTime;
        public bool SourceOneTime 
        {
            get
            {
                return _sourceOneTime;
            }
            set
            {
                _sourceOneTime = value;
                OnPropertyChanged(nameof(SourceOneTime));
            }
        }
        private int _sourceDuration;
        public int SourceDuration 
        {
            get
            {
                return _sourceDuration;
            }
            set
            {
                _sourceDuration = value;
                OnPropertyChanged(nameof(SourceDuration));
            }
        }
        public ICommand CreateSourceCommand { get; }
        public AddSourceViewModel()
        {
            CreateSourceCommand = new CreateSourceCommand();
        }
    }
}
