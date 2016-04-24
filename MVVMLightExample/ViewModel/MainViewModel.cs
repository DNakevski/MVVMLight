using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVMLightExample.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVMLightExample.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        readonly static EmployeesViewModel _employeeViewModel = new EmployeesViewModel();

        public MainViewModel()
        {
            CurrentViewModel = _employeeViewModel;
            ActivateEmployeesViewCommand = new RelayCommand(ActivateEmployeesView);
        }

        public ViewModelBase CurrentViewModel {
            get { return _currentViewModel; }
            set
            {
                if (_currentViewModel == value)
                    return;
                _currentViewModel = value;
                RaisePropertyChanged(() => CurrentViewModel);
            }
        }

        public ICommand ActivateEmployeesViewCommand { get; set; }

        private void ActivateEmployeesView()
        {
            CurrentViewModel = _employeeViewModel;
        }
    }
}