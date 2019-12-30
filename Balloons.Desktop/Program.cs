using Balloons.Core;
using System;

namespace Balloons.Desktop
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (var game = new Game1(new DesktopContetLoader()))
                game.Run();
        }
    }
}
