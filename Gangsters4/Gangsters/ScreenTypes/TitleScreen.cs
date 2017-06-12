using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Gangsters
{
    public class TitleScreen:GameScreen
    {
        MenuManager menuManager;
        Cenarios Fundo;
        private Song song;
        private SoundEffect switch_sound;
        // Image buttonStart;
        // Image buttonExit;

        public TitleScreen()
        {
            menuManager = new MenuManager();

        }

        public override void LoadContent()
        {

            base.LoadContent();
            
            XmlManager<Cenarios> CenariosLoader = new XmlManager<Cenarios>();
           // XmlManager<Image> buttonStartLoader = new XmlManager<Image>();
           // XmlManager<Image> buttonsExitLoader = new XmlManager<Image>();
            song = content.Load<Song>("Creditos");
            switch_sound = content.Load<SoundEffect>("switchSound");
            MediaPlayer.Volume = 0.1f;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(song);
           // buttonStart = new Image();
            //    buttonExit = new Image();
            Fundo = CenariosLoader.Load("Content/Load/Intro.xml");
            menuManager.LoadContent("Content/Load/TitleMenu.xml");

            Fundo.LoadContent();
           // buttonStart.LoadContent();
           // buttonExit.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            menuManager.UnloadContent();
            Fundo.UnloadContent();
            //buttonStart.UnloadContent();
           // buttonExit.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
       

            base.Update(gameTime);

            if (InputManager.Instance.KeyPressed(Keys.Up, Keys.Down))
                    switch_sound.Play(0.1f, 0, 0);

            Fundo.Update(gameTime);
            menuManager.Update(gameTime);
            // buttonStart.Update(gameTime);
            //  buttonExit.Update(gameTime);
          

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            Fundo.Draw(spriteBatch);
            menuManager.Draw(spriteBatch);
         //   buttonStart.Draw(spriteBatch);
          //  buttonExit.Draw(spriteBatch);


        }


    }
}
