using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MachineVisionSatrt.ViewModel
{
    partial class MainWindowViewModel : ObservableObject
    {


        [RelayCommand]
        private void Exit()
        {
            // 可选：弹窗确认
            var result = System.Windows.MessageBox.Show(
                "确定要退出程序吗？",
                "退出确认",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // 这里可以放资源释放或保存操作
                Application.Current.Shutdown();
            }
        }

        [RelayCommand]
        private void ConfigCommunicate()
        {
            MessageBox.Show("配置通讯");
        }

        [RelayCommand]
        private void NewProject()
        {
            MessageBox.Show("新建项目");
        }

        [RelayCommand]
        private void OpenProject()
        {
            MessageBox.Show("打开项目");
        }
    }
}
