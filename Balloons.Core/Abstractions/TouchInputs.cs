using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Balloons.Core
{
    public interface TouchInputs
    {
        public IEnumerable<Vector2> GetTouches();
    }
}
