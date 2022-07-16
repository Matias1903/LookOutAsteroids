using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spaceship
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D shipSprite;
        Texture2D asteroidsprite;
        Texture2D spaceSprite;
        SpriteFont gameFont;
        SpriteFont timerFont;

        Ship player = new Ship();
        Controller gameController = new Controller();
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            shipSprite = Content.Load<Texture2D>("ship");
            asteroidsprite = Content.Load<Texture2D>("asteroid");
            spaceSprite = Content.Load<Texture2D>("space");

            gameFont = Content.Load<SpriteFont>("spaceFont");
            timerFont = Content.Load<SpriteFont>("timerFont");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (gameController.inGame)
                player.Update(gameTime);


            gameController.Update(gameTime);

            for (int i = 0; i < gameController.asteroids.Count; i++)
            {
                gameController.asteroids[i].Update(gameTime);

                int sum = (int)gameController.asteroids[i].radius + player.radius;
                if (Vector2.Distance(gameController.asteroids[i].position, player.position) < sum)
                {
                    gameController.inGame = false;
                    player.position = Ship.defaultPos;
                    gameController.asteroids.Clear();
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(spaceSprite, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(shipSprite, new Vector2(player.position.X - 34, player.position.Y - 50), Color.White);

            for (int i = 0; i < gameController.asteroids.Count; i++)
            {
                _spriteBatch.Draw(asteroidsprite, new Vector2(gameController.asteroids[i].position.X - gameController.asteroids[i].radius, gameController.asteroids[i].position.Y - gameController.asteroids[i].radius), Color.White);
            }

            if (gameController.inGame == false)
            {
                string menuMessage = "Press 'Space' to begin!";
                Vector2 sizeOfText = gameFont.MeasureString(menuMessage);
                int halfWidth = _graphics.PreferredBackBufferWidth / 2;
                _spriteBatch.DrawString(gameFont, menuMessage, new Vector2(halfWidth - sizeOfText.X / 2, 200), Color.White);
            }

            _spriteBatch.DrawString(timerFont, $"Score: {Math.Floor(gameController.totalTime).ToString()}", new Vector2(10, 10), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
