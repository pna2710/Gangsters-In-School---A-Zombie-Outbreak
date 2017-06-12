using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Gangsters
{
    public class ExitScreen : GameScreen
    {
      
        public Game1 game;

        public ExitScreen()
        {

        }

        public override void LoadContent()
        {
            base.LoadContent();
          

        }

        public override void UnloadContent()
        {
            base.UnloadContent();
         
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            game.Quit();


        }

        public override void Draw(SpriteBatch spriteBatch)
        {
          

        }
    }
}