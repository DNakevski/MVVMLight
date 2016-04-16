using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLightExample.Models
{
    public class Employee : ObservableObject
    {
        private int _id;
        private string _name;
        private int _age;
        private decimal _salary;

        public int ID {
            get { return _id; }
            set
            {
                if(_id != value)
                {
                    Set<int>(() => ID, ref _id, value);
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    Set<string>(() => Name, ref _name, value);
                }
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (_age != value)
                {
                    Set<int>(() => Age, ref _age, value);
                }
            }
        }

        public decimal Salary
        {
            get { return _salary; }
            set
            {
                if (_salary != value)
                {
                    Set<decimal>(() => Salary, ref _salary, value);
                }
            }
        }

        public static ObservableCollection<Employee> GetAllEmployees()
        {
            var _employees = new ObservableCollection<Employee>();
            for(int i = 1; i <= 30; i++)
            {
                _employees.Add(new Employee
                {
                    ID = i,
                    Name = "Employee" + i,
                    Age = 20 + i,
                    Salary = 20000 + (i * 10)
                });
            }

            return _employees;
        }
    }
}
