namespace Balloons.Core
{
    public class FrameCounter : GameObject
    {
        public FrameCounter(TextSprite sprite)
        {
            Behavior = new CalculatesFrameRate(sprite);
            Sprites.Add(sprite);
        }
    }
}
