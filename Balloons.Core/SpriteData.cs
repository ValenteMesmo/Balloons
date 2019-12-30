using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Balloons.Core
{
    public class SpriteData
    {
        public SpriteData(Texture2D texture)
        {
            this.texture = texture;
        }
        public Texture2D texture { get; set; }
        public Rectangle targetRectangle { get; set; } = Rectangle.Empty;
        public Rectangle sourceRectangle { get; set; } = Rectangle.Empty;
    }
}
