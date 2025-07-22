using CommunityToolkit.Mvvm.Messaging;
using HalconDotNet;
using ImageProcessing.Messages;
using ImageProcessing.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageProcessing.View
{
    /// <summary>
    /// HalconDisplayControl.xaml 的交互逻辑
    /// </summary>
    public partial class HalconDisplayControl : UserControl, IRecipient<ImageLoadedMessage>
    {
        public HalconDisplayControl()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.Register(this);
            this.DataContext = new HalconDisplayControlViewModel();
        }
        public void Receive(ImageLoadedMessage message)
        {
            if (message.Value != null)
            {
                HalconDisplay.HalconWindow.ClearWindow();
                HalconDisplay.HalconWindow.DispObj(message.Value);
                HalconDisplay.SetFullImagePart();
            }
        }
    }
}
