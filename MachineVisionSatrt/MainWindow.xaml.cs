using MachineVisionSatrt.ViewModel;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MachineVisionSatrt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // 设置应用的版本信息
            var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString();
            // 按点分割，保留前3段
            var parts = version.Split('.');
            var shortFileVersion = string.Join(".", parts.Take(3));
            this.Title = $"MachineVision V{shortFileVersion}";
            // 数据绑定
            this.DataContext = new MainWindowViewModel();
        }
    }
}