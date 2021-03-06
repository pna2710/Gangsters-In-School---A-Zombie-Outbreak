﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Gangsters
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

       // bool videoend;
        public Image Image;
        Video Vid;
        VideoPlayer vidPlayer;
        //Vector2 Position, Scale;
        //Rectangle SourceRect;
        Texture2D vidTexture;
        Rectangle vidRectangle;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);


            Content.RootDirectory = "Content";
        }

        public void Quit()
        {
            this.Exit();
                
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = (int)Gangsters.ScreenManager.Instance.Dimensions.X;
            graphics.ApplyChanges();
            base.Initialize();




        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            Vid = Content.Load<Video>("3");
           
            vidRectangle = new Rectangle(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
          
            vidPlayer = new VideoPlayer();
            vidPlayer.Play(Vid);
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ScreenManager.Instance.GraphicsDevice = GraphicsDevice;
            ScreenManager.Instance.SpriteBatch = spriteBatch;
            ScreenManager.Instance.LoadContent(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            ScreenManager.Instance.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {


            if (vidPlayer.State != MediaState.Stopped)
            {
                if (InputManager.Instance.KeyPressed(Keys.Enter, Keys.Z))
                    vidPlayer.Stop();
            }


            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            ScreenManager.Instance.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

           
GraphicsDevice.Clear(Color.Black);



            spriteBatch.Begin();
            if (vidPlayer.State != MediaState.Stopped)
            {
                
                vidTexture = vidPlayer.GetTexture();

                

                if (vidTexture != null)
                    spriteBatch.Draw(vidTexture, GraphicsDevice.Viewport.Bounds, Color.White);
                //vidTexture = vidPlayer.GetTexture();
            }


            if (vidPlayer.State == MediaState.Stopped)

            {
                ScreenManager.Instance.Draw(spriteBatch);

            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}