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
* Class name : ControlsINfo
* Definition    : This class displyas the ControlsInfo of the game.
*/

namespace Gangsters
{
    public class ControlsInfo
    {

        public Image Image;

        public ControlsInfo()
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
        public void Update(GameTime gameTime) { 
        
            if (InputManager.Instance.KeyDown(Keys.M))
                Image.Alpha = 1.0f;
            else
                Image.Alpha = 0.0f;

            Image.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }

    }
}
