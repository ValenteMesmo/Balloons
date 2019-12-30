using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Balloons.Core
{
    public abstract class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        //public int Width { get; set; }
        //public int Height { get; set; }
        public bool Destroyed { get; private set; }

        public List<SpriteData> Sprites = new List<SpriteData>();

        protected Behavior Behavior { get; set; }

        public void Update()
        {
            if (Behavior != null)
                Behavior.Update();
        }

        public void Destroy()
        {
            Destroyed = true;
        }
    }
}
