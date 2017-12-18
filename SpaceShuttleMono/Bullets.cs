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
using Microsoft.Xna.Framework.Media;

namespace SpaceShuttleMono
{
    public class Bullets
    {
        public Texture2D BulletSprite;
        public Rectangle BulletRectangle;


        public Bullets(Texture2D sprite, Rectangle rect)
        {
            BulletSprite = sprite;
            BulletRectangle = rect;
        }


        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(BulletSprite, BulletRectangle, Color.White);
        }



    }
}
