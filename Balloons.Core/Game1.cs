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
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            World.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

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
                    spriteBatch.Draw(
                        spriteData.texture
                        , spriteData.targetRectangle
                        , spriteData.sourceRectangle
                        , Color.White);

#if DEBUG
                spriteBatch.DrawString(
                      font
                      , World.Objects[i].ToString()
                      , new Vector2(World.Objects[i].X, World.Objects[i].Y)
                      , Color.Blue
                      , 0
                      , Vector2.Zero
                      , 5
                      , SpriteEffects.None
                      , 0
                  );
#endif
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
