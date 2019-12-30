namespace Balloons.Core
{
    public class BalloonFactory : GameObject
    {
        public BalloonFactory(World world)
        {
            Behavior = new CreateBalloonsOverTime(world);
        }
    }
}
