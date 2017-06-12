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
    public class SplashScreen : GameScreen
    {
        public Image Image;
        Cenarios pressEnter;


        public SplashScreen()
            {

        }

        public override void LoadContent()
        {
            base.LoadContent();
            XmlManager<Cenarios> EnterLoader = new XmlManager<Cenarios>();
            pressEnter = EnterLoader.Load("Content/Load/pressEnter.xml");
            Image.LoadContent();
            pressEnter.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            Image.UnloadContent();
            pressEnter.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Image.Update(gameTime);
            pressEnter.Update(gameTime);

            if (InputManager.Instance.KeyPressed(Keys.Enter, Keys.Z))
                ScreenManager.Instance.ChangeScreens("TitleScreen");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
            pressEnter.Draw(spriteBatch);
        }
    }
}