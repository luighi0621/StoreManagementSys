using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Adapters
{
    public interface IAdvancedMediaPlayer
    {
        void PlayVLC(string name);
        void PlayMp4(string name);
    }
}
