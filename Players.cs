using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BadBadWolfEngine;
using BadBadWolfEngine.Controlls;

namespace BadBadWolfEngine.Entities
{
    public class Ball
    {
        private Texture2D ballTexture;
        private Vector2 ballPosition;
        private Vector2 ballSpeed;

        private bool facingRight;
        Microsoft.Xna.Framework.Graphics.SpriteEffects textureDirection;

        public Ball()
        {
            ballPosition = new Vector2(TestGame.windowWidth / 2,
                                       TestGame.windowHeight / 2);
            ballSpeed =new Vector2(500f, 500f);

            facingRight = true;
            textureDirection = SpriteEffects.None;
        }

        public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            ballTexture = Content.Load<Texture2D>("ball");
        }

        public void Update(Controller myController, float elapedSec)
        {
            if (myController.inputUp.getState()) ballPosition.Y -= ballSpeed.Y * elapedSec;
            if (myController.inputDown.getState()) ballPosition.Y += ballSpeed.Y * elapedSec;

            if (ballPosition.Y > TestGame.windowHeight + ballTexture.Height / 2){
                ballPosition.Y = - ballTexture.Height / 2;            
            }
            else if (ballPosition.Y < - ballTexture.Height / 2){
                ballPosition.Y = TestGame.windowHeight + ballTexture.Height / 2;
            }

            if (myController.inputLeft.getState()) 
            {
                ballPosition.X -= ballSpeed.X * elapedSec;
                if (facingRight)
                {
                    facingRight = false;
                    textureDirection = SpriteEffects.FlipHorizontally;
                }
            }
            if (myController.inputRight.getState())
            {
                ballPosition.X += ballSpeed.X * elapedSec;
                if (!facingRight)
                {
                    facingRight = true;
                    textureDirection = SpriteEffects.None;
                }
            }
            if (ballPosition.X > TestGame.windowWidth + ballTexture.Width / 2){
                ballPosition.X = - ballTexture.Width / 2;            
            }
            else if (ballPosition.X < -ballTexture.Width / 2){
                ballPosition.X = TestGame.windowWidth + ballTexture.Width / 2;
            }
        } 

        public void Draw(SpriteBatch _spriteBatch)
        {
            /*spriteBatch.Draw(): Example
            
            spriteBatch.Draw(
            texture: yourTexture,                     // Texture2D of your sprite
            position: new Vector2(100, 100),          // Position on the screen
            sourceRectangle: null,                    // Full texture (no source rectangle)
            color: Color.White,                       // No color tint
            rotation: 0f,                             // No rotation
            origin: Vector2.Zero,                     // No origin offset
            scale: 1.0f,                              // Original scale
            effects: SpriteEffects.FlipHorizontally,  // Flip the sprite horizontally
            layerDepth: 0f                            // Default layer depth
    );
            */
            _spriteBatch.Draw(ballTexture,
                              ballPosition,
                              null,
                              Color.White,
                              0f,
                              new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
                              Vector2.One,
                              textureDirection,
                              1.0f
                             );
        }
    }

    public class Block
    {
        private Texture2D blockTexture;
        private Vector2 blockPosition;

        public Block(float x, float y)
        {
            blockPosition = new Vector2(x + TestGame.windowWidth / 2,
                                        y + TestGame.windowHeight / 2);
        }

        public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            blockTexture = Content.Load<Texture2D>("block");
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
        _spriteBatch.Draw(blockTexture,
                          blockPosition,
                          Color.White
                          );
        }
    }
}