using GalaSoft.MvvmLight;
using MVVMLightExample.ViewModel.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MVVMLightExample.Infrastructure;

namespace MVVMLightExample.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ICommand _changeViewCommand;
        private INavigationPageInfo _currentViewModel;
        List<INavigationPageInfo> _pageViewModels;

        public MainViewModel()
        {
            //register the active pages
            PageViewModels.Add(new HomePageViewModel());
            PageViewModels.Add(new EmployeesViewModel());

            _currentViewModel = PageViewModels[0];
        }

        public List<INavigationPageInfo> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<INavigationPageInfo>();

                return _pageViewModels;
            }
        }


        public INavigationPageInfo CurrentViewModel {
            get { return _currentViewModel; }
            set
            {
                if (_currentViewModel == value)
                    return;
                _currentViewModel = value;
                RaisePropertyChanged(() => CurrentViewModel);
            }
        }

        public ICommand ChangeViewCommand
        {
            get
            {
                if (_changeViewCommand == null)
                {
                    _changeViewCommand = new CustomRelayCommand(
                    p => ChangeViewModel((INavigationPageInfo)p),
                    p => p is INavigationPageInfo);
                }
                return _changeViewCommand;
            }
        }

        private void ChangeViewModel(INavigationPageInfo viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);
        }
    }
}