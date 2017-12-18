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
    public class Background
    {
        Texture2D Image;
        Rectangle ScreenRectangle;

        public int imageWidth;
        public int imageHeight;

        public Vector2 imageCenter;


        public Background(ContentManager Content)
        {
            Image = Content.Load<Texture2D>("stars");
            ScreenRectangle = new Rectangle(0, 0, 1024, 768);
        }

        public void LoadContent()
        {

            imageWidth = Image.Width;
            imageHeight = Image.Height;

            imageCenter = new Vector2(imageWidth / 2, imageHeight / 2);


        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch sbatch)
        {
            sbatch.Draw(Image, ScreenRectangle, Color.White);


        }

    }
}
