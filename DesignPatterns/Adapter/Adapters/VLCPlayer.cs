using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Adapters
{
    class VLCPlayer : IAdvancedMediaPlayer
    {
        public void PlayMp4(string name)
        {
            Console.WriteLine("not supported"); ;
        }

        public void PlayVLC(string name)
        {
            Console.WriteLine("playing with vlc file: {0}", name);
        }
    }
}
