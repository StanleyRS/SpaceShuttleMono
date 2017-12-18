using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SpaceShuttleMono
{
    public class Player
    {
        Bullets Bullet;
        List<Bullets> bullets = new List<Bullets>();

        public Texture2D bulletTexture;
        public Texture2D texture;
        public Rectangle rectangle;

        public bool isShooting = false;
        public bool hasCollided = false;

        int playerMovement = 4;

        int bulletVelocity = 3;

        int delay = 0;

        // Constructor
        public Player()
        {

        }

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("shuttle");
            rectangle = new Rectangle(440, 540, texture.Width, texture.Height);

            bulletTexture = Content.Load<Texture2D>("weaponBLUE");

        }

        public void Update()
        {

            PlayerMove(); 
            PlayerShoot();



        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);

            foreach (Bullets b in bullets)
            {      
                b.Draw(spriteBatch);
            }
        }


        public void PlayerMove()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                rectangle.Y -= playerMovement;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                rectangle.Y += playerMovement;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                rectangle.X += playerMovement;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                rectangle.X -= playerMovement;
            }

        }

        public void PlayerShoot()
        {
            if (delay > 6)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    Bullet = new Bullets(bulletTexture, new Rectangle(rectangle.Location.X + 65, rectangle.Location.Y - 20, bulletTexture.Width, bulletTexture.Height));
                    bullets.Add(Bullet);

                    isShooting = true;
                }
                delay = 0;
            }
            else
            {
                delay++;
            }
            UpdateBullets();
        }

        public void UpdateBullets()
        {
            if (isShooting)
            {
                foreach (Bullets bullet in bullets)
                {
                    bullet.BulletRectangle.Y -= bulletVelocity;

                    // bullet check coliision
                }
            }

        }
    }
}
