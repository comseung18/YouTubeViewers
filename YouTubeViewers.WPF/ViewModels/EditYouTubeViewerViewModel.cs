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
    internal class EditYouTubeViewerViewModel : ViewModelBase
    {
        public Guid YouTubeViewerId { get; }
        public YouTubeViewerDetailFormViewModel YouTubeViewerDetailFormViewModel { get; }

        public EditYouTubeViewerViewModel(YouTubeViewer youTubeViewer, YouTubeViewersStore youTubeViewersStore, ModalNavigationStore modalNavigationStore)
        {
            YouTubeViewerId = youTubeViewer.Id;
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);

            ICommand submitCommand = new EditYouTubeViewerCommand(this, youTubeViewersStore, modalNavigationStore);
            YouTubeViewerDetailFormViewModel = new YouTubeViewerDetailFormViewModel(submitCommand, cancelCommand)
            {
                Username = youTubeViewer.Username,
                IsSubscribed = youTubeViewer.IsSubscribed,
                IsMember = youTubeViewer.IsMember
            };
        }
    }
}
