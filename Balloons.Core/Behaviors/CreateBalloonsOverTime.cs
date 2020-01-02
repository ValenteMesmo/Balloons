using Microsoft.Xna.Framework;
using System;

namespace Balloons.Core
{
    public class CreateBalloonsOverTime : Behavior
    {        
        private readonly World world;

        private int counter = 99;
        private Random random = new Random(171);

        public CreateBalloonsOverTime(World world)
        {
            this.world = world;
        }

        public override void Update()
        {
            counter += 1;

            if (counter > GameConstants.BalloonSize / GameConstants.Speed)
            {
                counter = 0;
                var ballonY = 700;
                var ballonX = random.Next(0, 6) * GameConstants.BalloonSize;

                var ballon = new Balloon(
                    new SpriteData(world.Textures["Balloon"])
                    {
                        sourceRectangle = new Rectangle(0, 0, 64, 93),
                        targetRectangle = new Rectangle(ballonX, ballonY, GameConstants.BalloonSize, GameConstants.BalloonSize)
                    }
                    , world.TouchInputs);
                ballon.X = ballonX;
                ballon.Y = ballonY;
                world.AddObject(ballon);
            }
        }
    }
}
