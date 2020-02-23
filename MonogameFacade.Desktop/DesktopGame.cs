using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonogameFacade
{
    public class DesktopGame : BaseGame
    {
        const double dt = 0.0166;
        double accumulator = 0.0;

        DateTime previousUpdate = DateTime.Now;

        public DesktopGame() : base(new DesktopContetLoader())
        {
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            IsFixedTimeStep = false;
            graphics.SynchronizeWithVerticalRetrace = false;
            InactiveSleepTime = new TimeSpan(0);
            graphics.PreferredBackBufferFormat = SurfaceFormat.HdrBlendable;
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            var currentUpdate = DateTime.Now;
            var delta = (currentUpdate - previousUpdate).TotalSeconds;
            if (delta > 0.25)
                delta = 0.25;
            previousUpdate = currentUpdate;

            accumulator = accumulator + delta;

            if (accumulator >= dt)
            {
                base.Update(gameTime);
                accumulator = accumulator - dt;
            }
            else
                SuppressDraw();

            FrameCounter.Update(accumulator);
        }
    }
}
