namespace Balloons.Core
{
    public class MultiBehavior : Behavior
    {
        public readonly Behavior[] Behaviors;

        public MultiBehavior(params Behavior[] Behaviors)
        {
            this.Behaviors = Behaviors;
        }

        public override void Update()
        {
            for(var i = 0; i < Behaviors.Length; i++)
            {
                Behaviors[i].Update();
            }
        }
    }
}
