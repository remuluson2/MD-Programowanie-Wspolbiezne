using PresentationLayer.ViewModel;
using System.Windows;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BallViewModel vm = new();
            DataContext = vm;
        }
    }
    
}
