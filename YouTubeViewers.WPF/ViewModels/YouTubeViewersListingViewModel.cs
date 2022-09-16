using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeViewers.WPF.Commands;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels
{
    internal class YouTubeViewersListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<YouTubeViewersListingItemViewModel> _youTubeViewersListingItemViewModels;
        private readonly YouTubeViewersStore _youTubeViewersStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private SelectedYouTubeViewerStore _selectedYouTubeViewerStore;

        public IEnumerable<YouTubeViewersListingItemViewModel> YouTubeViewersListingItemViewModels => _youTubeViewersListingItemViewModels;

        private YouTubeViewersListingItemViewModel? _selectedYouTubeViewerListingItemViewModel;

        public YouTubeViewersListingItemViewModel? SelectedYouTubeViewerListingItemViewModel
        {
            get { return _selectedYouTubeViewerListingItemViewModel; }
            set 
            { 
                _selectedYouTubeViewerListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedYouTubeViewerListingItemViewModel));

                _selectedYouTubeViewerStore.SelectedYouTubeViewer = _selectedYouTubeViewerListingItemViewModel?.YouTubeViewer;
            }

        }

        public YouTubeViewersListingViewModel(YouTubeViewersStore youTubeViewersStore, SelectedYouTubeViewerStore selectedYouTubeViewerStore, ModalNavigationStore modalNavigationStore)
        {
            _youTubeViewersStore = youTubeViewersStore;
            _selectedYouTubeViewerStore = selectedYouTubeViewerStore;
            _modalNavigationStore = modalNavigationStore;
            _youTubeViewersListingItemViewModels = new ObservableCollection<YouTubeViewersListingItemViewModel>();

            _youTubeViewersStore.YouTubeViewerAdded += YouTubeViewersStore_YouTubeViewerAdded;
            _youTubeViewersStore.YouTubeViewerUpdated += _youTubeViewersStore_YouTubeViewerUpdated;
        }

        private void _youTubeViewersStore_YouTubeViewerUpdated(YouTubeViewer youTubeViewer)
        {
            YouTubeViewersListingItemViewModel? youTubeViewersListingItemViewModel
                = _youTubeViewersListingItemViewModels.FirstOrDefault(y => y.YouTubeViewer.Id == youTubeViewer.Id);

            if(youTubeViewersListingItemViewModel != null)
            {
                youTubeViewersListingItemViewModel.Update(youTubeViewer);
            }
        }

        public override void Dispose()
        {
            _youTubeViewersStore.YouTubeViewerAdded -= YouTubeViewersStore_YouTubeViewerAdded;
            _youTubeViewersStore.YouTubeViewerUpdated -= _youTubeViewersStore_YouTubeViewerUpdated;
            base.Dispose();
        }

        private void YouTubeViewersStore_YouTubeViewerAdded(YouTubeViewer youTubeViewer)
        {
            AddYouTubeViewer(youTubeViewer);
        }

        private void AddYouTubeViewer(YouTubeViewer youTubeViewer)
        {
            YouTubeViewersListingItemViewModel itemViewModel =
                new YouTubeViewersListingItemViewModel(youTubeViewer, _youTubeViewersStore, _modalNavigationStore);
            _youTubeViewersListingItemViewModels.Add(itemViewModel);

        }
    }
}
