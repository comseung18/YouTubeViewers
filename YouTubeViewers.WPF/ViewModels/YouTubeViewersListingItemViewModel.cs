using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeViewers.WPF.Commands;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels
{
    internal class YouTubeViewersListingItemViewModel : ViewModelBase
    {
        public YouTubeViewer YouTubeViewer { get; private set; }

        public string Username => YouTubeViewer.Username;

        public YouTubeViewersListingItemViewModel(YouTubeViewer youTubeViewer, YouTubeViewersStore youTubeViewersStore, ModalNavigationStore modalNavigationStore)
        {
            YouTubeViewer = youTubeViewer;

            EditCommand = new OpenEditYouTubeViewerCommand(this, youTubeViewersStore, modalNavigationStore);
        }

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        internal void Update(YouTubeViewer youTubeViewer)
        {
            YouTubeViewer = youTubeViewer;
            OnPropertyChanged(nameof(Username));
        }
    }
}
