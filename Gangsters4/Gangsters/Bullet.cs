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
    public class Bullet
    {
    }
}
 /*       public Image Image;
        public Texture2D Texture;
        public Vector2 Velocity;
        private Vector2 bulletTarget;
        public Vector2 bulletPosition;
        public bool isActive;
        private float moveSpeed;
        public Rectangle rec;

        //public Vector2 Rectangle = new Vector2(Image.Scale.X, Image.Scale.Y)


        public Bullet()
        {
            Velocity = Vector2.Zero;
        }

        public void ActivateBullet(Vector2 point, Vector2 center, Texture2D texture)
        {
            bulletTarget = point;
            bulletPosition = center;
            Texture = texture;
            moveSpeed = 200;
            isActive = true;
            SetVelocity();
        }
        private void SetVelocity()
        {
            Velocity = -(bulletPosition - bulletTarget);
            Velocity.Normalize();
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

public void Update(GameTime gameTime)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (bulletPosition.Y < -30)
                isActive = false;
            if (bulletPosition.X < -30 || bulletPosition.X > 600)
                isActive = false;
            bulletPosition += (Velocity * moveSpeed * elapsedTime);
            rec = new Rectangle((int)bulletPosition.X, (int)bulletPosition.Y, Texture.Width, Texture.Height);
            HandleCollisions();
        
        }
        public void Draw(SpriteBatch spriteBatch)
        {

                spriteBatch.Draw(Texture, bulletPosition, null, color, rotation, new Vector2(Texture.Width / 2, Texture.Height / 2), 1.0f, SpriteEffects.None, 0f);
            }


public void Kill()
        {
            isActive = false;
           // Image.Draw(spriteBatch);
        }
    }
}
*/