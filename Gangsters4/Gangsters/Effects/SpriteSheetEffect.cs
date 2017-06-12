//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;


namespace Gangsters
{
    public class SpriteSheetEffect : ImageEffect
    {
        public int FrameCounter;
        public int SwitchFrame;
        public Vector2 CurrentFrame;
        public Vector2 AmountOfFrames;
        protected readonly Rectangle gameBoundries;
        public float elaps;
        public float delay = 200f;


        


        public SpriteSheetEffect()
        {


                AmountOfFrames = new Vector2(3, 24);
                CurrentFrame = new Vector2(0, 0);
                SwitchFrame = 100;
                FrameCounter = 0;
           
          
        }

        public int FrameWidth
        {
            get
            {
                if (image.Texture != null)
                    return image.Texture.Width / (int)AmountOfFrames.X;
                return 0;
            }
        }
        public int FrameHeight
        {
            get
            {
                if (image.Texture != null)
                    return image.Texture.Height / (int)AmountOfFrames.Y;
                return 0;
            }
        }


        //limite para as colisoes
        public Rectangle BoudingBox
        {
            get
               {
                return new Rectangle((int)CurrentFrame.X, (int)CurrentFrame.Y, FrameWidth, FrameHeight);
                }
                
        }

        public override void LoadContent(ref Image Image)
        {
            base.LoadContent(ref Image);
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (image.IsActive)
            {
                FrameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (FrameCounter >= SwitchFrame)
                    {
                        FrameCounter = 0;
                        CurrentFrame.X++;

                        if (CurrentFrame.X * FrameWidth >= image.Texture.Width)
                            CurrentFrame.X = 0;
                    }
                }
            else
                CurrentFrame.X = 1;

            image.SourceRect = new Rectangle((int)CurrentFrame.X * FrameWidth,
                (int)CurrentFrame.Y * FrameHeight, FrameWidth, FrameHeight);
            }
        }
    }



