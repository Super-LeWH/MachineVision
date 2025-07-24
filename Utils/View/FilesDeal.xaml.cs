using System;
using System.Collections.Generic;
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
using Utils.ViewModel;

namespace Utils.View
{
    /// <summary>
    /// FilesDeal.xaml 的交互逻辑
    /// </summary>
    public partial class FilesDeal : UserControl
    {
        public FilesDeal()
        {
            InitializeComponent();
            this.DataContext = new FilesDealViewModel();
        }
    }
}
