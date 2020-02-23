using Microsoft.Xna.Framework;

namespace MonogameFacade
{
    public class Block : GameObject
    {
        private SpriteRenderer texture;

        public Block(BaseGame game)
        {
            this.texture = new SpriteRenderer()
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
            game.Renderers.Add(texture);
        }
    }
}
