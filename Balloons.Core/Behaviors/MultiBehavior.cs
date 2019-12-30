namespace Balloons.Core
{
    public class MultiBehavior : Behavior
    {
        private readonly Behavior[] Behaviors;

        public MultiBehavior(params Behavior[] Behaviors)
        {
            this.Behaviors = Behaviors;
        }

        public void Update()
        {
            for(var i = 0; i < Behaviors.Length; i++)
            {
                Behaviors[i].Update();
            }
        }
    }
}
