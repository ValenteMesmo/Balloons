using System.Collections.Generic;
using System.Linq;

namespace Balloons.Core
{
    public class FramerateCounter
    {
        private int totalFrames = 0;
        private float totalSeconds = 0.0f;
        private float currentFramesPerSecond = 0.0f;
        private const int MAXIMUM_SAMPLES = 10;
        private Queue<float> _sampleBuffer = new Queue<float>();

        public float averageFramesPerSecond { get; private set; } = 0.0f;

        public void Update(float deltaTime)
        {
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
        }
    }
}
