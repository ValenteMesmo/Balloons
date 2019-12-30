using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Balloons.Core
{
    public interface ContentLoader
    {
        Dictionary<string, Texture2D> LoadTextures(ContentManager value);
    }
}
