using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Balloons.Core
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private World World;
        private SpriteFont font;
        private readonly ContentLoader contentLoader;

        public Game1(
            ContentLoader contentLoader
            , bool runningOnAndroid = false)
        {
            this.contentLoader = contentLoader;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            World = new World(
                new Camera(GraphicsDevice)
                {
                    position = new Vector2(1179.0f, 0.0f)
                }
                , contentLoader.LoadTextures(Content));

            font = Content.Load<SpriteFont>("Font");
            spriteBatch = new SpriteBatch(GraphicsDevice);

            World.AddObject(new BalloonFactory(World));
            World.AddObject(new FrameCounter(new TextSprite
            {
                Font = font,
                Position = new Vector2(100, -500)
            }));
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            World.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                null,
                null,
                null,
                null,
                World.camera.transform);

            for (var i = 0; i < World.Objects.Length; i++)
            {
                foreach (var spriteData in World.Objects[i].Sprites)
                    spriteData.Draw(spriteBatch);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
