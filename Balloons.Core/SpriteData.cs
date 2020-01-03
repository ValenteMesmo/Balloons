using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Balloons.Core
{
    public class SpriteData : Drawaaaaa
    {
        public SpriteData(Texture2D texture)
        {
            this.texture = texture;
        }
        public Texture2D texture { get; set; }
        public Rectangle targetRectangle { get; set; } = Rectangle.Empty;
        public Rectangle sourceRectangle { get; set; } = Rectangle.Empty;

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(
                texture
                , targetRectangle
                , sourceRectangle
                , Color.White);
        }
    }

    public class TextSprite : Drawaaaaa
    {
        public string Text { get; set; }

        public Vector2 Position { get; set; }

        public SpriteFont Font { get; set; }

        public override void Draw(SpriteBatch batch)
        {
            batch.DrawString(
                Font
                , Text
                , Position
                , Color.Blue
                , 0
                , Vector2.Zero
                , 5
                , SpriteEffects.None
                , 0
            );
        }
    }

    public abstract class Drawaaaaa
    {
        public abstract void Draw(SpriteBatch batch);
    }
}
