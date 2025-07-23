using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.ViewModel
{
    public partial class LoggingControlViewModel : ObservableObject
    {
        // logItems在注解的前提下会变换为LogItems
        [ObservableProperty]
        private ObservableCollection<string> logItems = new();
    }
}
