using Mayuri.Commands;
using Mayuri.Models;
using Microsoft.Extensions.DependencyInjection;
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
        private Guid _logSourceId;
        public Guid LogSourceId
        {
            get
            {
                return _logSourceId;
            }
            set
            {
                _logSourceId = value;
                OnPropertyChanged(nameof(LogSourceId));
            }
        }
        private KeyValuePair<Guid, string> _logSource;
        public KeyValuePair<Guid, string> LogSource
        {
            get
            {
                return _logSource;
            }
            set
            {
                _logSourceId = value.Key;
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
        public List<KeyValuePair<Guid, string>> CurrentSourcesList => _sources.GetCurrentSourcesList().Result;
        public ICommand CreateLogCommand { get; }
        private ISourceList _sources;
        private ILogList _logs;
        public CreateLogViewModel()
        {
            _sources = App.Current.Services.GetService<ISourceList>();
            _logs = App.Current.Services.GetService<ILogList>();
            CreateLogCommand = new CreateLogCommand(this, _sources, _logs);
        }
    }
}
