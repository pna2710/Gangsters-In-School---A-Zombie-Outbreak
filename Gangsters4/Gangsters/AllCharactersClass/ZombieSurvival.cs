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
    public class ZombieSurvival
    {
        public Image Image;
        public Vector2 Velocity;
        public Rectangle rec;
        public Vector2 position;
        public float MoveSpeed;
        public int Health = 2;
        public int Attack = 1;
        public bool IsLookingRight = true, isDead = false, isVisible= true;
        public int opcaozombie, i;
        public int speedreducer;
        Random PositionRandom = new Random();
        Random SpeedRandom = new Random();
        public float speedlvl;
        Random speed = new Random();
        //public int numerZombies  = 10;
            


        public ZombieSurvival()
        {
         
            Velocity = Vector2.Zero;
        }





        public void LoadContent(int opcao, int speedreducer)
        {
            switch (opcao)
            {
                case 1:
                    this.opcaozombie = 0;
                    break;
                case 2:
                    this.opcaozombie = 2;
                    break;
                case 3:
                    this.opcaozombie = 4;
                    break;
                case 4:
                    this.opcaozombie = 6;
                    break;
                case 5:
                    this.opcaozombie = 8;
                    break;
            }
            this.speedreducer = speedreducer;
            Image.Position.Y = 292;
            Image.Position.X = 910;

                
                Image.LoadContent();
        }
        public void UnloadContent()
        {
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime, ref Image PlayerImage)
        {

            Image.IsActive = true;

            i = this.opcaozombie;

            Vector2 PlayerPosition = PlayerImage.Position;
            //Player.Image.Position.X < Image.Position.X

            if (PlayerPosition.X - 75 > Image.Position.X)
            {
                Image.SpriteSheetEffect.CurrentFrame.Y = i + 1;
                speedlvl = speed.Next(1, 3);
                if (speedlvl == 1)
                    MoveSpeed = SpeedRandom.Next(50, 100);
                else if (speedlvl == 2)
                    MoveSpeed = SpeedRandom.Next(200, 250);
                else if (speedlvl == 3)
                {
                    MoveSpeed = SpeedRandom.Next(300, 400);
                }

                Velocity.X = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (PlayerPosition.X + 75 < Image.Position.X)
            {
                Image.SpriteSheetEffect.CurrentFrame.Y = i + 0;
                Velocity.X = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            else
            {
                Velocity.X = 0;
            }
            if (Velocity.X == 0)
                Image.IsActive = false;

            if (Health <= 0)
            {
                Image.SpriteSheetEffect.CurrentFrame.Y = 10;
                isDead = true;

            }

            Image.Position += Velocity / speedreducer;
            Image.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }
    }
}

