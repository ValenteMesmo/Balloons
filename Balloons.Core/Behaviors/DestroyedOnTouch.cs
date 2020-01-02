using Microsoft.Xna.Framework;
using System;

namespace Balloons.Core
{
    public class DestroyedOnTouch : Behavior
    {
        private readonly TouchInputs inputs;
        private readonly GameObject obj;

        public DestroyedOnTouch(GameObject obj, TouchInputs inputs)
        {
            this.inputs = inputs;
            this.obj = obj;
        }

        public override void Update()
        {
            foreach(var touch in inputs.GetTouches())
            {
                if (new Rectangle(
                    obj.X
                    , obj.Y
                    , GameConstants.BalloonSize//obj.Width
                    , GameConstants.BalloonSize//obj.Height
                        + GameConstants.Speed * GameConstants.maxSpeed)
                    .Contains(touch))
                {
                    GameConstants.Speed += GameConstants.acceleration;
                    if (GameConstants.Speed > GameConstants.maxSpeed)
                        GameConstants.Speed = GameConstants.maxSpeed;

                    obj.Destroy();
                }
            }
        }

    }
}
