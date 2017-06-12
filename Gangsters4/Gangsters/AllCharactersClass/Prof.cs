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
    public class Prof
    {
        public Image Image;
        public Vector2 Velocity;
        public Rectangle rec;
        public float MoveSpeed;
        public bool IsLookingRight = true, isDead = false;
        public int speedreducer;
        Random PositionRandom = new Random();
        Random SpeedRandom = new Random();
        public bool qwestDelivered;
        public bool asStoped;


        public Prof()
        {
            Velocity = Vector2.Zero;
        }





        public void LoadContent(int speedreducer)
        {
           
            this.speedreducer = speedreducer;
            Image.Position.Y = 292;
            Image.Position.X = -120;
            Image.LoadContent();
        }
        public void UnloadContent()
        {
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime, ref Image PlayerImage)
        {

            Image.IsActive = true;

            Vector2 PlayerPosition = PlayerImage.Position;
            //Player.Image.Position.X < Image.Position.X

            if (qwestDelivered == false)
            {

                if (PlayerPosition.X - 75 > Image.Position.X)
                {
                    Image.SpriteSheetEffect.CurrentFrame.Y = 0;
                    MoveSpeed = 150;
                    Velocity.X = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                else
                    Velocity.X = 0;
                // Image.SpriteSheetEffect.CurrentFrame.Y = 0;

                if (Velocity.X == 0)
                {
                    qwestDelivered = true;
                    Image.SpriteSheetEffect.CurrentFrame.Y = 1;
                }
                //  Image.IsActive = false;
            }
            else
                Image.SpriteSheetEffect.CurrentFrame.Y = 1;


            Image.Update(gameTime);
            Image.Position += Velocity / speedreducer;
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }
    }
}


