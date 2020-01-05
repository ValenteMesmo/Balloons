namespace Balloons.Core
{
    public class Balloon : GameObject
    {
        public Balloon(TouchInputs inputs, params SpriteData[] sprite)
        {
            Behavior = new MultiBehavior(
                new MoveUp(this) ,
                new DestroyedOnTouch(this, inputs),
                new DestroyWhenOffScreen(this),
                new SpriteSheetAnimation(this, sprite)
            );
        }
    }
}
