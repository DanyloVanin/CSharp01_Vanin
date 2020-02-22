using System.Windows;
using CSharp_Vanin_01.ViewModels;

namespace CSharp_Vanin_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new BirthdayAnalyzerViewModel();
        }
    }
}
