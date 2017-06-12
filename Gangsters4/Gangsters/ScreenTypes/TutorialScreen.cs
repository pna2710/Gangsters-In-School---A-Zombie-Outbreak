﻿using System;
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
    public class TutorialScreen : GameScreen
    {
        public Image Image;


        public TutorialScreen()
        {

        }

        public override void LoadContent()
        {
            base.LoadContent();
            Image.LoadContent();

        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            Image.UnloadContent();

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Image.Update(gameTime);
  

            if (InputManager.Instance.KeyPressed(Keys.Enter))
                ScreenManager.Instance.ChangeScreens("TitleScreen");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);

        }
    }
}