using System.Windows;
using System.Windows.Controls;

namespace SubScreenDisplay.Player
{
    public partial class LyricItem : UserControl
    {
        // 定义依赖属性
        public static readonly DependencyProperty MainProperty =
            DependencyProperty.Register("Main", typeof(string), typeof(LyricItem), 
                new PropertyMetadata(string.Empty, OnMainChanged));
                
        public static readonly DependencyProperty SubProperty =
            DependencyProperty.Register("Sub", typeof(string), typeof(LyricItem), 
                new PropertyMetadata(string.Empty, OnSubChanged));
                
        public static readonly DependencyProperty IsHighlightedProperty =
            DependencyProperty.Register("IsHighlighted", typeof(bool), typeof(LyricItem), 
                new PropertyMetadata(false, OnIsHighlightedChanged));
        
        // 属性
        public string Main
        {
            get { return (string)GetValue(MainProperty); }
            set { SetValue(MainProperty, value); }
        }
        
        public string Sub
        {
            get { return (string)GetValue(SubProperty); }
            set { SetValue(SubProperty, value); }
        }
        
        public bool IsHighlighted
        {
            get { return (bool)GetValue(IsHighlightedProperty); }
            set { SetValue(IsHighlightedProperty, value); }
        }
        
        public LyricItem()
        {
            InitializeComponent();
        }
        
        // 依赖属性回调
        private static void OnMainChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (LyricItem)d;
            control.MainText.Text = e.NewValue as string;
        }
        
        private static void OnSubChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (LyricItem)d;
            control.SubText.Text = e.NewValue as string;
        }
        
        private static void OnIsHighlightedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (LyricItem)d;
            bool isHighlighted = (bool)e.NewValue;
            
            if (isHighlighted)
            {
                // control.MainText.Foreground = System.Windows.Media.Brushes.LightSkyBlue;
                // control.SubText.Foreground = System.Windows.Media.Brushes.LightBlue;
                control.MainText.FontSize = 32;
                control.MainText.FontWeight = FontWeights.Bold;
                control.MainText.Margin = new Thickness(0, 0, 0, 2);
                control.SubText.FontSize = 14;
                control.SubText.FontWeight = FontWeights.Bold;
            }
            else
            {
                // control.MainText.Foreground = System.Windows.Media.Brushes.White;
                // control.SubText.Foreground = System.Windows.Media.Brushes.LightGray;
            }
        }
    }
}