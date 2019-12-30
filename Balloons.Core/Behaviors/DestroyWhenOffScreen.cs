namespace Balloons.Core
{
    public class DestroyWhenOffScreen : Behavior
    {
        private readonly GameObject obj;

        public DestroyWhenOffScreen(GameObject obj)
        {
            this.obj = obj;
        }

        public void Update()
        {
            if (obj.Y < -1200)
            {
                GameConstants.Speed -= GameConstants.breakSpeed;

                if (GameConstants.Speed < GameConstants.minSpeed)
                    GameConstants.Speed = GameConstants.minSpeed;

                obj.Destroy();
            }
        }
    }
}
