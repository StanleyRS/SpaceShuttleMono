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
    public class Asteroid
    {
        public Texture2D asteroidSprite;
        public Vector2 asteroidPosition;
        public Rectangle asteroidRectangle;

        Random rand = new Random();

        public Asteroid(Texture2D texture, Vector2 pos, Rectangle rect)
        {
            asteroidSprite = texture;
            asteroidPosition = pos;
            asteroidRectangle = rect;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(asteroidSprite, asteroidPosition, Color.White);
        }





    }
}
