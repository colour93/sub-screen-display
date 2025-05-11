using System.Windows;

namespace SubScreenDisplay
{
    /// <summary>
    /// DataBindingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DataBindingWindow : Window
    {
        public DataBindingWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
} 