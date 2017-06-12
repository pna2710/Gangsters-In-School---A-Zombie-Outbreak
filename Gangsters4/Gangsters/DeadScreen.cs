using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gangsters
{
    public class DeadScreen
    {
        public Image Image;


        public DeadScreen()
        {
            Image = new Image();
        }
        public void LoadContent()
        {
            Image.LoadContent();
        }
        public void UnloadContent()
        {
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            Image.Update(gameTime);
            if (InputManager.Instance.KeyPressed(Keys.Enter))
            {
                ScreenManager.Instance.ChangeScreens("TitleScreen");
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }
    }
}