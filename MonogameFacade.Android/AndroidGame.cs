using Android.Content.Res;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonogameFacade
{
    public class AndroidGame : BaseGame
    {
        public AndroidGame(AssetManager assets) : base(new AndroidContentLoader(assets))
        {
        }

        protected override void Initialize()
        {
            graphics.IsFullScreen = true;
            ////graphics.PreferredBackBufferWidth = 800;
            ////graphics.PreferredBackBufferHeight = 480;
            graphics.PreferredBackBufferFormat = SurfaceFormat.HdrBlendable;
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void Draw(GameTime gameTime)
        {
            //var currentUpdate = DateTime.Now;
            //var delta = (currentUpdate - previousUpdate).TotalSeconds;
            //previousUpdate = currentUpdate;

            FrameCounter.Update(gameTime.ElapsedGameTime.TotalSeconds);
            base.Draw(gameTime);
        }

        DateTime previousUpdate = DateTime.Now;
    }
}
