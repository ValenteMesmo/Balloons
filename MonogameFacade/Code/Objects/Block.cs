using Microsoft.Xna.Framework;

namespace MonogameFacade
{
    public class Block : GameObject
    {
        private DrawableTexture texture;

        public Block(BaseGame game)
        {
            this.texture = new DrawableTexture()
            {
                Texture = game.Texutes["btn_small"],
                Color = Color.White,
                Target = new Rectangle(0, 0, 10, 10)
            };
        }

        public override void Update(BaseGame game)
        {
            texture.Target.X = Position.X;
            texture.Target.Y = Position.Y;
            game.Drawables.Add(texture);
        }
    }
}
