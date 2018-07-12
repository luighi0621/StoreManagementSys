using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Adapters
{
    public class Mp4Player : IAdvancedMediaPlayer
    {
        public void PlayMp4(string name)
        {
            Console.WriteLine("playing with mp4 file: {0}", name);
        }

        public void PlayVLC(string name)
        {
            Console.WriteLine("not supported");
        }
    }
}
