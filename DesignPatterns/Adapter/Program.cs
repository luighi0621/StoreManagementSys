using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            // metodo para agregar formatos
            VideoPlayer videoP = new VideoPlayer();
            videoP.Play("avi", "mana.avi");
            videoP.Play("mp4", "marc anthony.mp4");
            videoP.Play("vlc", "despacito.vlc");
            videoP.Play("mp3", "mana.mp3");
            //videoP.AddSupport();
            Console.ReadKey();
        }
    }
}
