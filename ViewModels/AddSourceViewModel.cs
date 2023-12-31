﻿using Mayuri.Commands;
using Mayuri.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Windows.Input;

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
        public static List<string> SourceTypeList
        {
            get
            {
                return new List<string>
                {
                    "Book",
                    "Anime",
                    "Manga",
                    "Visual Novel",
                    "Video Game",
                    "Reading",
                    "Listening",
                    "Other"
                };
            }
        }

        private string _sourceType;
        public string SourceType
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
        public ICommand CreateSourceCommand { get; }
        private ISourceList _sources;
        public AddSourceViewModel()
        {
            SourceOneTime = false;
            _sources = App.Current.Services.GetService<ISourceList>();
            CreateSourceCommand = new CreateSourceCommand(this, _sources);
        }
    }
}
