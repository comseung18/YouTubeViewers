using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeViewers.WPF.ViewModels
{
    internal class EditYouTubeViewerViewModel : ViewModelBase
    {
        public YouTubeViewerDetailFormViewModel YouTubeViewerDetailFormViewModel { get; }

        public EditYouTubeViewerViewModel()
        {
            YouTubeViewerDetailFormViewModel = new YouTubeViewerDetailFormViewModel();
        }
    }
}
