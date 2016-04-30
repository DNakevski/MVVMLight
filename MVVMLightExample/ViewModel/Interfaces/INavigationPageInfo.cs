using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLightExample.ViewModel.Interfaces
{
    public interface INavigationPageInfo
    {
        string Name { get; }
        string DisplayName { get; }
        bool IsVisible { get; set; }
    }
}
