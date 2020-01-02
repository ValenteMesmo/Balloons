using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Balloons.Core
{
    public abstract class TouchInputs
    {
        public abstract IEnumerable<Vector2> GetTouches();
    }
}
