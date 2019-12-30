namespace Balloons.Core
{
    public class Balloon : GameObject
    {
        public Balloon(SpriteData sprite, TouchInputs inputs)
        {
            Behavior = new MultiBehavior(
                new MoveUp(this) ,
                new DestroyedOnTouch(this, inputs),
                new DestroyWhenOffScreen(this),
                new SingleTextureAnimation(this, sprite)
            );
        }
    }
}
