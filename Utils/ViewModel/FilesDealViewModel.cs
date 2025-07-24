using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.View;

namespace Utils.ViewModel
{
    internal partial class FilesDealViewModel : ObservableObject
    {
        [ObservableProperty]
        private object? currentView;
        public FilesDealViewModel()
        {
            CurrentView = new PageOfReadWrite();
        }

        [RelayCommand]
        private void ChangePage(string pageName)
        {
            switch (pageName)
            {
                case "PageOfReadWrite":
                    CurrentView = new PageOfReadWrite();
                    break;
                case "PageB":
                    CurrentView = new PageB();
                    break;
            }
        }
    }
}
