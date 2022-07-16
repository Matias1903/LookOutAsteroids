using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spaceship
{
    class Controller
    {
        public List<Asteroid> asteroids = new List<Asteroid>();
        public double timer = 2;
        public double maxTime = 2;
        public int nextSpeed = 300;
        public bool inGame = false;
        public double totalTime = 0;


        public void Update(GameTime gameTime)
        {
            if (inGame)
            {
                AsteroidLogic(gameTime);
                IncreaseTimer(gameTime);
            }
            else
                StartGame();


        }

        public void AsteroidLogic(GameTime gameTime)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds;

            if (timer <= 0)
            {
                asteroids.Add(new Asteroid(nextSpeed));
                TimerReset();
                IncreaseSpawnRate();
                IncreaseSpeed();
            }
        }
        public void StartGame()
        {
            KeyboardState kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.Space))
            {
                inGame = true;
                totalTime = 0;
                timer = 2;
                maxTime = 2;
                nextSpeed = 300;
            }
        }

        private void TimerReset()
        {
            timer = maxTime;
        }

        private void IncreaseSpawnRate()
        {
            if (maxTime > 0.35)
            {
                maxTime -= 0.1;
            }
        }

        private void IncreaseSpeed()
        {
            if (nextSpeed < 950)
            {
                nextSpeed += 4;
            }
        }

        private void IncreaseTimer(GameTime gameTime)
        {
            totalTime += gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}