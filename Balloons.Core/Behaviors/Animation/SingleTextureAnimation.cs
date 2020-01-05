using Microsoft.Xna.Framework;

namespace Balloons.Core
{
    public class SingleTextureAnimation : Behavior
    {
        private readonly SpriteData Sprite;
        private readonly GameObject obj;

        public SingleTextureAnimation(
            GameObject obj
            , SpriteData SpriteData)
        {
            Sprite = SpriteData;
            obj.Sprites.Add(SpriteData);
            this.obj = obj;
        }

        public override void Update()
        {
            Sprite.targetRectangle = new Rectangle(
                obj.X
                , obj.Y
                , Sprite.targetRectangle.Width
                , Sprite.targetRectangle.Height);
        }
    }
}


