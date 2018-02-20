using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Model;

namespace App.Shared
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<RssFeedItem> _feed = new List<RssFeedItem>();

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            
        }

        public async Task Load()
        {
            try
            {
                _feed = await MyAppContext.FeedService.Load();
                FeedLoadingError = "";
            }
            catch (Exception e)
            {
                FeedLoadingError = e.Message;
            }
            finally
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Feed)));
            }
        }

        public List<RssFeedItem> Feed => _feed;
        private string feedLoadingError;

        public string FeedLoadingError
        {
            get
            {
                return feedLoadingError;
            }

            private set
            {
                feedLoadingError = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FeedLoadingError)));
            }
        }
    }
}