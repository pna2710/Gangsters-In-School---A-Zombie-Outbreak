using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gangsters
{
    public class Player
    {
        public Image Image;
        public Vector2 Velocity;
        public Rectangle rec;
        public float MoveSpeed;
        public int Attack = 1;
        public int Health1 = 5, Health2 = 5, Health3 = 5, Health4 = 5;
        public bool IsLookingRight = true, isAttacking = false, isDead = false;
        public int countat = 0;
        public int opcaopersonagem, i;
        //public Vector2 Rectangle = new Vector2(Image.Scale.X, Image.Scale.Y)


        public Player()
        {
            Velocity = Vector2.Zero;
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
            Image.IsActive = true;






            i = GameplayScreen.OpcaoPersona();

            if (Image.Position.X == -25)
            {
                Velocity.X = 0;
                
            }
            else if(Image.Position.X == 800)
            {
                Velocity.X = 0;
                
            }

            if (Velocity.X == 0)
            {
                if(IsLookingRight == true)
                {
                    Image.SpriteSheetEffect.CurrentFrame.Y = i + 2;
                    isAttacking = false;
                }
                else
                {
                    Image.SpriteSheetEffect.CurrentFrame.Y = i + 3;
                    isAttacking = false;
                }
                
            }
            
            if (InputManager.Instance.KeyDown(Keys.Space) && (InputManager.Instance.KeyDown(Keys.D)))
            {
                IsLookingRight = true;

                {
                    if (countat < 6)
                    {
                        Image.SpriteSheetEffect.CurrentFrame.Y = i + 4;
                        isAttacking = true;
                    }
                    else
                    {
                       
                        isAttacking = false;
                    }
                }
            }
            else if (InputManager.Instance.KeyDown(Keys.Space) && (InputManager.Instance.KeyDown(Keys.A)))
            {
                IsLookingRight = true;
                
                    if(countat < 6)
                    {
                        Image.SpriteSheetEffect.CurrentFrame.Y = i + 5;
                        isAttacking = true;
                    }
                    else
                    {
                        
                        isAttacking = false;
                    }
                
            }
            else if (InputManager.Instance.KeyDown(Keys.Space) && (IsLookingRight == true))
            {
                
                    if (countat < 6)
                    {
                        Image.SpriteSheetEffect.CurrentFrame.Y = i + 4;
                        isAttacking = true;
                    }
                    else
                    {
                        
                        isAttacking = false;
                    }
                
            }
            else if (InputManager.Instance.KeyDown(Keys.Space) && IsLookingRight == false)
            {
                
                    if (countat < 6)
                    {
                        Image.SpriteSheetEffect.CurrentFrame.Y = i + 5;
                        isAttacking = true;
                    }
                    else
                    {
                        
                        isAttacking = false;
                    }
                
            }


            if (InputManager.Instance.KeyDown(Keys.D))
            {
                IsLookingRight = true;
                if (!InputManager.Instance.KeyDown(Keys.Space))
                {
                    isAttacking = false;
                    if (Image.Position.X < 800)
                    {
                        Image.SpriteSheetEffect.CurrentFrame.Y = i + 0;
                        Velocity.X = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                    }
                    else
                    {
                        Velocity.X = 0;
                        Image.SpriteSheetEffect.CurrentFrame.Y = i + 2;

                    }
                }
                else
                {
                    Velocity.X = 0;


                    {
                        if (countat < 6)
                        {
                            Image.SpriteSheetEffect.CurrentFrame.Y = i + 4;
                            isAttacking = true;
                        }
                        else
                        {

                            isAttacking = false;
                        }
                    }


                }
            }

            else if (InputManager.Instance.KeyDown(Keys.A))
            {
                IsLookingRight = false;
                if (!InputManager.Instance.KeyDown(Keys.Space))
                {
                    isAttacking = false;
                    if (Image.Position.X > -25)
                    {
                        Image.SpriteSheetEffect.CurrentFrame.Y = i + 1;
                        Velocity.X = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                    else
                    {
                        Velocity.X = 0;
                        Image.SpriteSheetEffect.CurrentFrame.Y = i + 3;
                    }
                }
                else
                {
                    Velocity.X = 0;

                    if (countat < 6)
                    {
                        Image.SpriteSheetEffect.CurrentFrame.Y = i + 5;
                        isAttacking = true;
                    }
                    else
                    {

                        isAttacking = false;
                    }
                }
            
            }
            else
            {
                Velocity.X = 0;

            }

            if (Health1 <= 0 || Health2 <= 0 || Health3 <= 0 || Health4 <= 0)
            {
                isDead = true;
            }

            countat++;
            if (countat >= 6) countat = 0;
            Image.Position += Velocity * 3 / 2;
            Image.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }
    }
}
