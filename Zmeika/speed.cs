using System;

namespace Zmeika
{
    class SpeedController
    {
        private int initialSpeed;
        private int speedIncrease;
        private int speedStep;
        private int currentSpeed;

        public SpeedController(int initialSpeed, int speedIncrease, int speedStep)
        {
            this.initialSpeed = initialSpeed;
            this.speedIncrease = speedIncrease;
            this.speedStep = speedStep;
            this.currentSpeed = initialSpeed;
        }

        public void IncreaseSpeed()
        {
            currentSpeed += speedIncrease;
        }

        public bool ShouldIncreaseSpeed(int foodCount)
        {
            return foodCount % speedStep == 0;
        }

        public int GetCurrentSpeed()
        {
            return currentSpeed;
        }

        public void UpdateSpeed(int foodCount)
        {
            if (ShouldIncreaseSpeed(foodCount))
            {
                IncreaseSpeed();
            }
        }
    }
}