using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeViewers.WPF.Commands
{
    internal abstract class AsyncCommandBase : CommandBase
    {
        public override async void Execute(object? parameter)
        {
            try
            {
                await ExcuteAsync(parameter);
            }
            catch (Exception) { }
            
        }

        public abstract Task ExcuteAsync(object? parameter);
    }
}
