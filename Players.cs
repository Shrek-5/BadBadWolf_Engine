using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BadBadWolfEngine;
using BadBadWolfEngine.Controlls;

namespace BadBadWolfEngine.Entities
{
    public class Ball
    {
        private Texture2D texture;
        private Vector2 position;
        public Vector2 speed;

        public int notColliding;

        private bool facingRight;
        Microsoft.Xna.Framework.Graphics.SpriteEffects textureDirection;

        public Rectangle HitBox => new Rectangle((int)(position.X - texture.Width / 2),
                                                 (int)(position.Y - texture.Height / 2),
                                                 texture.Width,
                                                 texture.Height
                                                );

        public Ball()
        {
            position = new Vector2((TestGame.windowWidth / 2) - 32,
                                       (TestGame.windowHeight / 2) - 32);
            speed =new Vector2(500f, 500f);

            facingRight = true;
            textureDirection = SpriteEffects.None;
            notColliding = 1;
        }

        public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            texture = Content.Load<Texture2D>("ball");
        }

        public void Update(Controller myController, float elapedSec)
        {
            if (myController.inputUp.getState())
                position.Y -= speed.Y * elapedSec * notColliding;
            if (myController.inputDown.getState())
                position.Y += speed.Y * elapedSec * notColliding;

            if (position.Y > TestGame.windowHeight + texture.Height / 2)
                position.Y = - texture.Height / 2;            
            else if (position.Y < - texture.Height / 2)
                position.Y = TestGame.windowHeight + texture.Height / 2;

            if (myController.inputLeft.getState()) 
            {
                position.X -= speed.X * elapedSec * notColliding;
                if (facingRight)
                {
                    facingRight = false;
                    textureDirection = SpriteEffects.FlipHorizontally;
                }
            }
            if (myController.inputRight.getState())
            {
                position.X += speed.X * elapedSec * notColliding;
                if (!facingRight)
                {
                    facingRight = true;
                    textureDirection = SpriteEffects.None;
                }
            }
            if (position.X > TestGame.windowWidth + texture.Width / 2)
                position.X = - texture.Width / 2;            
            else if (position.X < -texture.Width / 2)
                position.X = TestGame.windowWidth + texture.Width / 2;
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
            _spriteBatch.Draw(texture,
                              position,
                              null,
                              Color.White,
                              0f,
                              new Vector2(texture.Width / 2, texture.Height / 2),
                              Vector2.One,
                              textureDirection,
                              1.0f
                             );
        }

        public void UpdateBallState(List<Block> blocks)
        {
            // Check for collisions between the ball and each block
            foreach (var blockC in blocks)
            {
                if (this.HitBox.Intersects(blockC.HitBox))
                    Console.WriteLine("Bola >< Retangulo");
            }
        }
    }

    public class Block
    {
        private Texture2D texture;
        private Vector2 position;

        public Rectangle HitBox => new Rectangle((int)position.X, 
                                                 (int)position.Y, 
                                                 texture.Width, 
                                                 texture.Height
                                                );

        public Block(float x, float y)
        {
            position = new Vector2(x + TestGame.windowWidth / 2,
                                        y + TestGame.windowHeight / 2
                                       );
        }
        
        public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            texture = Content.Load<Texture2D>("block");
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
        _spriteBatch.Draw(texture,
                          position,
                          Color.White
                         );
        }
    }
}