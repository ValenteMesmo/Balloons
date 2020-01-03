using System;
using System.Collections.Generic;
using System.Linq;

namespace Balloons.Core
{
    public class CalculatesFrameRate : Behavior
    {
        private int totalFrames = 0;
        private float totalSeconds = 0.0f;
        private float currentFramesPerSecond = 0.0f;
        private const int MAXIMUM_SAMPLES = 10;
        private readonly TextSprite TextSprite;
        private Queue<float> _sampleBuffer = new Queue<float>();

        private DateTime LastUpdate;      

        public float averageFramesPerSecond { get; private set; } = 0.0f;

        public CalculatesFrameRate(TextSprite TextSprite)
        {
            this.TextSprite = TextSprite;
        }

        public override void Update()
        {
            var currentUpdate = DateTime.Now;
            var deltaTime = (float)(currentUpdate - LastUpdate).TotalSeconds;
            currentFramesPerSecond = 1.0f / deltaTime;

            _sampleBuffer.Enqueue(currentFramesPerSecond);

            if (_sampleBuffer.Count > MAXIMUM_SAMPLES)
            {
                _sampleBuffer.Dequeue();
                averageFramesPerSecond = _sampleBuffer.Average(i => i);
            }
            else
                averageFramesPerSecond = currentFramesPerSecond;

            totalFrames = totalFrames + 1;
            totalSeconds = totalSeconds + deltaTime;

            TextSprite.Text = averageFramesPerSecond.ToString();

            LastUpdate = currentUpdate;
        }
    }
}
