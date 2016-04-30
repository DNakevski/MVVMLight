using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVMLightExample.Models;
using MVVMLightExample.ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMLightExample.ViewModel
{
    public class EmployeesViewModel : ViewModelBase, INavigationPageInfo
    {
        //navigation info parameteres
        private const string _name = "EmployeesView";
        private const string _displayName = "Employees View";
        private bool _isVisible = true;

        private ObservableCollection<Employee> _employees;
        private Employee _selectedEmployee;

        public ICommand LoadEmployeesCommand { get; set; }
        public ICommand SaveEmployeesCommand { get; set; }

        public EmployeesViewModel()
        {
            LoadEmployeesCommand = new RelayCommand(LoadEmployeesMethod);
            SaveEmployeesCommand = new RelayCommand(SaveEmployeeMethod);
        }

        public ObservableCollection<Employee> EmployeeList { get { return _employees; } }

        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                if (_selectedEmployee != value)
                {
                    _selectedEmployee = value;
                    RaisePropertyChanged(() => SelectedEmployee);
                }
            }
        }

        //Page navigation info properties
        public string Name { get { return _name; } }
        public string DisplayName { get { return _displayName; } }
        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }

            set
            {
                if (_isVisible == value)
                    return;
                _isVisible = value;
                RaisePropertyChanged(() => IsVisible);
            }
        }

        //Command methods
        public void SaveEmployeeMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Employees Saved"));
        }

        public void LoadEmployeesMethod()
        {
            _employees = Employee.GetAllEmployees();
            RaisePropertyChanged(() => EmployeeList);
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Employees Loaded"));
        }
    }
}
