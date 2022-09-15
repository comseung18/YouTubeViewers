using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeViewers.WPF.ViewModels
{
    internal class AddYouTubeViewerViewModel : ViewModelBase
    {
        public YouTubeViewerDetailFormViewModel YouTubeViewerDetailFormViewModel { get; }

        public AddYouTubeViewerViewModel()
        {
            YouTubeViewerDetailFormViewModel = new YouTubeViewerDetailFormViewModel();
        }
    }
}
