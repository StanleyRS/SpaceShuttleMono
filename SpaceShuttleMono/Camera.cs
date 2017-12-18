using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShuttleMono
{
    public class Camera
    {
        public Matrix transform;
        Viewport view;
        Vector2 centre;

        public Camera(Viewport viewNew)
        {
            view = viewNew;
        }

        public void Update(GameTime gameTime, Player shuttle)
        {
            centre = new Vector2(shuttle.rectangle.X + (shuttle.texture.Width / 2 - 510), shuttle.rectangle.Y + (shuttle.texture.Height / 2 - 650));
            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) *
                Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0));
        }



    }
}
