using GalaSoft.MvvmLight;
using MVVMLightExample.ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLightExample.ViewModel
{
    public class HomePageViewModel : ViewModelBase, INavigationPageInfo
    {
        private const string _name = "HomePageView";
        private const string _displayName = "Home Page View";
        private bool _isVisible = true;

        private string _content = "This is Home View, Welcome! :)";

        public string DisplayName { get { return _displayName; } }
        public string Name { get { return _name; } }

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                if (_isVisible == value)
                    return;

                _isVisible = value;
                RaisePropertyChanged(() => IsVisible);
            }
        }

        public string Content { get { return _content; }
            set
            {
                if (_content == value)
                    return;

                _content = value;
                RaisePropertyChanged(() => Content);
            }
        }

    }
}
