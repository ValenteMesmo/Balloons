using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameFacade;
using System;
using System.Collections.Generic;

namespace MonogameFacade
{
    public abstract class BaseGame : Game
    {
        public FrameCounter FrameCounter = new FrameCounter();
        public Bag<GameObject> Objects = new Bag<GameObject>(100 * 100 * 10);
        public Bag<Renderer> Renderers = new Bag<Renderer>(100 * 100 * 10);
        //public List<Renderer> RenderersWithEffect1 = new List<Renderer>();

        private readonly ContentLoader contentLoader;
        private readonly Camera Camera;

        protected GraphicsDeviceManager graphics;
        public Dictionary<string, Texture2D> Texutes { get; private set; }

        private SpriteBatch spriteBatch;
        public SpriteFont font;

        public BaseGame(ContentLoader contentLoader)
        {
            this.contentLoader = contentLoader;

            this.Camera = new Camera();
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;            
        }

        protected override void LoadContent()
        {
            Texutes = contentLoader.LoadTextures(Content);

            font = Content.Load<SpriteFont>("font");
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            Renderers.Clear();

            for (int i = 0; i < Objects.Count; i++)
                Objects[i].Update(this);

            Camera.Update(GraphicsDevice);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                null,
                null,
                null,
                null,
                Camera.transform);

            for (var i = 0; i < Renderers.Count; i++)
                Renderers[i].Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
