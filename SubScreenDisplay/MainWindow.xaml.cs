using System.Windows;
using SubScreenDisplay.API;

namespace SubScreenDisplay;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
///
public partial class MainWindow : Window
{
    public static SMTCHelper Smtc;

    public MainWindow()
    {
        InitializeComponent();
        Loaded();
    }

    private void Smtc_MediaPropertiesChanged(object? sender, EventArgs e)
    {
        Dispatcher.Invoke(async () =>
        {
            var info = await Smtc.GetMediaInfoAsync();
            if (info == null) return;

            StatusText.Text = info.Title + " - " + info.Artist;
        });
    }

    private void Smtc_SessionExited(object? sender, EventArgs e)
    {
    }

    private async void Loaded()
    {
        Smtc = await SMTCHelper.CreateInstance();
        Smtc.MediaPropertiesChanged += Smtc_MediaPropertiesChanged;
        Smtc.SessionExited += Smtc_SessionExited;
        Smtc_MediaPropertiesChanged(null, null);
    }

    private void OpenDataBindingWindow_Click(object sender, RoutedEventArgs e)
    {
        var dataBindingWindow = new DataBindingWindow();
        dataBindingWindow.Owner = this;
        dataBindingWindow.ShowDialog();
        StatusText.Text = "关闭了数据绑定示例窗口";
    }
}