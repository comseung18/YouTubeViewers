using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Stores
{
    internal class ModalNavigationStore
    {
		private ViewModelBase? _currentViewModel;

		public ViewModelBase? CurrentViewModel
        {
			get 
			{ 
				return _currentViewModel;
			}
			set 
			{
                _currentViewModel?.Dispose();
                _currentViewModel = value;
				CurrentViewModelChanged?.Invoke();
			}
		}

        public bool IsOpen => CurrentViewModel != null;

        public event Action? CurrentViewModelChanged;

		internal void Close()
		{
			CurrentViewModel = null;
		}
	}
}
