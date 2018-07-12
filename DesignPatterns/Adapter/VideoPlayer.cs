using Adapter.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class VideoPlayer : IMediaPlayer
    {
        IMediaPlayer player;
        public void Play(string type, string name)
        {
            if (string.Compare(type, "avi", true) == 0)
            {
                Console.WriteLine("Playing avi video named: {0}", name);
            }
            else if (string.Compare(type, "mp4", true) == 0 || string.Compare(type, "vlc", true) == 0)
            {
                player = new MediaAdapter(type);
                player.Play(type, name);
            }
            else
            {
                Console.WriteLine("Invalid media. {0} format not supported.", type);
            }
        }

        public void AddSupport(IMediaPlayer plugin)
        {
            player.AddSupport(plugin);
        }
    }
}
