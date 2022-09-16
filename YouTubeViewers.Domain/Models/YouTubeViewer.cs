using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeViewers.Domain.Models
{
    public class YouTubeViewer
    {
        public YouTubeViewer(string username, bool isSubscribed, bool isMember, Guid id)
        {
            Username = username;
            IsSubscribed = isSubscribed;
            IsMember = isMember;
            Id = id;
        }
        public Guid Id { get; }


        public string Username { get; }
        public bool IsSubscribed { get; }
        public bool IsMember { get; }
    }
}
