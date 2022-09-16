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
    internal class EditYouTubeViewerCommand : AsyncCommandBase
    {
        private readonly EditYouTubeViewerViewModel _editYouTubeViewerViewModel;
        private readonly YouTubeViewersStore _youTubeViewersStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public EditYouTubeViewerCommand(EditYouTubeViewerViewModel editYouTubeViewerViewModel, YouTubeViewersStore youTubeViewersStore, ModalNavigationStore modalNavigationStore)
        {
            this._editYouTubeViewerViewModel = editYouTubeViewerViewModel;
            this._youTubeViewersStore = youTubeViewersStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExcuteAsync(object? parameter)
        {
            YouTubeViewerDetailFormViewModel formViewModel = _editYouTubeViewerViewModel.YouTubeViewerDetailFormViewModel;
            YouTubeViewer youTubeViewer = new(
                formViewModel.Username,
                formViewModel.IsSubscribed,
                formViewModel.IsMember,
                _editYouTubeViewerViewModel.YouTubeViewerId
                );

            try
            {
                await _youTubeViewersStore.Update(youTubeViewer);
                _modalNavigationStore.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
