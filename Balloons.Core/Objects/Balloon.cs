using System;
using System.Collections.Generic;

namespace Balloons.Core
{

    public class Balloon : GameObject
    {
        public const int Idle = 0;
        public const int Dying = 1;

        public Balloon(
            TouchInputs inputs
            , SpriteData[] idle
            , SpriteData[] death)
        {
            var state = new ObjectState();
            var StateBehavior = new StateBasedBeavior(state);

            StateBehavior.Add(Idle, new MultiBehavior(
                new MoveUp(this),
                new KillOnTouch(this, inputs, state),
                new DestroyWhenOffScreen(this),
                new SpriteSheetAnimation(this, idle)
            ));

            StateBehavior.Add(Dying, new MultiBehavior(
                new SpriteSheetAnimation(this, death),
                new DestroyAfterDurationLimit(this, 10)
            ));

            Behavior = StateBehavior;
        }
    }

    public class ObjectState
    {
        public int Value { get; set; }
    }
    
    public class DestroyAfterDurationLimit : Behavior
    {
        private readonly int duration;
        private readonly GameObject obj;
        private int time = 0;

        public DestroyAfterDurationLimit(GameObject obj, int duration)
        {
            this.duration = duration;
            this.obj = obj;
        }

        public override void Update()
        {
            time++;
            if (time == duration)
                obj.Destroy();
        }
    }

    public class StateBasedBeavior : Behavior
    {
        private readonly Dictionary<int, MultiBehavior> Options =
            new Dictionary<int, MultiBehavior>();

        private readonly ObjectState State;

        public StateBasedBeavior(ObjectState State)
        {
            this.State = State;
        }

        public void Add(int stateValue, MultiBehavior behaviors)
        {
#if DEBUG
            if (Options.ContainsKey(stateValue))
                throw new Exception($"{nameof(StateBasedBeavior)} already have an {nameof(MultiBehavior)} for {nameof(ObjectState)} {stateValue}");
#endif
            Options.Add(stateValue, behaviors);
        }

        public override void Update()
        {
            var initialState = State.Value;
            var updates = Options[State.Value].Behaviors;

            for (var i = 0; i < updates.Length; i++)
            {
                updates[i].Update();

                if (initialState != State.Value)
                    break;
            }
        }
    }

}
