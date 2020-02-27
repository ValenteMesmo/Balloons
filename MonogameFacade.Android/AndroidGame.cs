using Android.Content.Res;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
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

        protected override void Update(GameTime gameTime)
        {
            var state = TouchPanel.GetState();

            Touches.Clear();
            for (int i = 0; i < state.Count; i++)
            {
                if (state[i].State > 0)
                    Touches.Add(Camera.GetWorldPosition(state[i].Position));
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            FrameCounter.Update(gameTime.ElapsedGameTime.TotalSeconds);
            base.Draw(gameTime);
        }
    }
}
