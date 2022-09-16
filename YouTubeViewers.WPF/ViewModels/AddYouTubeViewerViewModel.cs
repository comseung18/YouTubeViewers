using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeViewers.WPF.Commands;

namespace YouTubeViewers.WPF.ViewModels
{
    internal class AddYouTubeViewerViewModel : ViewModelBase
    {
        public YouTubeViewerDetailFormViewModel YouTubeViewerDetailFormViewModel { get; }

        
        public AddYouTubeViewerViewModel(Stores.YouTubeViewersStore youTubeViewersStore, Stores.ModalNavigationStore modalNavigationStore)
        {
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            ICommand submitCommand = new AddYouTubeViewerCommand(this, youTubeViewersStore,modalNavigationStore);
            YouTubeViewerDetailFormViewModel = new YouTubeViewerDetailFormViewModel(submitCommand, cancelCommand);
        }
    }
}
