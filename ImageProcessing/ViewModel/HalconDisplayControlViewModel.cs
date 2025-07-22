using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using HalconDotNet;
using ImageProcessing.Messages;
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
    }
}
