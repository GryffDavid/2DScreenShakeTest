using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace _2DScreenShakeTest1
{    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        _2DCamera Camera;
        Texture2D BGTexture;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
        }

        protected override void Initialize()
        {
            Camera = new _2DCamera();
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            BGTexture = Content.Load<Texture2D>("Background");
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        
        protected override void UnloadContent()
        {
        }
        
        protected override void Update(GameTime gameTime)
        {
            Camera.Update(gameTime);
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, Camera.Transform);
                spriteBatch.Draw(BGTexture, BGTexture.Bounds, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
