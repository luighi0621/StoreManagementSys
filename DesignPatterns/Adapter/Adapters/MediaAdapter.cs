using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Adapters
{
    public class MediaAdapter : IMediaPlayer
    {
        IAdvancedMediaPlayer advanced;
        Dictionary<string, IAdvancedMediaPlayer> _Plugins = new Dictionary<string, IAdvancedMediaPlayer>();

        public MediaAdapter(string type)
        {
            if (string.Compare(type, "vlc", true) == 0)
            {
                advanced = new VLCPlayer();
            }
            else if (string.Compare(type, "mp4", true) == 0)
            {
                advanced = new Mp4Player();
            }
        }

        public void AddSupport(IMediaPlayer plugin)
        {
            
        }

        public void Play(string type, string name)
        {
            if (string.Compare(type, "vlc", true) == 0)
            {
                advanced.PlayVLC(name);
            }
            else if (string.Compare(type, "mp4", true) == 0)
            {
                advanced.PlayMp4(name);
            }
        }
    }
}
