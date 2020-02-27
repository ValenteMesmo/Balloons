using Microsoft.Xna.Framework;
using System;

namespace MonogameFacade
{
    public class CreateBlock : GameObject
    {
        int cooldown = 0;

        Color[] Colors = new Color[] {
            Color.Red,
            Color.Blue,
            Color.Green,
            Color.Yellow,
            Color.Magenta,
            Color.Cyan,
            Color.Orange,
            Color.White,

            Color.Red,
            Color.Blue,
            Color.Green,
            Color.Yellow,
            Color.Magenta,
            Color.Cyan,
            Color.Orange,
            Color.White,

            Color.Red,
            Color.Blue,
            Color.Green,
            Color.Yellow,
            Color.Magenta,
            Color.Cyan,
            Color.Orange,
            Color.White,
        };

        private const int initialSpeed = 10;

        Point[] possibleSpeeds = new Point[]
        {
            new Point(0,initialSpeed)
            ,new Point(initialSpeed,0)
            ,new Point(0,-initialSpeed)
            ,new Point(-initialSpeed,0)
            ,new Point(-initialSpeed,-initialSpeed)
            ,new Point(initialSpeed,initialSpeed)
            ,new Point(-initialSpeed,initialSpeed)
            ,new Point(initialSpeed,-initialSpeed)
        };

        public override void Update(BaseGame game)
        {
            if (cooldown > 0)
            {
                cooldown = cooldown - 1;
                return;
            }

            for (int i = 0; i < game.Touches.Count; i++)
                //for (int j = 0; j < possibleSpeeds.Length; j++)
                game.Objects.Add(new Block(game)
                {
                    Position = game.Touches[i].ToPoint(),
                    //Speed = new Point(initialSpeed, initialSpeed),
                    Color = Colors[i]
                }); ;

            cooldown = 0;
        }
    }

    public class Block : GameObject
    {
        private SpriteRenderer texture;
        private int Duration = 100;
        public Point Speed;

        public Color Color;

        public Block(BaseGame game)
        {
            this.texture = new SpriteRenderer()
            {
                Texture = game.Texutes["btn"],
                Target = new Rectangle(0, 0, 200, 200)
            };
        }

        public override void Update(BaseGame game)
        {
            Duration = Duration - 1;
            if (Duration == 0)
            //if (Speed.X == 0 && Speed.Y == 0)
            {
                game.Objects.Remove(this);
                return;
            }

            //Speed.X = (int)MathHelper.Lerp(Speed.X, 0f, 0.0000001f);
            //Speed.Y = (int)MathHelper.Lerp(Speed.Y, 0f, 0.0000001f);

            //Position.X = Position.X + Speed.X;
            //Position.Y = Position.Y + Speed.Y;

            texture.Target.X = Position.X;
            texture.Target.Y = Position.Y;
            //texture.Target.Width =
            //    texture.Target.Height = 250 + Math.Abs(Speed.X) + Math.Abs(Speed.Y);
            texture.Color = Color;

            game.Renderers.Add(texture);
        }
    }
}
