using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Adapters
{
    public interface IMediaPlayer
    {
        void Play(string type, string name);
        void AddSupport(IMediaPlayer plugin);
    }
}
