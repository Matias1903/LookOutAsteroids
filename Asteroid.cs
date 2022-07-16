using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Spaceship
{
    class Asteroid
    {
        public Vector2 position;
        public float speed;
        public float radius = 59;

        public Asteroid(int speed)
        {
            this.speed = speed;
            Random rand = new Random();
            this.position = new Vector2(1280 + radius, rand.Next(0, 721));
        }

        public void Update(GameTime gameTime)
        {
            //Making the asteroid move.
            //Left every frame.

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position.X -= speed * deltaTime;
            
        }
    }
}