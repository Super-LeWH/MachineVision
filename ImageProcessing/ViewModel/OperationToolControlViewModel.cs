using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using HalconDotNet;
using ImageProcessing.Messages;
using ImageProcessing.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ImageProcessing.ViewModel
{
    public partial class OperationToolControlViewModel : ObservableObject
    {
        /// <summary>
        /// 加载一张图像
        /// </summary>
        [RelayCommand]
        private void LoadImg()
        {
            // 创建文件选择对话框
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "请选择要加载的图像";
            openFileDialog.Filter = "图像文件 (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png|所有文件 (*.*)|*.*";

            // 显示对话框并判断是否选择了文件
            if (openFileDialog.ShowDialog() == true)
            {
                string imgPath = openFileDialog.FileName;
                var image = new HImage(imgPath);

                // 广播出去！
                WeakReferenceMessenger.Default.Send(new ImageLoadedMessage(image));
            }
        }
    }
}
