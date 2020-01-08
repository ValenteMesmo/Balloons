using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

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

                var idleAnimation = new List<SpriteData>();
                var deathAnimation = new List<SpriteData>();

                var cellSize = 170;

                for (int i = 0; i < 5; i++)
                {
                    idleAnimation.Add(new SpriteData(world.Textures["coin"])
                    {
                        sourceRectangle = new Rectangle(i* 200, 0, 200, cellSize),
                        targetRectangle = new Rectangle(ballonX, ballonY, GameConstants.BalloonSize, GameConstants.BalloonSize)
                    });

                    deathAnimation.Add(new SpriteData(world.Textures["coin"])
                    {
                        sourceRectangle = new Rectangle(i * 200, cellSize, 200, cellSize),
                        targetRectangle = new Rectangle(ballonX, ballonY, GameConstants.BalloonSize, GameConstants.BalloonSize)
                    });
                }

                var ballon = new Balloon(                    
                    world.TouchInputs
                    , idleAnimation.ToArray()
                    , deathAnimation.ToArray());
                ballon.X = ballonX;
                ballon.Y = ballonY;
                world.AddObject(ballon);
            }
        }
    }
}
