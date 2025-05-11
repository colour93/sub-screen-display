using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SubScreenDisplay.ViewModels
{
    public class DemoViewModel : INotifyPropertyChanged
    {
        private string _title;
        private string _description;
        private ObservableCollection<DemoItem> _items;

        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<DemoItem> Items
        {
            get => _items;
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged();
                }
            }
        }

        public DemoViewModel()
        {
            Title = "Fluent UI 演示";
            Description = "这是一个使用 WPF + .NET 9.0 + 官方 FluentUI 的示例应用";
            
            // 初始化项目列表
            Items = new ObservableCollection<DemoItem>
            {
                new DemoItem { Name = "项目 1", Description = "这是项目1的描述", IsSelected = false },
                new DemoItem { Name = "项目 2", Description = "这是项目2的描述", IsSelected = true },
                new DemoItem { Name = "项目 3", Description = "这是项目3的描述", IsSelected = false },
                new DemoItem { Name = "项目 4", Description = "这是项目4的描述", IsSelected = false },
                new DemoItem { Name = "项目 5", Description = "这是项目5的描述", IsSelected = false }
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DemoItem : INotifyPropertyChanged
    {
        private string _name;
        private string _description;
        private bool _isSelected;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 