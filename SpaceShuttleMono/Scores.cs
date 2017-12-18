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
    public class Scores
    {
        int Score;
        int HighScore;

        SpriteFont startingTextFont, scoresTextFont;
        public Scores(ContentManager Content)
        {
            startingTextFont = Content.Load<SpriteFont>("startingTextFont");
            scoresTextFont = Content.Load<SpriteFont>("scoresFont");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(scoresTextFont, "Score: " + Score, new Vector2(20, 30), Color.White);
            spriteBatch.DrawString(scoresTextFont, "HighScore: " + HighScore, new Vector2(850, 30), Color.White);
        }

    }
}
