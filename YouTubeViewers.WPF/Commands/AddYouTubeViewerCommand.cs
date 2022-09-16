using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Commands
{
    internal class AddYouTubeViewerCommand : AsyncCommandBase
    {
        private readonly AddYouTubeViewerViewModel _addYouTubeViewerViewModel;
        private readonly YouTubeViewersStore _youTubeViewersStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public AddYouTubeViewerCommand(ViewModels.AddYouTubeViewerViewModel addYouTubeViewerViewModel, YouTubeViewersStore youTubeViewersStore, ModalNavigationStore modalNavigationStore)
        {
            _addYouTubeViewerViewModel = addYouTubeViewerViewModel;
            _youTubeViewersStore = youTubeViewersStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExcuteAsync(object? parameter)
        {
            YouTubeViewerDetailFormViewModel formViewModel = _addYouTubeViewerViewModel.YouTubeViewerDetailFormViewModel;
            YouTubeViewer youTubeViewer = new YouTubeViewer(
                formViewModel.Username,
                formViewModel.IsSubscribed,
                formViewModel.IsMember,
                Guid.NewGuid()
                ); 

            try
            {
                await _youTubeViewersStore.Add(youTubeViewer);
                _modalNavigationStore.Close();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
