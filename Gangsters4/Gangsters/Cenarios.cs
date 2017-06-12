using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/**
* Class name : Cenarios()
* Definition    :
*/


namespace Gangsters
{
   public  class Cenarios
    {

        public Image Image;


        public Cenarios()
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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }

    }
}

