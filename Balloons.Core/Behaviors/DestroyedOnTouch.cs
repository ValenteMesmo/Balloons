using Microsoft.Xna.Framework;
using System;

namespace Balloons.Core
{
    public class KillOnTouch : Behavior
    {
        private readonly TouchInputs inputs;
        private readonly GameObject obj;
        private readonly ObjectState state;

        public KillOnTouch(GameObject obj, TouchInputs inputs, ObjectState state)
        {
            this.inputs = inputs;
            this.obj = obj;
            this.state = state;
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

                    state.Value = Balloon.Dying;
                }
            }
        }

    }
}
