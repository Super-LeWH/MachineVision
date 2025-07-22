using CommunityToolkit.Mvvm.Messaging.Messages;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing.Messages
{
    public class ImageLoadedMessage : ValueChangedMessage<HImage>
    {
        public ImageLoadedMessage(HImage value) : base(value)
        {
        }
    }
}
