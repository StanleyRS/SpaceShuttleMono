using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SpaceShuttleMono
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont newFont;

        Player Player;
        Background Image;

        Rectangle EnemyRectangle;
        Texture2D Enemy;

        Asteroid asteroid;
        List<Asteroid> enemies = new List<Asteroid>();

        //Camera camera;

        Random rand = new Random();
        int pick;
        int randomY, randomX;
        int delay = 0;
        int hitsCount = 0;

        int randomTextX, randomTextY;

        float fallVelocity = 0.9f;


        bool playerShot = true;


        // Game states 
        enum GameState
        {
            Starting,
            Playing,
            Finished
        };
        GameState currentGameState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //camera = new Camera(GraphicsDevice.Viewport);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Player = new Player();
            Image = new Background(this.Content);

            newFont = Content.Load<SpriteFont>("scoresFont");

            Player.LoadContent(this.Content);

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            Player.Update();

            Image.Update();

            UpdateEnemies(gameTime);

            //camera.Update(gameTime, Player);

            base.Update(gameTime);
         }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transform);

            spriteBatch.Begin();

            Image.Draw(spriteBatch);

            randomTextX = rand.Next(100, 800);
            randomTextY = rand.Next(100, 800);

            if (Player.CollisionCheck(Player, asteroid))
            {
                //Player.Draw(spriteBatch);

                spriteBatch.DrawString(newFont, "YOU GOT HIT, COVEERR!!!!!!", new Vector2(randomTextX, randomTextY), Color.White);


            }
            else
            {
                Player.Draw(spriteBatch);
            }


            foreach (Asteroid enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);

        }


        // Some self declared methods


        #region Methods

        private void UpdateEnemies(GameTime gameTime)
        {
            pick = rand.Next(1, 4);

            randomX = rand.Next(10, 900);
            randomY = rand.Next(-10, 0);

            switch (pick)
            {
                case 1:
                    Enemy = Content.Load<Texture2D>("asteroidSMALL");
                    break;
                case 2:
                    Enemy = Content.Load<Texture2D>("asteroidMEDIUM");
                    break;
                case 3:
                    Enemy = Content.Load<Texture2D>("asteroidLARGE");
                    break;
                default:
                    break;
            }

            //if (currentGameState == GameState.Playing)
            //{
            if (delay < 0)
            {
                EnemyRectangle = new Rectangle(randomX, randomY, Enemy.Width, Enemy.Height);

                asteroid = new Asteroid(Enemy, new Vector2(randomX, randomY), EnemyRectangle);
                enemies.Add(asteroid);

                delay = 500;
            }
            else
            {
                delay--;
            }

            foreach (Asteroid e in enemies)
            {
                e.asteroidPosition.Y += fallVelocity;

                Player.CollisionCheck(Player, e);

            }

            

            //}
        }






        private void PlayerCollisionCheck(Player player, Asteroid enemy)
        {
            if (CollisionCheck(player, enemy))
                hitsCount++;

            if (hitsCount.Equals(3))
                playerShot = true;


        }

        public bool CollisionCheck(Player player, Asteroid enemy)
        {
            if (player.rectangle.Intersects(enemy.asteroidRectangle))
            {
                return true;
            }
            return false;
        }





        /* public void GameStart(GameTime gameTime)
         {

             currentKeyboardState = Keyboard.GetState();


             if (currentKeyboardState.GetPressedKeys().Length > 0 && currentGameState.Equals(GameState.Starting))
             {
                 currentGameState = GameState.Playing;
             }

             previousKeyBoardState = currentKeyboardState;

             base.Update(gameTime);
         }*/

        #endregion

    }
}
