using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Threading;
using SubScreenDisplay.API;
using SubScreenDisplay.Models;
using Windows.Media.Control;

namespace SubScreenDisplay.ViewModels
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        private Song _currentSong;
        private bool _isPlaying;
        private SMTCHelper _smtcHelper;
        
        public Song CurrentSong
        {
            get => _currentSong;
            set
            {
                _currentSong = value;
                OnPropertyChanged();
            }
        }
        
        public bool IsPlaying
        {
            get => _isPlaying;
            set
            {
                _isPlaying = value;
                OnPropertyChanged();
            }
        }
        
        // 构造函数
        public PlayerViewModel()
        {
            // 初始化 SMTC Helper
            InitializeSMTCHelperAsync();
        }
        
        private async void InitializeSMTCHelperAsync()
        {
            _smtcHelper = await SMTCHelper.CreateInstance();
            
            // 注册事件处理
            _smtcHelper.MediaPropertiesChanged += OnMediaPropertiesChanged;
            _smtcHelper.PlaybackInfoChanged += OnPlaybackInfoChanged;
            _smtcHelper.SessionExited += OnSessionExited;
            
            // 初始加载当前媒体信息
            await UpdateMediaInfoAsync();
        }
        
        private async void OnMediaPropertiesChanged(object sender, EventArgs e)
        {
            await UpdateMediaInfoAsync();
        }
        
        private async void OnPlaybackInfoChanged(object sender, EventArgs e)
        {
            var status = _smtcHelper.GetPlaybackStatus();
            if (status.HasValue)
            {
                IsPlaying = status.Value == GlobalSystemMediaTransportControlsSessionPlaybackStatus.Playing;
            }
        }
        
        private void OnSessionExited(object sender, EventArgs e)
        {
            // 清空当前歌曲信息
            CurrentSong = null;
            IsPlaying = false;
        }
        
        private async Task UpdateMediaInfoAsync()
        {
            var mediaInfo = await _smtcHelper.GetMediaInfoAsync();
            if (mediaInfo != null)
            {
                // 更新播放状态
                var status = _smtcHelper.GetPlaybackStatus();
                IsPlaying = status == GlobalSystemMediaTransportControlsSessionPlaybackStatus.Playing;
                
                // 更新歌曲信息
                CurrentSong = new Song
                {
                    Title = mediaInfo.Title,
                    Artist = mediaInfo.Artist,
                };
            }
        }
        
        // INotifyPropertyChanged 实现
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}