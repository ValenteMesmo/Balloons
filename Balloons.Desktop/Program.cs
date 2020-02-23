using MonogameFacade;
using System;
using System.Threading.Tasks;

namespace Balloons.Desktop
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (var game = new DesktopGame())
            {
                Task.Factory.StartNew(async () =>
                {
                    await Task.Delay(500);

                    for (int k = 0; k < 5; k++)
                    for (int i = 0; i < 100; i++)
                        for (int j = 0; j < 100; j++)
                        {
                            var obj = new Block(game);
                            obj.Position.X = i * 10;
                            obj.Position.Y = j * 10;
                            game.Objects.Add(obj);
                        }

                    game.Objects.Add(new FpsDisplay(game));
                });

                game.Run();
            }
        }
    }
}
