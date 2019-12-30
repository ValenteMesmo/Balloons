namespace Balloons.Core
{
    public class MoveUp : Behavior
    {
        private readonly GameObject obj;

        public MoveUp(GameObject obj)
        {
            this.obj = obj;
        }

        public void Update()
        {
            obj.Y -= GameConstants.Speed;
        }
    }
}
