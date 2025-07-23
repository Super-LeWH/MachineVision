using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using HalconDotNet;
using ImageProcessing.Messages;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing.ViewModel
{
    public partial class HalconDisplayControlViewModel : ObservableObject, IRecipient<ImageLoadedMessage>
    {
        public HalconDisplayControlViewModel()
        {
            // 注册订阅
            WeakReferenceMessenger.Default.Register(this);
        }

        [ObservableProperty]
        private HImage? _displayImage;

        /// <summary>
        /// 收到加载的图像
        /// </summary>
        public void Receive(ImageLoadedMessage message)
        {
            DisplayImage = message.Value;
        }

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
                // 写入日志
                Logging.Service.LogService.Info("读入一张图像");
            }
        }
    }
}
