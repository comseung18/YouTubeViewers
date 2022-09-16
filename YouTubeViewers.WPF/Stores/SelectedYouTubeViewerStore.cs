using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Models;

namespace YouTubeViewers.WPF.Stores
{
    internal class SelectedYouTubeViewerStore
    {
		private YouTubeViewer? _selectedYouTubeViewer;
		private readonly YouTubeViewersStore _youTubeViewersStore;

		public SelectedYouTubeViewerStore(YouTubeViewersStore youTubeViewersStore)
		{
			_youTubeViewersStore = youTubeViewersStore;
			_youTubeViewersStore.YouTubeViewerUpdated += _youTubeViewersStore_YouTubeViewerUpdated;
		}

		private void _youTubeViewersStore_YouTubeViewerUpdated(YouTubeViewer youTubeViewer)
		{
			if(youTubeViewer.Id == SelectedYouTubeViewer?.Id)
			{
				SelectedYouTubeViewer = youTubeViewer;
			}
		}

		public YouTubeViewer? SelectedYouTubeViewer
        {
			get 
			{ 
				return _selectedYouTubeViewer; 
			}
			set 
			{
                _selectedYouTubeViewer = value;
				SelectedYouTubeViewerChanged?.Invoke();

            }
		}

		public event Action? SelectedYouTubeViewerChanged;

	}
}
