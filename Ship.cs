using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spaceship
{
    class Ship
    {
        public static Vector2 defaultPos = new Vector2(640, 360);
        public Vector2 position = defaultPos;
        public float speed = 300;
        public int radius = 32;

        public void Update(GameTime gameTime)
        {
            Movement(gameTime);
        }

        private void Movement(GameTime gameTime)
        {
            KeyboardState kState = Keyboard.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kState.IsKeyDown(Keys.D) && position.X < 1280 - radius)
            {
                position.X += speed * deltaTime;
            }
            if (kState.IsKeyDown(Keys.A) && position.X > 0 + radius)
            {
                position.X -= speed * deltaTime;
            }
            if (kState.IsKeyDown(Keys.W) && position.Y > 0 + radius)
            {
                position.Y -= speed * deltaTime;
            }
            if (kState.IsKeyDown(Keys.S) && position.Y < 720 - radius)
            {
                position.Y += speed * deltaTime;
            }
        }
    }
}
