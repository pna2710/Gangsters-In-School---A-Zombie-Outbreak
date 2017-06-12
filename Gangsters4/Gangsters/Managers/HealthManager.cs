using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gangsters
{
    public class HealthManager
    {
        public Image Image;
        //if Pçlayeur.isDead 
        public HealthManager()
        {
            
        }
        public void LoadContent(int i, Player p)
        {
            if (i == 0)
            {
                Image.Position = new Vector2(-25, -100);
            }
            else if (i == 1)
            {
                Image.Position = new Vector2(200, -100);
            }
            else if (i == 2)
            {
                Image.Position = new Vector2(425, -100);
            }
            else if (i == 3)
            {
                Image.Position = new Vector2(650, -100);
            }

            Image.Scale = new Vector2(0.7f, 0.7f);
            Image.LoadContent();
        }
        public void UnloadContent()
        {
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime, Player p, int i)
        {
            if (i == 0)
            {
                switch (p.Health1)
                {
                    case 1:
                        Image.HealthSprite.CurrentFrame = new Vector2(4, 0);
                        break;
                    case 2:
                        Image.HealthSprite.CurrentFrame = new Vector2(3, 0);
                        break;
                    case 3:
                        Image.HealthSprite.CurrentFrame = new Vector2(2, 0);
                        break;
                    case 4:
                        Image.HealthSprite.CurrentFrame = new Vector2(1, 0);
                        break;
                    case 5:
                        Image.HealthSprite.CurrentFrame = new Vector2(0, 0);
                        break;
                    default:
                        Image.HealthSprite.CurrentFrame = new Vector2(5, 0);
                        break;
                }
            }
            else if (i == 1)
            {
                switch (p.Health2)
                {
                    case 1:
                        Image.HealthSprite.CurrentFrame = new Vector2(4, 1);
                        break;
                    case 2:
                        Image.HealthSprite.CurrentFrame = new Vector2(3, 1);
                        break;
                    case 3:
                        Image.HealthSprite.CurrentFrame = new Vector2(2, 1);
                        break;
                    case 4:
                        Image.HealthSprite.CurrentFrame = new Vector2(1, 1);
                        break;
                    case 5:
                        Image.HealthSprite.CurrentFrame = new Vector2(0, 1);
                        break;
                    default:
                        Image.HealthSprite.CurrentFrame = new Vector2(5, 1);
                        break;
                }
            }
            else if (i == 2)
            {
                switch (p.Health3)
                {
                    case 1:
                        Image.HealthSprite.CurrentFrame = new Vector2(4, 2);
                        break;
                    case 2:
                        Image.HealthSprite.CurrentFrame = new Vector2(3, 2);
                        break;
                    case 3:
                        Image.HealthSprite.CurrentFrame = new Vector2(2, 2);
                        break;
                    case 4:
                        Image.HealthSprite.CurrentFrame = new Vector2(1, 2);
                        break;
                    case 5:
                        Image.HealthSprite.CurrentFrame = new Vector2(0, 2);
                        break;
                    default:
                        Image.HealthSprite.CurrentFrame = new Vector2(5, 2);
                        break;
                }
            }
            else if (i == 3)
            {
                switch (p.Health4)
                {
                    case 1:
                        Image.HealthSprite.CurrentFrame = new Vector2(4, 3);
                        break;
                    case 2:
                        Image.HealthSprite.CurrentFrame = new Vector2(3, 3);
                        break;
                    case 3:
                        Image.HealthSprite.CurrentFrame = new Vector2(2, 3);
                        break;
                    case 4:
                        Image.HealthSprite.CurrentFrame = new Vector2(1, 3);
                        break;
                    case 5:
                        Image.HealthSprite.CurrentFrame = new Vector2(0, 3);
                        break;
                    default:
                        Image.HealthSprite.CurrentFrame = new Vector2(5, 3);
                        break;
                }
            }
        

           


                Image.Update(gameTime);
            
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }
    }
}
